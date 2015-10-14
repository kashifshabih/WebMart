using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardService.BLL
{
    public class SecurityKey
    {
        public string GetDecrypt(string ciphertext)
        {
            //Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            //KeyValueConfigurationElement Appsetting = config.AppSettings.Settings["sequence"];
            //var key = StringToBinary(Appsetting.Value);
            //var xor = "";
            //for (var i = 0; i < ciphertext.Length; ++i)
            //    xor += ciphertext[i] ^ key[i % key.Length];
            //return BinaryToString(xor);

            return "";
        }
    }
}