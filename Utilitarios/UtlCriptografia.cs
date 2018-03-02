using System.IO;
using System.Security.Cryptography;

namespace Utilitarios
{
    /// <summary>
    /// Classe utilitária para trabalhar com criptografia
    /// </summary>
    public static class UtlCriptografia
    {
        /// <summary>
        /// Criptografa uma string
        /// </summary>
        /// <param name="inputString">string a ser criptografada</param>
        /// <returns>string criptografada</returns>
        public static string Criptografa(string inputString)
        {
            byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            MemoryStream InputStream = new MemoryStream();
            byte[] InputByte = new byte[inputString.Length];
            InputByte = System.Text.Encoding.Default.GetBytes(inputString);
            InputStream.Write(InputByte, 0, InputByte.Length);
            InputStream.Position = 0;

            MemoryStream OutputStream = new MemoryStream();
            byte[] Buffer = new byte[128];

            //SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create("Rijndael"); //Create Rijndael não funciona no .Net Core. Usar Aes.Create()
            SymmetricAlgorithm Algorithm = Aes.Create();
            Algorithm.IV = IV;
            Algorithm.Key = Key;
            ICryptoTransform Transform = Algorithm.CreateEncryptor();
            CryptoStream CryptStream = new CryptoStream(OutputStream, Transform, CryptoStreamMode.Write);

            int RemainingBufferLength = InputStream.Read(Buffer, 0, Buffer.Length);
            while (RemainingBufferLength > 0)
            {
                CryptStream.Write(Buffer, 0, RemainingBufferLength);
                RemainingBufferLength = InputStream.Read(Buffer, 0, Buffer.Length);
            }
            CryptStream.FlushFinalBlock();

            string OutputString = System.Convert.ToBase64String(OutputStream.ToArray());

            CryptStream.Close();
            CryptStream = null;
            InputStream.Close();
            InputStream = null;
            OutputStream.Close();
            OutputStream = null;

            return OutputString;
        }

        /// <summary>
        /// Descriptografa uma string
        /// </summary>
        /// <param name="inputString">string a ser descriptografada</param>
        /// <returns>string descriptografada</returns>
        public static string Descriptografa(string inputString)
        {
            byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            MemoryStream InputStream = new MemoryStream();
            byte[] InputByte = System.Convert.FromBase64String(inputString);
            InputStream.Write(InputByte, 0, InputByte.Length);
            InputStream.Position = 0;

            MemoryStream OutputStream = new MemoryStream();
            byte[] Buffer = new byte[128];

            //SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create("Rijndael"); //Create Rijndael não funciona no .Net Core. Usar Aes.Create()
            SymmetricAlgorithm Algorithm = Aes.Create();
            Algorithm.IV = IV;
            Algorithm.Key = Key;
            ICryptoTransform Transform = Algorithm.CreateDecryptor();
            CryptoStream CryptStream = new CryptoStream(InputStream, Transform, CryptoStreamMode.Read);

            int RemainingBufferLength = CryptStream.Read(Buffer, 0, Buffer.Length);
            while (RemainingBufferLength > 0)
            {
                OutputStream.Write(Buffer, 0, RemainingBufferLength);
                RemainingBufferLength = CryptStream.Read(Buffer, 0, Buffer.Length);
            }

            string OutputString = System.Text.Encoding.Default.GetString(OutputStream.ToArray());

            CryptStream.Close();
            CryptStream = null;
            InputStream.Close();
            InputStream = null;
            OutputStream.Close();
            OutputStream = null;

            return OutputString;
        }
    }
}
