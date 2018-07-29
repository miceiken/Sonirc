using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Models
{
    public class Message : IEquatable<Message>
    {
        public IEnumerable<Tag> Tags { get; set; }
        public User Prefix { get; set; }
        public string Command { get; set; }
        public IEnumerable<string> Parameters { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Message);
        }

        public bool Equals(Message other)
        {
            return other != null &&
                   EqualityComparer<IEnumerable<Tag>>.Default.Equals(Tags, other.Tags) &&
                   EqualityComparer<User>.Default.Equals(Prefix, other.Prefix) &&
                   Command == other.Command &&
                   EqualityComparer<IEnumerable<string>>.Default.Equals(Parameters, other.Parameters);
        }

        public override int GetHashCode()
        {
            var hashCode = 333461972;
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Tag>>.Default.GetHashCode(Tags);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(Prefix);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Command);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<string>>.Default.GetHashCode(Parameters);
            return hashCode;
        }
    }
}
