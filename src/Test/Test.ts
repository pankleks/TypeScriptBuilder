namespace TestA
{
	export interface IEntity<T>
	{
		id: T;
		map1: TestB.IPair<number, IEntity<number>>;
		map2: TestB.IPair<string, IEntity<string>>;
		testAny: any;
	}
	export interface IEmployee extends IEntity<number>
	{
		login: string;
		employeeType?: EmployeeType;
		arrayTest: string[];
		listTest: Date[];
		dictIntTest: { [index: number]: Date };
		dictStringTest: { [index: string]: Date };
		collectionTest: IEntity<Date>[];
		skip: any;
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
		test: { [index: number]: TestA.IEntity<T> };
	}
	export interface IPair<T1, T2>
	{
		t1: T1;
		t2: T2;
		testProperty: number;
	}
}
