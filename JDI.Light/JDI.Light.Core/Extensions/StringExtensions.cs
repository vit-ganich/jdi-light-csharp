﻿using System;
using System.Text.RegularExpressions;

namespace JDI.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comparison)
        {
            return source.IndexOf(toCheck, comparison) >= 0;
        }

        public static bool Matches(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}