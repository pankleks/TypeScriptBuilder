namespace TestA
{
	// TestA.Entity`1[T]
	export interface IFunkyEntity<T>
	{
		// T
		id: T;
		// TestB.Pair`2[System.Int32,TestA.Entity`1[System.Int32]]
		map1: TestB.IPair<number, IFunkyEntity<number>>;
		// TestB.Pair`2[System.String,TestA.Entity`1[System.String]]
		map2: TestB.IPair<string, IFunkyEntity<string>>;
		// System.DateTimeOffset
		testAny: any;
	}
	// TestA.Equipment
	export interface IEquipment
	{
		// System.Int32
		code: number;
		// System.Collections.Generic.Dictionary`2[System.Double,System.String]
		objectDictionary: {};
		// System.Int16
		id: number;
		// TestB.Pair`2[System.Int32,TestA.Entity`1[System.Int32]]
		map1: TestB.IPair<number, IFunkyEntity<number>>;
		// TestB.Pair`2[System.String,TestA.Entity`1[System.String]]
		map2: TestB.IPair<string, IFunkyEntity<string>>;
		// System.DateTimeOffset
		testAny: any;
	}
	// TestA.Employee
	export interface IEmployee extends IFunkyEntity<number>
	{
		// System.String
		login: string;
		// System.Nullable`1[TestA.EmployeeType]
		employeeType?: UserType;
		// System.String[]
		arrayTest: string[];
		// System.Collections.Generic.List`1[System.DateTime]
		listTest: Date[];
		// System.Collections.Generic.Dictionary`2[System.Int32,System.DateTime]
		dictIntTest: { [index: number]: Date };
		// System.Collections.Generic.Dictionary`2[System.String,System.DateTime]
		dictStringTest: { [index: string]: Date };
		// System.Collections.Generic.ICollection`1[TestA.Entity`1[System.DateTime]]
		collectionTest: IFunkyEntity<Date>[];
		// TestA.Stamp
		createdBy: IStamp;
		// TestA.Skip
		skip: any;
	}
	// TestA.Stamp
	export interface IStamp
	{
		// System.Int16
		userId: number;
		// System.String
		user: string;
	}
	// TestA.EmployeeType
	export enum UserType
	{
		Normal = 1,
		Temporary = 2,
	}
}
namespace TestB
{
	// TestB.Strange`1[T]
	export class Strange<T>
	{
		// System.Collections.Generic.Dictionary`2[System.Int32,TestA.Entity`1[T]]
		readonly test: { [index: number]: TestA.IFunkyEntity<T> } = {};
	}
	// TestB.Pair`2[T1,T2]
	export interface IPair<T1, T2>
	{
		// T1
		t1: T1;
		// T2
		t2: T2;
		// System.Int32
		testProperty: number;
	}
}
