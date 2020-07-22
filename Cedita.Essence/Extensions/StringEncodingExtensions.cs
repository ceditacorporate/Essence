// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Text;

namespace Cedita.Essence.Extensions
{
    public static class StringEncodingExtensions
    {
        /// <summary>
        /// Encode the string to Base 64.
        /// </summary>
        /// <param name="str">String to work with.</param>
        /// <returns>Encoded string as Base64.</returns>
        public static string EncodeBase64(this string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        /// Decode the string from Base 64.
        /// </summary>
        /// <param name="str">Base64 Encoded String to work with.</param>
        /// <returns>Decoded string from Base64.</returns>
        public static string DecodeBase64(this string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
