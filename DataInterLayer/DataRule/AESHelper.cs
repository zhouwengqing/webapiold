using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class AESHelper
    {
        private static byte[] Operation(byte[] src, string strKey, bool isEncrypt)
        {
            if (string.IsNullOrEmpty(strKey))
                return null;

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(strKey),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform;

            if (isEncrypt)
            {
                cTransform = rm.CreateEncryptor();
            }
            else
            {
                cTransform = rm.CreateDecryptor();
            }

            byte[] resultArray = cTransform.TransformFinalBlock(src, 0, src.Length);
            return resultArray;
        }

        public static byte[] Encrypt(byte[] src, string strKey)
        {
            return Operation(src, strKey, true);
        }

        public static byte[] Decrypt(byte[] src, string strKey)
        {
            return Operation(src, strKey, false);
        }
    }
}
