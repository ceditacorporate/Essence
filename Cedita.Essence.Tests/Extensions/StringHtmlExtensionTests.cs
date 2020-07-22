// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Cedita.Essence.Extensions;
using Xunit;

namespace Cedita.Essence.Tests
{
    public class StringHtmlExtensionTests
    {
        [Theory]
        [InlineData("Test", 0)]
        [InlineData("Test\nTest", 1)]
        [InlineData("Test\r\nTest", 1)]
        [InlineData("Test\n\r\nTest", 2)]
        [InlineData("Test\n\n\r\nTest", 3)]
        public void Nl2BrTest(string input, int expectedOccurences)
        {
            Assert.Equal(expectedOccurences, input.Nl2Br().OccurencesOf("<br />"));
        }

        [Theory]
        [InlineData("Test", "Test")]
        [InlineData("<b>Test</b>", "Test")]
        [InlineData("<b>Test</b> More Content", "Test More Content")]
        [InlineData("<b>Test</b> More Content <p>Another Tag</p>", "Test More Content Another Tag")]
        [InlineData("<b>Test</b> More Content <p class=\"testing\">Another Tag</p>", "Test More Content Another Tag")]
        [InlineData("<b>Test</b> More Content <p class=\"testing\" onclick=\"testMethod('lol what')\">Another Tag</p>", "Test More Content Another Tag")]
        [InlineData("<b>Test</b> More Content <p class=\"testing\" onclick=\"testMethod(\"lol what\")\">Another Tag</p>", "Test More Content Another Tag")]
        public void StripHtmlTest(string input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, input.StripHtml());
        }
    }
}
