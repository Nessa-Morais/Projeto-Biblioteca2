using System.Data.SqlTypes;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.Common;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.AccessControl;
using System;
//using SystemAcl.Security.Cryptography;
//using FileSystemAclExtensions.Text;

namespace Biblioteca.Models
{
     public static class Cryptographya{
       
        
            public static string TextoCryptographado( string senha)
            {
                MD5 MD5Hasher = MD5.Create();

                byte[] By = Encoding.Default.GetBytes(senha);
                byte[] byteCryptographado = MD5Hasher.ComputeHash(By);

                StringBuilder SB = new StringBuilder();

                foreach (byte b in byteCryptographado)
                {
                    string DebugB = b.ToString("x2");
                    SB.Append(DebugB);
                }

                return SB.ToString();
            }
    }
        
}
