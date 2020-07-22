// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Cedita.Essence.Extensions
{
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Get a visible name from a FieldInfo's <see cref="DisplayAttribute"/> attribute, or the field's name if not present.
        /// </summary>
        /// <param name="memberInfo">FieldInfo instance.</param>
        /// <returns>Name from DisplayAttribute, or field name if no attribute.</returns>
        public static string GetDescription(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            var attr = memberInfo.GetCustomAttribute<DescriptionAttribute>(false);
            if (attr != null)
            {
                var name = attr.Description;
                if (!name.IsNullOrEmpty())
                {
                    return name;
                }
            }

            return memberInfo.Name;
        }

        /// <summary>
        /// Get a visible name from a FieldInfo's <see cref="DisplayAttribute"/> attribute, or the field's name if not present.
        /// </summary>
        /// <param name="memberInfo">FieldInfo instance.</param>
        /// <returns>Name from DisplayAttribute, or field name if no attribute.</returns>
        public static string GetDisplayName(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            var attr = memberInfo.GetCustomAttribute<DisplayAttribute>(false);
            if (attr != null)
            {
                var name = attr.GetName();
                if (!name.IsNullOrEmpty())
                {
                    return name;
                }
            }

            return memberInfo.Name;
        }
    }
}
