using System;
using System.Collections.Generic;
using System.IO;
using TypeScriptBuilder;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var
                builder = new TypeScriptGenerator().ExcludeType(typeof(Program));

            builder.AddCSType(typeof(TestA.Employee));
            builder.AddCSType(typeof(TestB.Strange<>));

            builder.Store("Test.ts");
        }
    }
}

namespace TestA
{
    public enum EmployeeType
    {
        Normal = 1,
        Temporary = 2
    }

    [TSMap("Funky")]
    public class Entity<T>
    {
        public T Id;

        public TestB.Pair<int, Entity<int>> Map1;
        public TestB.Pair<string, Entity<string>> Map2;

        [TSAny]
        public DateTimeOffset TestAny;
    }

    public class Employee : Entity<int>
    {
        public string Login;
        public EmployeeType? EmployeeType;

        public string[] ArrayTest;
        public List<DateTime> ListTest;

        public Dictionary<int, DateTime> DictIntTest;
        public Dictionary<string, DateTime> DictStringTest;

        public ICollection<Entity<DateTime>> CollectionTest;

        // exclude
        [TSAny]
        public Skip Skip;
        [TSExclude]
        public int Skip2;
    }

    [TSExclude]
    public class Skip
    {
    }
}

namespace TestB
{
    public class Pair<T1, T2>
    {
        public T1 t1;
        public T2 t2;

        public int TestProperty { get; set; }

        void Test([TSAny]int n)
        {
        }
    }

    [TSClass]
    public class Strange<T>
    {
        [TSInitialize("{}")]
        public readonly Dictionary<int, TestA.Entity<T>> Test;
    }
}