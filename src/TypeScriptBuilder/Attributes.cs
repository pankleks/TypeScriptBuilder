using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypeScriptBuilder
{
    public class TSExclude : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class TSAny : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct), Obsolete("experimental")]
    public class TSClass : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property), Obsolete("experimental")]
    public class TSInitialize : Attribute
    {
        public readonly string Body;
        public TSInitialize(string body)
        {
            Body = body;
        }
    }

    public class TSMap : Attribute
    {
        public readonly string Name;
        public TSMap(string name)
        {
            Name = name;
        }
    }
}
