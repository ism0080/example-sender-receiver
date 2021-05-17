namespace Example.SenderReceiver.TaskHandlers.Common
{
    /// <summary>
    ///     A convenience class for passing around custom properties as a KeyValue pair
    /// </summary>
    public class KeyValuePair
    {
        public KeyValuePair()
        {
        }

        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public bool Equals(KeyValuePair other)
        {
            return other != null &&
                   Key == other.Key &&
                   Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is KeyValuePair)) return false;
            var other = obj as KeyValuePair;
            return Equals(other);
        }

        public static bool operator ==(KeyValuePair a1, KeyValuePair a2)
        {
            if (ReferenceEquals(a1, a2)) return true;
            if (a1 is null) return false;
            if (a2 is null) return false;

            return a1.Equals(a2);
        }

        public static bool operator !=(KeyValuePair a1, KeyValuePair a2)
        {
            if (ReferenceEquals(a1, a2)) return false;
            if (a1 is null) return true;
            if (a2 is null) return true;

            return !a1.Equals(a2);
        }

        public override int GetHashCode()
        {
            return (string.IsNullOrEmpty(Key) ? 0 : Key.GetHashCode()) ^
                   (string.IsNullOrEmpty(Value) ? 0 : Value.GetHashCode());
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
