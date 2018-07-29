using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Models
{
    public class User : IEquatable<User>
    {
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Host { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Nickname == other.Nickname &&
                   Username == other.Username &&
                   Host == other.Host;
        }

        public override int GetHashCode()
        {
            var hashCode = 54785165;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nickname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Host);
            return hashCode;
        }
    }
}
