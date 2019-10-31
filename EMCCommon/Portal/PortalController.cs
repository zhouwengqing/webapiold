using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EMCCommon.Portal.Model;
using System.Data.Entity.Migrations;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EMCCommon.Portal
{
    public class PortalController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        RuletblFW_Log rule_log = new RuletblFW_Log();





        #region 用户相关API


        /// <summary>
        /// 功能描述：查询用户
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-15
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage QueryUser(QueryUser_Info info)
        {
            string result = string.Empty;
            QueryUser_Return QR = new QueryUser_Return();
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    if (info.fldUserName == null)
                    {
                        var query = from x in db.tblFW_User
                                    select x;

                        QR.tblFW_User = query.ToList();

                        var query2 = from x in db.tblFW_Role
                                     select x;

                        QR.tblFW_Role = query2.ToList();

                        var query3 = from x in db.tblFW_User_Role
                                     select x;

                        QR.tblFW_User_Role = query3.ToList();
                    }
                    else
                    {

                        var query = from x in db.tblFW_User
                                    where x.fldUserName.Contains(info.fldUserName) &&
                                    x.fldActive == info.fldActive &&
                                    x.fldCityID == info.fldCityID &&
                                    x.fldDeptID == info.fldDeptID
                                    select x;

                        QR.tblFW_User = query.ToList();

                        var query2 = from x in query
                                     join y in db.tblFW_User_Role
                                     on x.fldAutoID equals y.fldUserID
                                     select y;

                        QR.tblFW_User_Role = query2.ToList();



                        var query3 = from x in query2
                                     join y in db.tblFW_Role
                                     on x.fldRoleID equals y.fldAutoID
                                     select y;

                        QR.tblFW_Role = query3.ToList();




                    }


                }

                if (true)
                {
                    result = rule.JsonStr("ok", "", QR);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class QueryUser_Info
        {
            /// <summary>
            /// 用户名
            /// </summary>
            public string fldUserName { get; set; }


            /// <summary>
            /// false：停用
            /// true：激活
            /// </summary>
            public bool fldActive { get; set; }


            public int fldCityID { get; set; }

            public int fldDeptID { get; set; }
        }


        public class QueryUser_Return
        {
            /// <summary>
            /// 用户表
            /// </summary>
            public List<tblFW_User> tblFW_User { get; set; }


            /// <summary>
            /// 角色表
            /// </summary>
            public List<tblFW_Role> tblFW_Role { get; set; }


            /// <summary>
            /// 用户-角色表
            /// </summary>
            public List<tblFW_User_Role> tblFW_User_Role { get; set; }
        }






        /// <summary>
        /// 功能描述：新建用户
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-15
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_User(AddOrUpdate_User_Info info)
        {
            string result = string.Empty;
            int result2 = 0;
            tblFW_User user = new tblFW_User();
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    user.fldAutoID = info.fldAutoID;
                    user.fldUserName = info.fldUserName;
                    user.fldUserDesc = info.fldUserDesc;
                    user.fldPassword = MD5Encrypt(info.fldPassword).ToUpper();
                    user.fldDeptID = info.fldDeptID;
                    user.fldCityID = info.fldCityID;
                    user.fldDuty = info.fldDuty;
                    user.fldHeaderShip = info.fldHeaderShip;
                    user.fldSex = info.fldSex;
                    user.fldEducation = info.fldEducation;

                    if (info.fldBirthday == null || info.fldBirthday == "")
                    {
                        user.fldBirthday = null;
                    }
                    else
                    {
                        user.fldBirthday = DateTime.Parse(info.fldBirthday);
                    }

                    user.fldEmail = info.fldEmail;
                    user.fldPhone = info.fldPhone;
                    user.fldMobile = info.fldMobile;
                    user.fldActive = info.fldActive;
                    user.fldMemo = info.fldMemo;

                    db.tblFW_User.AddOrUpdate(user);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建成功！用户ID为：" + user.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class AddOrUpdate_User_Info
        {
            public int fldAutoID { get; set; }

            public string fldUserName { get; set; }

            public string fldUserDesc { get; set; }

            public string fldPassword { get; set; }

            public int fldDeptID { get; set; }

            public int fldCityID { get; set; }

            public string fldDuty { get; set; }

            public string fldHeaderShip { get; set; }

            public bool fldSex { get; set; }

            public short fldEducation { get; set; }

            public string fldBirthday { get; set; }

            public string fldEmail { get; set; }

            public string fldPhone { get; set; }

            public string fldMobile { get; set; }

            public bool fldActive { get; set; }

            public string fldMemo { get; set; }
        }

        ///   <summary>
        ///   给一个字符串进行MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strText)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower();
        }















        /// <summary>
        /// 功能描述：删除用户
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_User(Delete_User_Info info)
        {
            string result = string.Empty;
            List<tblFW_User> list = new List<tblFW_User>();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    list = (from x in db.tblFW_User
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFW_User.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_User_Info
        {
            public int[] IDList { get; set; }
        }








        #endregion



        #region 角色相关API


        /// <summary>
        /// 功能描述：查询角色
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage QueryRole(QueryRole_Info info)
        {
            string result = string.Empty;
            QueryRole_Return QR = new QueryRole_Return();
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    if (info.fldName == null)
                    {
                        var query = from x in db.tblFW_Role
                                    select x;
                        QR.tblFW_Role = query.ToList();

                        var query2 = from x in db.tblFW_RightSet
                                     select x;
                        QR.tblFW_RightSet = query2.ToList();

                        var query3 = from x in db.tblFW_Role_RightSet
                                     select x;
                        QR.tblFW_Role_RightSet = query3.ToList();
                    }
                    else
                    {
                        var query = from x in db.tblFW_Role
                                    where x.fldName == info.fldName &&
                                    x.fldCityID == info.fldCityID
                                    select x;

                        QR.tblFW_Role = query.ToList();

                        var query2 = from x in query
                                     join y in db.tblFW_Role_RightSet
                                     on x.fldAutoID equals y.fldRoleID
                                     select y;

                        QR.tblFW_Role_RightSet = query2.ToList();



                        var query3 = from x in query2
                                     join y in db.tblFW_RightSet
                                     on x.fldRightSetID equals y.fldAutoID
                                     select y;

                        QR.tblFW_RightSet = query3.ToList();

                    }
                }

                result = rule.JsonStr("ok", "", QR);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class QueryRole_Info
        {
            public string fldName { get; set; }

            public int fldCityID { get; set; }
        }


        public class QueryRole_Return
        {
            /// <summary>
            /// 角色表
            /// </summary>
            public List<tblFW_Role> tblFW_Role { get; set; }

            /// <summary>
            /// 权限表
            /// </summary>
            public List<tblFW_RightSet> tblFW_RightSet { get; set; }

            /// <summary>
            ///[角色-权限]表
            /// </summary>
            public List<tblFW_Role_RightSet> tblFW_Role_RightSet { get; set; }
        }










        /// <summary>
        /// 功能描述：新建或者更新角色
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_Role(AddOrUpdate_Role_Info info)
        {
            string result = string.Empty;
            tblFW_Role role = new tblFW_Role();
            int result2 = 0;
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    role.fldAutoID = info.fldAutoID;
                    role.fldName = info.fldName;
                    role.fldRoleDesc = info.fldRoleDesc;
                    role.fldCityID = info.fldCityID;

                    db.tblFW_Role.AddOrUpdate(role);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建或者更新成功！角色ID为：" + role.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class AddOrUpdate_Role_Info
        {
            public int fldAutoID { get; set; }

            public string fldName { get; set; }

            public string fldRoleDesc { get; set; }

            public int fldCityID { get; set; }
        }








        /// <summary>
        /// 功能描述：删除角色
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_Role(Delete_Role_Info info)
        {
            string result = string.Empty;
            List<tblFW_Role> list = new List<tblFW_Role>();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    list = (from x in db.tblFW_Role
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFW_Role.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_Role_Info
        {
            public int[] IDList { get; set; }
        }




        #endregion



        #region [用户-角色]相关


        /// <summary>
        /// 功能描述：更新[用户-角色]
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Update_User_Role(Update_User_Role_Info info)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    var query = (from x in db.tblFW_User_Role
                                 where x.fldUserID == info.UserID
                                 select x).ToList();

                    db.tblFW_User_Role.RemoveRange(query);

                    result2 += db.SaveChanges();

                    foreach (var item in info.RoleIDList)
                    {
                        tblFW_User_Role user_role = new tblFW_User_Role();
                        user_role.fldUserID = info.UserID;
                        user_role.fldRoleID = item;

                        db.tblFW_User_Role.Add(user_role);
                    }

                    result2 += db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "更新成功！", "");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可更新的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Update_User_Role_Info
        {
            public int UserID { get; set; }

            public List<int> RoleIDList { get; set; }
        }


        #endregion



        #region 权限相关API


        /// <summary>
        /// 功能描述：查询权限
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-17
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage QueryRightSet(QueryRightSet_Info info)
        {
            string result = string.Empty;
            try
            {
                List<tblFW_RightSet> list = new List<tblFW_RightSet>();

                using (PortalEntity db = new PortalEntity())
                {
                    if (info.fldName == null)
                    {
                        list = (from x in db.tblFW_RightSet
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblFW_RightSet
                                where x.fldName == info.fldName &&
                                x.fldParentID == info.fldParentID
                                select x).ToList();
                    }
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class QueryRightSet_Info
        {
            public string fldName { get; set; }

            public int fldParentID { get; set; }
        }










        /// <summary>
        /// 功能描述：新建或者更新权限
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_RightSet(AddOrUpdate_RightSet_Info info)
        {
            string result = string.Empty;
            tblFW_RightSet rightset = new tblFW_RightSet();
            int result2 = 0;
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    rightset.fldAutoID = info.fldAutoID;
                    rightset.fldName = info.fldName;
                    rightset.fldFlag = info.fldFlag;
                    rightset.fldKeyword = info.fldKeyword;
                    rightset.fldParentID = info.fldParentID;
                    rightset.fldOrder = info.fldOrder;
                    rightset.fldLevel = info.fldLevel;
                    rightset.fldTarget = info.fldTarget;
                    rightset.fldBusinessPoint = info.fldBusinessPoint;
                    rightset.fldWebSiteTag = info.fldWebSiteTag;
                    rightset.fldImage = info.fldImage;

                    db.tblFW_RightSet.AddOrUpdate(rightset);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建或者更新成功！权限ID为：" + rightset.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class AddOrUpdate_RightSet_Info
        {
            public int fldAutoID { get; set; }

            public string fldName { get; set; }

            public short fldFlag { get; set; }

            public string fldKeyword { get; set; }

            public int fldParentID { get; set; }

            public short fldOrder { get; set; }

            public short fldLevel { get; set; }

            public short fldTarget { get; set; }

            public bool fldBusinessPoint { get; set; }

            public short fldWebSiteTag { get; set; }

            public string fldImage { get; set; }
        }








        /// <summary>
        /// 功能描述：删除角色
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_RightSet(Delete_RightSet_Info info)
        {
            string result = string.Empty;
            List<tblFW_RightSet> list = new List<tblFW_RightSet>();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    list = (from x in db.tblFW_RightSet
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFW_RightSet.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_RightSet_Info
        {
            public int[] IDList { get; set; }
        }



        #endregion



        #region [角色-权限]相关


        /// <summary>
        /// 功能描述：更新[用户-角色]
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Update_Role_RightSet(Update_Role_RightSet_Info info)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    var query = (from x in db.tblFW_Role_RightSet
                                 where x.fldRoleID == info.RoleID
                                 select x).ToList();

                    db.tblFW_Role_RightSet.RemoveRange(query);

                    result2 += db.SaveChanges();

                    foreach (var item in info.RightSetIDList)
                    {
                        tblFW_Role_RightSet role_rightset = new tblFW_Role_RightSet();
                        role_rightset.fldRoleID = info.RoleID;
                        role_rightset.fldRightSetID = item;

                        db.tblFW_Role_RightSet.Add(role_rightset);
                    }

                    result2 += db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "更新成功！", "");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可更新的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Update_Role_RightSet_Info
        {
            public int RoleID { get; set; }

            public List<int> RightSetIDList { get; set; }
        }





        #endregion



        #region 城市相关API



        /// <summary>
        /// 功能描述：查询城市
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage QueryCity(QueryCity_Info info)
        {
            string result = string.Empty;
            try
            {

                List<tblFW_RegCity> list = new List<tblFW_RegCity>();

                using (PortalEntity db = new PortalEntity())
                {
                    if (info.fldSTCode == null)
                    {
                        list = (from x in db.tblFW_RegCity
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblFW_RegCity
                                where x.fldSTCode == info.fldSTCode
                                select x).ToList();
                    }
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class QueryCity_Info
        {
            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }
        }





        /// <summary>
        /// 功能描述：新增或者更新城市
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_City(AddOrUpdate_City_Info info)
        {
            string result = string.Empty;
            tblFW_RegCity city = new tblFW_RegCity();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    city.fldAutoID = info.fldAutoID;
                    city.fldSTCode = info.fldSTCode;
                    city.fldSTName = info.fldSTName;
                    city.fldParentID = info.fldParentID;
                    city.fldNeedAuditing = info.fldNeedAuditing;
                    city.fldISLogin = info.fldISLogin;
                    city.fldSort = info.fldSort;
                    city.fldSTCodeGA = info.fldSTCodeGA;
                    city.fldCityArea = info.fldCityArea;
                    city.fldLatitude = info.fldLatitude;
                    city.fldLongitude = info.fldLongitude;

                    db.tblFW_RegCity.AddOrUpdate(city);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建或者更新成功！城市ID为：" + city.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class AddOrUpdate_City_Info
        {
            public int fldAutoID { get; set; }

            public string fldSTCode { get; set; }

            public string fldSTName { get; set; }

            public int fldParentID { get; set; }

            public bool fldNeedAuditing { get; set; }

            public bool fldISLogin { get; set; }

            public int fldSort { get; set; }

            public string fldSTCodeGA { get; set; }

            public short fldCityArea { get; set; }

            public decimal fldLatitude { get; set; }

            public decimal fldLongitude { get; set; }
        }








        /// <summary>
        /// 功能描述：删除城市
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_City(Delete_City_Info info)
        {
            string result = string.Empty;
            List<tblFW_RegCity> list = new List<tblFW_RegCity>();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    list = (from x in db.tblFW_RegCity
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFW_RegCity.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_City_Info
        {
            public int[] IDList { get; set; }
        }









        #endregion



        #region 部门相关API



        /// <summary>
        /// 功能描述：查询部门
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage QueryDept(QueryDept_Info info)
        {
            string result = string.Empty;
            try
            {

                List<tblFW_Dept> list = new List<tblFW_Dept>();

                using (PortalEntity db = new PortalEntity())
                {
                    if (info.fldDeptCode == null)
                    {
                        list = (from x in db.tblFW_Dept
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblFW_Dept
                                where x.fldDeptCode == info.fldDeptCode
                                select x).ToList();
                    }
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class QueryDept_Info
        {
            /// <summary>
            /// 部门代码
            /// </summary>
            public string fldDeptCode { get; set; }
        }







        /// <summary>
        /// 功能描述：新增或者更新部门
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_Dept(AddOrUpdate_Dept_Info info)
        {
            string result = string.Empty;
            tblFW_Dept dept = new tblFW_Dept();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    dept.fldAutoID = info.fldAutoID;
                    dept.fldDeptCode = info.fldDeptCode;
                    dept.fldDeptName = info.fldDeptName;
                    dept.fldCityID = info.fldCityID;

                    db.tblFW_Dept.AddOrUpdate(dept);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建或者更新成功！部门ID为：" + dept.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class AddOrUpdate_Dept_Info
        {
            public int fldAutoID { get; set; }

            public string fldDeptCode { get; set; }

            public string fldDeptName { get; set; }

            public int fldCityID { get; set; }
        }





        /// <summary>
        /// 功能描述：删除部门
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-16
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_Dept(Delete_Dept_Info info)
        {
            string result = string.Empty;
            List<tblFW_Dept> list = new List<tblFW_Dept>();
            int result2 = 0;

            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    list = (from x in db.tblFW_Dept
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFW_Dept.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_Dept_Info
        {
            public int[] IDList { get; set; }
        }




        #endregion




        #region 登陆认证

        /// <summary>
        /// 功能描述：登陆认证
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-17
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login(Login_Info info)
        {
            string result = string.Empty;
            //string password = MD5Encrypt(info.fldPassword);
            List<tblFW_RightSet> list = new List<tblFW_RightSet>();

            tblFW_User User = new tblFW_User();

            Login_Return login_return = new Login_Return();

            try
            {

                using (PortalEntity db = new PortalEntity())
                {

                    User = (from x in db.tblFW_User
                            where x.fldUserName == info.fldUserName
                            select x).FirstOrDefault();

                    if (User == null)
                    {
                        result = rule.JsonStr("error", "用户名不存在！", "");
                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }

                    //用户加密后的密码
                    string pwd1 = MD5Encrypt(User.fldPassword.ToLower() + info.DateTimeNow);

                    //传入加密后的密码
                    //string pwd2 = MD5Encrypt(password + info.DateTimeNow);

                    if (pwd1 != info.fldPassword)
                    {
                        result = rule.JsonStr("error", "密码错误！", "");
                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }




                    DateTime dtime = DateTime.Parse(DateTime.Now.ToShortDateString());

                    FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, info.fldUserName, dtime, DateTime.Now.AddHours(3), true, string.Format("{0}&{1}&{2}", info.fldUserName, pwd1, User.fldCityID), FormsAuthentication.FormsCookiePath);
                    //返回登录结果、用户信息、用户验证票据信息
                    var Token = FormsAuthentication.Encrypt(token);






                    LoginInfo lginfo = new LoginInfo();


                    byte[] value = Func_AES128加密(User.fldAutoID.ToString(), "abcdef1234567890");



                    lginfo.UserID = User.fldAutoID.ToString();
                    lginfo.UserName = User.fldUserName;
                    lginfo.UserDesc = User.fldUserDesc;
                    lginfo.Token = Token;
                    lginfo.CityID = User.fldCityID;

                    var query2 = from x in db.tblFW_User_Role
                                 where x.fldUserID == User.fldAutoID
                                 select x;

                    var query3 = from x in query2
                                 join y in db.tblFW_Role
                                 on x.fldRoleID equals y.fldAutoID
                                 select y;

                    var query4 = from x in query3
                                 join y in db.tblFW_Role_RightSet
                                 on x.fldAutoID equals y.fldRoleID
                                 select y;

                    list = (from x in query4
                            join y in db.tblFW_RightSet
                            on x.fldRightSetID equals y.fldAutoID
                            select y).ToList();
                    login_return.RightSet_List = list.DistinctBy(p=> new { p.fldAutoID}).ToList();

                    login_return.Login_Info = lginfo;







                    using (Lap.Model.LAPContext db_Lap = new Lap.Model.LAPContext())
                    {
                        Lap.Model.tblFW_Log log = new Lap.Model.tblFW_Log();
                        log.fldModalName = info.fldModalName;
                        log.fldUserID = User.fldAutoID;
                        log.fldCityID = User.fldCityID;
                        log.fldContent = "用户登录系统";
                        log.fldDate_operate = DateTime.Now;

                        if (info.fldIPAddress == null || info.fldIPAddress == "")
                        {
                            log.fldIPAddress = GetIP();
                            if (log.fldIPAddress == null || log.fldIPAddress == "")
                            {
                                log.fldIPAddress = "::1";
                            }
                        }
                        else
                        {
                            log.fldIPAddress = info.fldIPAddress;
                        }

                        db_Lap.tblFW_Log.Add(log);
                        db_Lap.SaveChanges();
                    }


                }





                result = rule.JsonStr("ok", "", login_return);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Login_Info
        {
            public string fldUserName { get; set; }

            public string fldPassword { get; set; }

            public string DateTimeNow { get; set; }

            public string fldModalName { get; set; }

            public string fldIPAddress { get; set; }
        }






        public class Login_Return
        {
            public LoginInfo Login_Info { get; set; }

            public List<tblFW_RightSet> RightSet_List { get; set; }
        }



        /// <summary>
        /// 登录用户信息
        /// </summary>
        public class LoginInfo
        {
            /// <summary>
            /// 用户ID
            /// </summary>
            public string UserID { get; set; }


            /// <summary>
            /// 登录用户名
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 用户身份验证密钥
            /// </summary>
            public string Token { get; set; }


            public string UserDesc { get; set; }


            /// <summary>
            /// 登录用户城市ID
            /// </summary>
            public int CityID { get; set; }
        }







        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        }









































        /// <summary>
        /// 功能描述：获取用户权限
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-27
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login_RightSet(Login_RightSet_Info info)
        {
            string result = string.Empty;
            List<tblFW_RightSet> list = new List<tblFW_RightSet>();

            byte[] key = Encoding.UTF8.GetBytes("abcdef1234567890");

            //byte[] vk = Func_AES128解密(info.fldAutoID, key);

            //string userid = Encoding.UTF8.GetString(vk).TrimEnd('\u000f').TrimEnd('\u000e').TrimEnd().Trim();
            string userid = info.fldAutoID;
            int id = int.Parse(userid.Trim());


            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    var query = (from x in db.tblFW_User
                                 where x.fldAutoID == id
                                 select x).FirstOrDefault();

                    var query2 = from x in db.tblFW_User_Role
                                 where x.fldUserID == query.fldAutoID
                                 select x;

                    var query3 = from x in query2
                                 join y in db.tblFW_Role
                                 on x.fldRoleID equals y.fldAutoID
                                 select y;

                    var query4 = from x in query3
                                 join y in db.tblFW_Role_RightSet
                                 on x.fldAutoID equals y.fldRoleID
                                 select y;

                    list = (from x in query4
                            join y in db.tblFW_RightSet
                            on x.fldRightSetID equals y.fldAutoID
                            select y).ToList();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Login_RightSet_Info
        {
            public string fldAutoID { get; set; }
        }






        /// <summary>
        ///  ASE_128_ECB_无填充_64Base_解密函数
        /// </summary>
        /// <param name="content">密串（字节）</param>
        /// <param name="keyArray">密钥（字节）</param>
        /// <returns>解密后的字符串</returns>
        public static byte[] Func_AES128解密(byte[] content, byte[] keyArray)
        {
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.None;
            rDel.BlockSize = 128;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(content, 0, content.Length);
            return resultArray;
        }


        /// <summary>
        /// ASE_128_ECB_无填充_64Base_加密函数
        /// </summary>
        /// <param name="content">要加密的内容</param>
        /// <param name="key">一定要16位的密钥</param>
        /// <returns>加密的字符串（字节）</returns>
        public static byte[] Func_AES128加密(string content, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(content);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            //返回字节数组，可用Convert.FromBase64String（）转换为字节
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);    

            return resultArray;
        }



        #endregion






        #region 重置密码


        /// <summary>
        /// 功能描述：重置密码
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-18
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ResetPassWord(ResetPassWord_Info info)
        {
            string result = string.Empty;
            string password = MD5Encrypt(info.PassWord_New);
            int num = 0;
            tblFW_User user = new tblFW_User();
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    user = (from x in db.tblFW_User
                            where x.fldAutoID == info.UserID
                            select x).FirstOrDefault();

                    user.fldPassword = password.ToUpper();



                    db.tblFW_User.AddOrUpdate(user);
                    num = db.SaveChanges();

                }

                if (num > 0)
                {
                    result = rule.JsonStr("ok", "", "用户ID：" + user.fldAutoID + "的密码修改成功！密码为：" + info.PassWord_New + "加密后为：" + user.fldPassword);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class ResetPassWord_Info
        {
            public int UserID { get; set; }

            public string PassWord_New { get; set; }
        }

        #endregion


















        /// <summary>
        /// 功能描述：修改状态
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-18
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeActive(ChangeActive_Info info)
        {
            string result = string.Empty;
            int num = 0;
            tblFW_User user = new tblFW_User();
            try
            {
                using (PortalEntity db = new PortalEntity())
                {
                    user = (from x in db.tblFW_User
                            where x.fldAutoID == info.UserID
                            select x).FirstOrDefault();

                    user.fldActive = info.fldActive;

                    db.tblFW_User.AddOrUpdate(user);
                    num = db.SaveChanges();

                }

                if (num > 0)
                {
                    result = rule.JsonStr("ok", "", "用户ID：" + user.fldAutoID + "的状态修改成功！");
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class ChangeActive_Info
        {
            public int UserID { get; set; }

            public bool fldActive { get; set; }
        }



    }







    public static class HttpRequestMessageExtensions
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage =
            "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            // Web-hosting. Needs reference to System.Web.dll
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            // Self-hosting. Needs reference to System.ServiceModel.dll. 
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic owinContext = request.Properties[OwinContext];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;
        }
    }
}
