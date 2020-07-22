// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;

namespace Cedita.Essence.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get a Description attribute's description value from an Enum Value.
        /// </summary>
        /// <param name="value">Enum Value.</param>
        /// <returns>Description for Enum Value.</returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var fieldInfo = value.GetType().GetField(value.ToString());
            return fieldInfo.GetDescription();
        }

        /// <summary>
        /// Get a DisplayName attribute's name value from an Enum Value.
        /// </summary>
        /// <param name="value">Enum Value.</param>
        /// <returns>Display Name for Enum Value.</returns>
        public static string GetDisplayName(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var fieldInfo = value.GetType().GetField(value.ToString());
            return fieldInfo.GetDisplayName();
        }

        /// <summary>
        /// Checks if the target enumeration includes the specified flag.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>
        /// <b>true</b> if match, otherwise <b>false</b>.
        /// </returns>
        /// <remarks>
        /// From http://www.codeproject.com/KB/cs/fun-with-cs-extensions.aspx.
        /// </remarks>
        public static bool Includes<TEnum>(this TEnum target, TEnum flags)
            where TEnum : IComparable, IConvertible, IFormattable
        {
            if (target.GetType() != flags.GetType())
            {
                throw new ArgumentException("Enum type mismatch", nameof(flags));
            }

            var a = Convert.ToInt64(target);
            var b = Convert.ToInt64(flags);
            return (a & b) == b;
        }

        /// <summary>
        /// Checks if the target enumeration includes any of the specified flags.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>
        /// <b>true</b> if match, otherwise <b>false</b>.
        /// </returns>
        /// <remarks>
        /// From http://www.codeproject.com/KB/cs/fun-with-cs-extensions.aspx.
        /// </remarks>
        public static bool IncludesAny<TEnum>(this TEnum target, TEnum flags)
            where TEnum : IComparable, IConvertible, IFormattable
        {
            if (target.GetType() != flags.GetType())
            {
                throw new ArgumentException("Enum type mismatch", nameof(flags));
            }

            var a = Convert.ToInt64(target);
            var b = Convert.ToInt64(flags);
            return (a & b) != 0L;
        }
    }
}
