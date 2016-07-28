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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct), Obsolete("experimental, known issues")]
    public class TSClass : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TSInitialize : Attribute
    {
        public readonly string Body;
        public TSInitialize(string body)
        {
            Body = body;
        }
    }
}
