using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Words.Tables;
using System.Drawing;


namespace DDYZ.Ensis.Rule.DataRule
{
    public class AsposeWordsHelper
    {

        public AsposeWordsHelper()
        {
        }

        /// <summary>
        /// 功能描述：导出html到word文档保存
        /// 创建  人：周文卿
        /// 创建时间：2017/10/23
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <param name="html">html</param>
        /// <param name="path">路径</param>
        public void htmlword(string html,string path)
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.InsertHtml(@html);
            doc.Save(@path);
        }

        #region 根据doc模板路径返回Document
        /// <summary>
        /// 根据doc模板路径返回Document
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="strDocTemplatePath"></param>
        /// <returns></returns>
        public Document OpenTemplateDoc(string strDocTemplatePath)
        {
            //string tmppath = Server.MapPath("~/template/reporttemplate.doc");
            Document doc = new Document(strDocTemplatePath); //载入模板 
            return doc;
        }

        #endregion

        #region 根据doc模板路径返回DocumentBuiler
        /// <summary>
        /// 根据doc模板路径返回DocumentBuiler
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="strDocTemplatePath"></param>
        /// <returns></returns>
        public DocumentBuilder OpenTemplateDocumentBuilder(string strDocTemplatePath)
        {
            Document doc = new Document(strDocTemplatePath); //载入模板 
            DocumentBuilder builder = new DocumentBuilder(doc);
            return builder;
        }

        #endregion


        #region 创建表格Head Cell
        /// <summary>
        /// 创建表格Head Cell
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strCellValue"></param>
        /// <param name="cellwidth"></param>
        public void CreateHeadCell(DocumentBuilder builder, string strCellValue, double cellwidth)
        {
            builder.InsertCell(); // 添加一个单元格 
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;

            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            //builder.CellFormat.FitText = true;
            //builder.CellFormat.PreferredWidth = PreferredWidth.FromPercent(20) ;
            //builder.CellFormat.PreferredWidth=CellFormat.PreferredWidth.Value;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            builder.Font.Bold = true;
            builder.CellFormat.WrapText = true;
            builder.Font.Name = "宋体";
            builder.Font.Size = 10.5;
            builder.CellFormat.Width = cellwidth;
            //builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
            builder.Write(strCellValue);
        }

        #endregion
        #region 创建表格Head Cell
        /// <summary>
        /// 创建表格Head Cell
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strCellValue"></param>
        /// <param name="cellwidth"></param>
        public void CreateHeadCell2(DocumentBuilder builder, string strCellValue, double cellwidth)
        {
            builder.InsertCell(); // 添加一个单元格 
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            // builder.CellFormat.FitText = true;
            // builder.CellFormat.PreferredWidth = PreferredWidth.FromPercent(20) ;
            //builder.CellFormat.PreferredWidth=CellFormat.PreferredWidth.Value;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            builder.Font.Bold = true;
            builder.CellFormat.WrapText = true;
            builder.Font.Name = "宋体";
            builder.Font.Size = 10.5;
            builder.CellFormat.Width = cellwidth;
            //builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
            builder.Write(strCellValue);
        }

        #endregion

        #region 创建标题文本
        /// <summary>
        /// 创建标题文本
        /// author:du
        /// date:20120723
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strText"></param>

        public void CreateTitleText(DocumentBuilder builder, string strText)
        {
            builder.Font.Name = "宋体";
            builder.Font.Size = 13.5;
            builder.Font.Bold = true;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            builder.Write(strText);

        }

        #endregion

        #region 创建表格Merge Head Cell
        /// <summary>
        /// 创建表格Merge Head Cell
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strCellValue"></param>
        /// <param name="cellwidth"></param>
        public void CreateMergeCell(ref DocumentBuilder builder, string strCellValue, double cellwidth, int iMergeDirection
                , CellMerge cm)
        {
            builder.InsertCell(); // 添加一个单元格 
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.WrapText = true;
            if (iMergeDirection == 0)
            {
                builder.CellFormat.VerticalMerge = cm;
            }
            else if (iMergeDirection == 1)
            {
                builder.CellFormat.HorizontalMerge = cm;

            }


            builder.Font.Name = "宋体";
            builder.Font.Size = 10.5;
            // builder.CellFormat.Width = cellwidth;
            // builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
            if (cm != Aspose.Words.Tables.CellMerge.Previous)
            {
                builder.Write(strCellValue);
            }

        }
        #endregion

        #region 创建表格数据Cell
        /// <summary>
        /// 创建表格数据Cell
        /// author:du
        /// date:20120721
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strCellValue"></param>
        /// <param name="cellwidth"></param>
        public void CreateCell(DocumentBuilder builder, string strCellValue, double cellwidth)
        {
            if (strCellValue == null) strCellValue = "";

            builder.InsertCell(); // 添加一个单元格 
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = Color.Black;
            builder.CellFormat.WrapText = true;
            builder.Font.Name = "宋体";
            builder.Font.Size = 10.5;
            builder.Bold = false;
            builder.CellFormat.Width = cellwidth;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            //builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
            builder.Write(strCellValue);


        }
        /// <summary>
        /// 创建表格数据Cell,增加Font传入
        /// author:du
        /// date:20130111
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="strCellValue"></param>
        /// <param name="cellwidth"></param>
        /// <param name="font"></param>
        public void CreateCell3(DocumentBuilder builder, string strCellValue, double cellwidth, Aspose.Words.Font font)
        {
            if (strCellValue == null) strCellValue = "";

            builder.InsertCell(); // 添加一个单元格 
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.WrapText = false;
            builder.Font.Name = font.Name;
            builder.Font.Size = 10.5;
            builder.Bold = false;
            builder.CellFormat.Width = cellwidth;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
            builder.Write(strCellValue);


        }
        #endregion

        #region MergeCells
        /// <summary>
        /// Merges the range of cells found between the two specified cells both horizontally and vertically. Can span over multiple rows.
        /// </summary>
        public void MergeCells(Cell startCell, Cell endCell)
        {
            Table parentTable = startCell.ParentRow.ParentTable;

            // Find the row and cell indices for the start and end cell.
            Point startCellPos = new Point(startCell.ParentRow.IndexOf(startCell), parentTable.IndexOf(startCell.ParentRow));
            Point endCellPos = new Point(endCell.ParentRow.IndexOf(endCell), parentTable.IndexOf(endCell.ParentRow));
            // Create the range of cells to be merged based off these indices. Inverse each index if the end cell if before the start cell. 
            Rectangle mergeRange = new Rectangle(Math.Min(startCellPos.X, endCellPos.X), Math.Min(startCellPos.Y, endCellPos.Y),
                Math.Abs(endCellPos.X - startCellPos.X) + 1, Math.Abs(endCellPos.Y - startCellPos.Y) + 1);

            foreach (Row row in parentTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    Point currentPos = new Point(row.IndexOf(cell), parentTable.IndexOf(row));

                    // Check if the current cell is inside our merge range then merge it.
                    if (mergeRange.Contains(currentPos))
                    {
                        if (currentPos.X == mergeRange.X)
                            cell.CellFormat.HorizontalMerge = CellMerge.First;
                        else
                            cell.CellFormat.HorizontalMerge = CellMerge.Previous;

                        if (currentPos.Y == mergeRange.Y)
                            cell.CellFormat.VerticalMerge = CellMerge.First;
                        else
                            cell.CellFormat.VerticalMerge = CellMerge.Previous;
                    }
                }
            }
        }
        #endregion


        #region 根据bookmark位置的设置值
        /// <summary>
        /// 根据bookmark位置的设置值
        /// author:du
        /// date:20120723
        /// </summary>
        /// <param name="strDocTemplatePath"></param>
        /// <returns></returns>
        public void setBookmarkValue(ref DocumentBuilder builder, string strBookmarkname, string strValue)
        {
            string strBookmarkName = "TotalCProjectName";
            builder.MoveToBookmark(strBookmarkName);
            builder.Write(strValue);

        }

        #endregion


        #region 合并单元格文本内容相同的单元格
        public void MergeCellByText(Table pTable, int iStartNum, int iColNum, int EndNum)
        {
            string strTemp = "";
            int iTempNum = 0;//存放相同内容的数目
            //int iEndTempRow = iStartNum;

            Cell pStartCell = pTable.Rows[iStartNum].Cells[iColNum];
            Cell pEndCell = pTable.Rows[iStartNum].Cells[iColNum];
            string strFirstText = pTable.Rows[iStartNum].Cells[iColNum].GetText().Trim();

            for (int i = iStartNum + 1; i <= EndNum; i++)
            {
                strTemp = pTable.Rows[i].Cells[iColNum].GetText().Trim();
                if (strTemp == strFirstText)
                {
                    //iEndTempRow = iEndTempRow + 1;
                    iTempNum = iTempNum + 1;

                    if (i == EndNum)//最后一行
                    {
                        pEndCell = pTable.Rows[i].Cells[iColNum];
                        this.MergeCells(pStartCell, pEndCell);
                    }
                }
                else
                {
                    if (iTempNum > 0)
                    {
                        pEndCell = pTable.Rows[i - 1].Cells[iColNum];
                        this.MergeCells(pStartCell, pEndCell);


                    }
                    pStartCell = pTable.Rows[i].Cells[iColNum];
                    strFirstText = strTemp;
                    iTempNum = 0;
                }

            }

        }
        #endregion
    }
}
