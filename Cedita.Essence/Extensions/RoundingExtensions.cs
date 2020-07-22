// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;

namespace Cedita.Essence.Extensions
{
    public static class RoundingExtensions
    {
        public static int RoundValueToNext(this double value, int up) => (int)(Math.Ceiling(value / up) * up);
    }
}
