using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypeScriptBuilder
{
    public class TypeScriptGeneratorOptions
    {
        public bool UseCamelCase = true;    // changes fields names: TestField1 -> testField1
        public bool AddIinInterface = true; // use I in interface names: MyData -> IMyData
        public bool EmitReadonly = true;    // emits readonly for readonly fields (need TypeScript 2.0)
    }
}
