using System;

namespace H5
{
    public class ReadyAttribute : AdapterAttribute
    {
        public const string Format = "H5.ready(this.{2});";
        public const string FormatScope = "H5.ready(this.{2}, this);";
        public const string Event = "ready";
        public const bool StaticOnly = true;

        public ReadyAttribute()
        {
        }
    }
}
