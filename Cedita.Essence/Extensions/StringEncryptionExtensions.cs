// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Cedita.Essence.Extensions
{
    public static class StringEncryptionExtensions
    {
        /// <summary>
        /// Encrypt the string with RSA using <paramref name="key"/>.
        /// </summary>
        /// <param name="str">String to work with.</param>
        /// <param name="key">Encryption Key.</param>
        /// <returns>Encypted string with RSA.</returns>
        public static string RsaEncrypt(this string str, string key)
        {
            var cspp = new CspParameters
            {
                KeyContainerName = key,
            };
            var rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true,
            };
            var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(str), true);
            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// Encrypt the string with RSA using <paramref name="key"/>.
        /// </summary>
        /// <param name="str">RSA Encrypted String to work with.</param>
        /// <param name="key">Encryption Key.</param>
        /// <returns>Decrypted string with RSA.</returns>
        public static string RsaDecrypt(this string str, string key)
        {
            var cspp = new CspParameters
            {
                KeyContainerName = key,
            };
            var rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true,
            };
            var decryptArray = str.Split(new[] { "-" }, StringSplitOptions.None);
            var decryptByteArray = Array.ConvertAll(decryptArray, s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber)));
            var bytes = rsa.Decrypt(decryptByteArray, true);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
