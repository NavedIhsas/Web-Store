using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common
{
    public class EncryptSaleInType
    {


        public void Main(string text)
        {
            //text value : Dynamics || SaleIn || Shygun

            using var rsa = new RSACryptoServiceProvider();
            using var aes = Aes.Create();
            var enc = EncryptSaleInType.EncryptString(text, rsa.ExportParameters(false), false);
            var dec = EncryptSaleInType.DecryptString(enc, rsa.ExportParameters(true), false);

        }

        public static string EncryptString(string inputString, RSAParameters parameters, bool fOaep)
        {
            byte[] encryptedData;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(parameters);
                encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(inputString), fOaep);
            }
            return Convert.ToBase64String(encryptedData);
        }

       public static string DecryptString(string inputString, RSAParameters parameters, bool fOaep)
        {
            byte[] decryptedData;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(parameters);
                decryptedData = rsa.Decrypt(Convert.FromBase64String(inputString), fOaep);
            }
            return Encoding.UTF8.GetString(decryptedData);
        }
    }

}
