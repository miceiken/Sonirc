using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Models
{
    public class Fullhost : IEquatable<Fullhost>
    {
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Hostname { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Fullhost);
        }

        public bool Equals(Fullhost other)
        {
            return other != null &&
                    Nickname == other.Nickname &&
                    Username == other.Username &&
                    Hostname == other.Hostname;
        }

        public override int GetHashCode()
        {
            var hashCode = 54785165;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nickname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Hostname);
            return hashCode;
        }
    }
}
