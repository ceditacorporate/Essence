// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Text.RegularExpressions;

namespace Cedita.Essence.Extensions
{
    public static class RssParserExtensions
    {
        public static string GetImage(this string item)
        {
            var rv = string.Empty;

            var regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?.(?:jpg|bmp|gif|png)", 
                RegexOptions.IgnoreCase);
            var matches = regx.Matches(item);
            if (matches.Count != 0)
            {
                rv = matches[0].Value;
            }

            return rv;
        }
    }
}
