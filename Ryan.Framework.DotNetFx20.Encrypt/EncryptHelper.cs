////////////////////////////////////////
//ver		:1.1.0.0
//Create by  	:Ray
//Create Date	:2012-11-29
//last Update	:2012-11-30
//Description	:Ray Encrypt Utilty
//UpdateLog	:
//2012-11-30	新增MD5Encrypt()
//2012-11-30	新增HashEncrypt()
//2012-11-30	新增MD5HashCodeEncrypt()
//2012-11-30	新增HashCodeMD5Encrypt
//2018-03-10    加重载
//2019-11-01    SHA1Encrypt()
/////////////////////////////////////////
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ryan.Framework.DotNetFx20.Encrypt
{
    public sealed class EncryptHelper
    {
        /// <summary>
        /// 默认的key
        /// </summary>
        static readonly string key = "77052300";
        public EncryptHelper()
        { }

        ///// <summary>  
        /////方法一:  
        /////此种加密之后的字符串是三十二位的(字母加数据)字符串   
        ///// Example:password是admin 加密变成后21232f297a57a5a743894a0e4a801fc3  
        ///// </summary>  
        ///// <param name="beforeStr"></param>  
        ///// <returns></returns>  
        //public static string MD5_Encrypt(string beforeStr)
        //{
        //    string afterString = "";
        //    try
        //    {
        //        MD5 md5 = MD5.Create();
        //        byte[] hashs = md5.ComputeHash(Encoding.UTF8.GetBytes(beforeStr));

        //        foreach (byte by in hashs)
        //            //这里是字母加上数据进行加密.//3y 可以,y3不可以或 x3j等应该是超过32位不可以  
        //            afterString += by.ToString("x2");
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return afterString;
        //}
        ///// <summary>  
        ///// 方法:二  
        /////HashAlgorithm加密  
        ///// 这种加密是 字母加-加字符   
        ///// Example:password是admin 加密变成后19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12  
        ///// </summary>  
        ///// <param name="password"></param>  
        ///// <returns></returns>  
        //public static String HashEncrypt(string password)
        //{
        //    Byte[] hashedBytes = null;
        //    try
        //    {
        //        Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
        //        hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return BitConverter.ToString(hashedBytes);//MD5加密  
        //}

        ///// <summary>  
        ///// 方法:三  
        ///// MD5  +  HashCode加密  
        ///// Example:password是admin 加密变成后 895b7da64943134be17b825ce118456c  
        ///// </summary>  
        ///// <returns></returns>  
        //public static String MD5HashCodeEncrypt(string EncryptPwd)
        //{
        //    return MD5Encrypt(HashEncrypt(EncryptPwd)); //在HashEncrypt基础上再MD5  
        //}

        ///// <summary>  
        ///// 方法:四  
        ///// HashCode+MD5 加密  
        ///// Example:password是admin 加密变成后EB-1D-6D-E2-FC-F1-CD-94-4D-75-78-E6-3D-7A-12-32  
        ///// </summary>  
        ///// <param name="EncryptPwd"></param>  
        ///// <returns></returns>  
        //public static String HashCodeMD5Encrypt(string EncryptPwd)
        //{
        //    return HashEncrypt(MD5_Encrypt(EncryptPwd)); //在MD5基础再HashCode  
        //}
        ///// <summary>  
        ///// 方法:五  
        ///// </summary>  
        ///// <param name="EncryptPwd"></param>  
        ///// <returns></returns>
        //public static String HashMD5Encrypt(string EncryptPwd)
        //{
        //    return HashCodeMD5Encrypt(HashCodeMD5Encrypt(EncryptPwd)); //在HashCodeMD5Encrypt基础再HashCode  
        //}
        ///// <summary>  
        ///// 方法:六  
        ///// 哈哈 是不是  有点晕呢？  
        ///// 大家伙可以继续写下去  
        ///// </summary>  
        ///// <param name="EncryptPwd"></param>  
        ///// <returns></returns>  
        //public static string MD5HashEncrypt(string EncryptPwd)
        //{
        //    return MD5HashCodeEncrypt(MD5HashCodeEncrypt(EncryptPwd)); //在MD5基础再HashCode  
        //}


        #region DES

        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(string Key, string str)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
            byte[] bIV = IV;
            byte[] bStr = Encoding.UTF8.GetBytes(str);
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, desc.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);
                cStream.Write(bStr, 0, bStr.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string Key, string DecryptStr)
        {
            try
            {
                byte[] bKey = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
                byte[] bIV = IV;
                byte[] bStr = Convert.FromBase64String(DecryptStr);
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, desc.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);
                cStream.Write(bStr, 0, bStr.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        #region 重载

        public static string Decrypt(string decryptString)
        {
            return Decrypt(key, decryptString);
        }

        public static string Encrypt(string encryptString)
        {
            return Encrypt(key, encryptString);
        }

        #endregion

        #region NEW DES
        /// <summary>
        /// DES加密，对接其他语言使用同一规则用
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        public static string DESEncryptString(string pToEncrypt, string key, string IV)
        {
            Byte[] keyArray = new byte[32];
            keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(key);
            Byte[] ivArray = new byte[32];
            ivArray = System.Text.UTF8Encoding.UTF8.GetBytes(IV);
            Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(pToEncrypt);
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = System.Security.Cryptography.CipherMode.CBC;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <param name="key">加密密钥</param>
        /// <returns></returns>
        public static string DESEncrypt(string EncryptString, byte[] Key, byte[] IV)
        {
            //byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] inputByteArray = Encoding.UTF8.GetBytes(EncryptString);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="input">待解密的字符串</param>
        /// <param name="key">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string DESDecrypt(string DecryptString, byte[] Key, byte[] IV)
        {
            try
            {
                //byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
                byte[] inputByteArray = Convert.FromBase64String(DecryptString);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(Key, IV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #endregion

        #region SHA
        /// <summary>
        /// SHA1 加密 
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <param name="upperOrLower">大小写格式（大写：X2;小写:x2）默认小写</param> 
        public static string SHA1Encrypt(string content, Encoding encode, string upperOrLower = "x2")
        {
            try
            {
                var buffer = encode.GetBytes(content);//用指定编码转为bytes数组
                var data = SHA1.Create().ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString(upperOrLower));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }

        /// <summary>
        /// SHA256 加密 
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <param name="upperOrLower">大小写格式（大写：X2;小写:x2）默认小写</param> 
        public static string SHA256Encrypt(string content, Encoding encode, string upperOrLower = "x2")
        {
            try
            {
                var buffer = encode.GetBytes(content);//用指定编码转为bytes数组
                var data = SHA256.Create().ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString(upperOrLower));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }

        /// <summary>
        /// SHA512 加密 
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <param name="upperOrLower">大小写格式（大写：X2;小写:x2）默认小写</param> 
        public static string SHA512Encrypt(string content, Encoding encode, string upperOrLower = "x2")
        {
            try
            {
                var buffer = encode.GetBytes(content);//用指定编码转为bytes数组
                var data = SHA512.Create().ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString(upperOrLower));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }

        /// <summary>
        /// SHA384 加密 
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <param name="upperOrLower">大小写格式（大写：X2;小写:x2）默认小写</param> 
        public static string SHA384Encrypt(string content, Encoding encode, string upperOrLower = "x2")
        {
            try
            {
                var buffer = encode.GetBytes(content);//用指定编码转为bytes数组
                var data = SHA384.Create().ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString(upperOrLower));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
        #endregion

        #region MD5
        /// <summary>
        /// MD5 加密 
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <param name="upperOrLower">大小写格式（大写：X2;小写:x2）默认小写</param> 
        public static string MD5Encrypt(string content, Encoding encode, string upperOrLower = "x2")
        {
            try
            {
                var buffer = encode.GetBytes(content);//用指定编码转为bytes数组
                var data = MD5.Create().ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString(upperOrLower));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("MD5加密出错：" + ex.Message);
            }
        }
        #endregion
    }
}