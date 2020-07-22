// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;

namespace Cedita.Essence.Extensions
{
    public static class DoubleExtensions
    {
        public static double Clamp(this double self, double min, double max) => Math.Min(max, Math.Max(self, min));
    }
}
