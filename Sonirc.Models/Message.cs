using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonirc.Models
{
    public class Message : IEquatable<Message>
    {
        public IReadOnlyCollection<Tag> Tags { get; set; }
        public string Source { get; set; }
        public string Verb { get; set; }
        public IReadOnlyCollection<string> Parameters { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Message);
        }

        public bool Equals(Message other)
        {
            return other != null &&
                   Tags.NullRespectingSequenceEqual(other.Tags) &&
                   Source == other.Source &&
                   Verb == other.Verb &&
                   Parameters.NullRespectingSequenceEqual(other.Parameters);
        }

        public override int GetHashCode()
        {
            var hashCode = 333461972;
            hashCode = hashCode * -1521134295 + EqualityComparer<IReadOnlyCollection<Tag>>.Default.GetHashCode(Tags);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Verb);
            hashCode = hashCode * -1521134295 + EqualityComparer<IReadOnlyCollection<string>>.Default.GetHashCode(Parameters);
            return hashCode;
        }
    }
}
