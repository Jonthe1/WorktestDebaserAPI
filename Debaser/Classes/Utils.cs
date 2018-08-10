using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Debaser.Classes
{
    public static class Utils
    {
        public static bool IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }

        public static string ReplaceHTMLMarkup(string input)
        {
            var newString = Regex.Replace(input, @"<[^>]+>|&nbsp;", " ");
            return newString;
        }

        public static string ReplaceSpecialCharacters(string input)
        {
            var newString = Regex.Replace(input, "[^a-zA-Z.]+", " ");
            return newString;
        }


    }
}