using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ConsoleApp2;

namespace ConsoleApp2
{
    public class HashContent
    {
        string GetHashContent(string content)
        {
            var tmpSorce = ASCIIEncoding.ASCII.GetBytes(content);
            var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSorce);
            var tmpHashStr = CryptographyTools.ByteToArrayToString(tmpHash);
            return tmpHashStr;
        }
    }
}
