// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Text;

namespace Cedita.Essence.Extensions
{
    public static class StringHtmlExtensions
    {
        private enum AttributeMode
        {
            None,
            Single,
            Double,
        }

        /// <summary>
        /// Convert new line characters to HTML line breaks.
        /// </summary>
        /// <param name="str">String to work with.</param>
        /// <returns>String with New Lines converted to Line Breaks.</returns>
        public static string Nl2Br(this string str)
        {
            return str.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        /// <summary>
        /// Strip HTML tags from a string.
        /// </summary>
        /// <param name="str">String to work with.</param>
        /// <returns>String with HTML tags removed.</returns>
        public static string StripHtml(this string str)
        {
            var path = new StringBuilder(str);
            var sb = new StringBuilder();
            int pos = 0;
            while (pos < path.Length)
            {
                char ch = path[pos];
                pos++;

                if (ch == '<')
                {
                    var attributeMode = AttributeMode.None;
                    while (pos < path.Length)
                    {
                        ch = path[pos];
                        pos++;

                        if (attributeMode == AttributeMode.None && ch == '>')
                        {
                            break;
                        }
                        else if (attributeMode != AttributeMode.None)
                        {
                            if (ch == '\\')
                            {
                                pos++;
                            }
                            else if ((attributeMode == AttributeMode.Single && ch == '\'') || (attributeMode == AttributeMode.Double && ch == '"'))
                            {
                                attributeMode = AttributeMode.None;
                            }
                        }
                        else
                        {
                            if (ch == '\'')
                            {
                                attributeMode = AttributeMode.Single;
                            }
                            else if (ch == '"')
                            {
                                attributeMode = AttributeMode.Double;
                            }
                        }
                    }
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }
    }
}
