namespace TestA
{
	export interface IFunkyEntity<T>
	{
		id: T;
		map1: TestB.IPair<number, IFunkyEntity<number>>;
		map2: TestB.IPair<string, IFunkyEntity<string>>;
		testAny: any;
	}
	export interface IEquipment
	{
		code: number;
		objectDictionary: {};
		id: number;
		map1: TestB.IPair<number, IFunkyEntity<number>>;
		map2: TestB.IPair<string, IFunkyEntity<string>>;
		testAny: any;
	}
	export interface IEmployee extends IFunkyEntity<number>
	{
		login: string;
		employeeType?: UserType;
		arrayTest: string[];
		listTest: Date[];
		dictIntTest: { [index: number]: Date };
		dictStringTest: { [index: string]: Date };
		collectionTest: IFunkyEntity<Date>[];
		createdBy: IStamp;
		skip: any;
	}
	export interface IStamp
	{
		userId: number;
		user: string;
	}
	export enum UserType
	{
		Normal = 1,
		Temporary = 2,
	}
}
namespace TestB
{
	export class Strange<T>
	{
		readonly test: { [index: number]: TestA.IFunkyEntity<T> } = {};
	}
	export interface IPair<T1, T2>
	{
		t1: T1;
		t2: T2;
		testProperty: number;
	}
}
