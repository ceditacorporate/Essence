// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections;

namespace Cedita.Essence.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="BitArray"/> objects.
    /// </summary>
    public static class BitArrayExtensions
    {
        /// <summary>
        /// Finds the index for a given match function.
        /// </summary>
        /// <param name="gateArray">The gate array.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index of the first found value; else -1.</returns>
        public static int FindIndex(this BitArray gateArray, Predicate<bool> match)
        {
            var foundIndex = -1;
            for (int i = 0; i < gateArray.Count; i++)
            {
                if (match(gateArray[i]))
                {
                    foundIndex = i;
                    break;
                }
            }

            return foundIndex;
        }

        /// <summary>
        /// Finds the index for a given match function.
        /// </summary>
        /// <param name="gateArray">The gate array.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index of the first found value; else -1.</returns>
        public static int FindIndex(this BitArray gateArray, int startIndex, Predicate<bool> match)
        {
            var foundIndex = -1;
            for (int i = startIndex; i < gateArray.Count; i++)
            {
                if (match(gateArray[i]))
                {
                    foundIndex = i;
                    break;
                }
            }

            return foundIndex;
        }
    }
}
