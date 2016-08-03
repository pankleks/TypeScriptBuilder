namespace TestA
{
	export interface IFunky<T>
	{
		id: T;
		map1: TestB.IPair<number, IFunky<number>>;
		map2: TestB.IPair<string, IFunky<string>>;
		testAny: any;
	}
	export interface IEmployee extends IFunky<number>
	{
		login: string;
		employeeType?: EmployeeType;
		arrayTest: string[];
		listTest: Date[];
		dictIntTest: { [index: number]: Date };
		dictStringTest: { [index: string]: Date };
		collectionTest: IFunky<Date>[];
		skip: any;
		id: number;
		map1: TestB.IPair<number, IFunky<number>>;
		map2: TestB.IPair<string, IFunky<string>>;
		testAny: any;
	}
	export enum EmployeeType
	{
		Normal = 1,
		Temporary = 2,
	}
}
namespace TestB
{
	export class Strange<T>
	{
		readonly test: { [index: number]: TestA.IFunky<T> } = {};
	}
	export interface IPair<T1, T2>
	{
		t1: T1;
		t2: T2;
		testProperty: number;
	}
}
