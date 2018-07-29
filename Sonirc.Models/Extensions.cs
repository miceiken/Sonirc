using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonirc.Models
{
    public static class Extensions
    {
        public static bool NullRespectingSequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return first == null && second == null ? true
                 : first == null || second == null ? false
                 : first.SequenceEqual(second);
        }
    }
}
