
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class GestorDeEncriptacion
{

    static String AESKEY = "eckIEptpScebO7eOMmHlEcH7D8yOTz7GPFT7mrqSnY4=";
    static String AESIV = "AK8p702PFr4eWbb6B1g82Q==";
    static String RSAPublicKey = "<RSAKeyValue><Modulus>tsBjrD7cndJc2qhIi0g889KsAy3w/YH+35+k7QsHA23nS8sMwfLzYPjVqYXe+xzJyGr5iaBT58XSoDDTVMViaC/x7XqXlAQyLuHcwrRX2XbLatKXLXfk7glaBGsR/YTUgqDEFlFn6qtMdb8ho3xbw2VC93si6hlpwoYdYqqTu5U=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    static String RSAPrivateKey = "<RSAKeyValue><Modulus>tsBjrD7cndJc2qhIi0g889KsAy3w/YH+35+k7QsHA23nS8sMwfLzYPjVqYXe+xzJyGr5iaBT58XSoDDTVMViaC/x7XqXlAQyLuHcwrRX2XbLatKXLXfk7glaBGsR/YTUgqDEFlFn6qtMdb8ho3xbw2VC93si6hlpwoYdYqqTu5U=</Modulus><Exponent>AQAB</Exponent><P>4emSFoB8RxRvLJMkIVqO7s1wjQ6sLvNDFzgFdMJ029lvtft1VJGXj9vxVUP/YjZhI+NO4rFAugaK5i1GZjPEqw==</P><Q>zxdCXJcapGaM+68oFlkTb5vU0KEswpnWNoPsDXfdzfsobGc5oUMONZf6+IqdMaZ2VOUez5gLzn/oycz4NdwAvw==</Q><DP>J/VwaZqAYPI0V+YO1fd2oLal2c1ml0df7pNyI5zhnqFvKPk5X6QA8uksXrCQU4ba18Y1BdPkZwMRPnVzplAx0Q==</DP><DQ>TAvcgKe0Tt6hsuKVM++t5XQx6BLnnuZi9U3oZuG3f6ZVJ8mYLhGzrBaNQKuWId9g4LfqYo0Q+NmboE82boDFfQ==</DQ><InverseQ>BBDtMUyFZO/s6y9VNtWZcRUBuH83YQ4q2NUbBlCZwlar4U4G/KOE2oAnwkT4nQ5HnvvyGaFyuS8G1T1/bJ6b7w==</InverseQ><D>MgSMAyudVDCsK0hduolF7XHelGwxhiDbMjdOe3ZGMCEXaf4j+r1U8ViJmgFC2zWw4IKu04UnEctp72ANpyjy2pypvjD4TbxC/8YeyYkppM6uphPN8KtoRJgpFoHV7TRNUM/QNuqwbu39iviSQdTGUCoEC8wGC4MJQ52GNqsmYO0=</D></RSAKeyValue>";


    private GestorDeEncriptacion()
    {

    }

    //SDC Modificar List por String como argumentos y retorno
    public static String DesencriptarAes(String informacionEncriptada)
    {
        string informacionDesencriptada = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(AESKEY);
            aesAlg.IV = Convert.FromBase64String(AESIV);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(informacionEncriptada)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        informacionDesencriptada = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return informacionDesencriptada;
    }


    //SDC Modificar List por String como argumentos y retorno
    public static String EncriptarAes(String informacionAEncriptar)
    {
        byte[] informacionEncriptada;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(AESKEY);
            aesAlg.IV = Convert.FromBase64String(AESIV);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(informacionAEncriptar);
                    }
                    informacionEncriptada = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(informacionEncriptada);
    }

    //SDC Cambiar List por String
    public static String EncriptarMD5(String informacion)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(informacion);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public static String DesencriptarRSA(String informacionEncriptada)
    {
        RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2028);
        rsaProvider.FromXmlString(RSAPrivateKey);
        byte[] decryptedData = rsaProvider.Decrypt(Convert.FromBase64String(informacionEncriptada), false);
        return Encoding.ASCII.GetString(decryptedData);
    }
}