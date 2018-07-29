using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Models
{
    public class Tag : IEquatable<Tag>
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tag);
        }

        public bool Equals(Tag other)
        {
            return other != null &&
                   Key == other.Key &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = 206514262;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }
    }
}
