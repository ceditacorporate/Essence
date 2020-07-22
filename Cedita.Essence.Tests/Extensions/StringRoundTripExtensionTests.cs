// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Security.Cryptography;
using Cedita.Essence.Extensions;
using Xunit;

namespace Cedita.Essence.Tests
{
    public class StringRoundTripExtensionTests
    {
        [Fact]
        public void RoundTripBase64Test()
        {
            var baseTest = "This is a string";
            var base64Test = "VGhpcyBpcyBhIHN0cmluZw==";

            Assert.Equal(base64Test, baseTest.EncodeBase64());
            Assert.Equal(baseTest, base64Test.DecodeBase64());
            Assert.Equal(baseTest, baseTest.EncodeBase64().DecodeBase64());
        }

        [Fact]
        public void RoundTripRsaTest()
        {
            var baseTest = "This is a string";
            var baseKey = "This is a key";
            var wrongKey = "This is a wrong key";

            Assert.Equal(baseTest, baseTest.RsaEncrypt(baseKey).RsaDecrypt(baseKey));
            Assert.Throws<CryptographicException>(() => baseTest.RsaEncrypt(baseKey).RsaDecrypt(wrongKey));
            Assert.Throws<CryptographicException>(() => baseTest.RsaEncrypt(wrongKey).RsaDecrypt(baseKey));
        }
    }
}
