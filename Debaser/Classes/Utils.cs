using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Debaser.Classes
{
    public static class Utils
    {
        public static bool IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}