using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FarmTick
{
    public class FarmClient
    {
        private string GetLoginPass(string pass, string verify)
        {
            return GetMD5Hash(GetMD5Hash(pass, 3).ToUpper() + verify.ToUpper()).ToUpper();
        }

        private string GetFarmTime()
        {
            return Math.Floor((DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds).ToString();
        }

        // 获得FarmKey
        private string GetFarmKey(string farmTime)
        {
            return GetMD5Hash(farmTime + "fs#$hsJ!Fa*AF!-0aPS".Substring(Convert.ToInt32(farmTime) % 10));
        }

        // MD5加密算法, count为加密次数
        private static string GetMD5Hash(string input)
        {
            return GetMD5Hash(input, 1);
        }
        private static string GetMD5Hash(string input, int count)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(input);
            for (int i = 0; i < count; i++)
                buffer = md5.ComputeHash(buffer);
            return Bin2Hex(buffer);
        }

        // 将字节数组转换为16进制表示
        private static string Bin2Hex(byte[] binbytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < binbytes.Length; i++)
                sb.Append(binbytes[i].ToString("x2"));
            return sb.ToString();
        }
    }
}
