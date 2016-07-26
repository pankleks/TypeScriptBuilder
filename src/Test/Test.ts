namespace TestA {
    export interface Entity<T> {
        id: T;
        map1: TestB.Pair<number, Entity<number>>;
        map2: TestB.Pair<string, Entity<string>>;
        testAny: any;
    }
    export interface Employee extends Entity<number> {
        login: string;
        employeeType?: EmployeeType;
        arrayTest: string[];
        listTest: Date[];
        dictIntTest: { [index: number]: Date };
        dictStringTest: { [index: string]: Date };
        collectionTest: Entity<Date>[];
        skip: any;
    }
    export enum EmployeeType {
        Normal = 1,
        Temporary = 2,
    }

}
namespace TestB {
    export interface Strange<T> {
        test: { [index: number]: TestA.Entity<T> };
    }
    export interface Pair<T1, T2> {
        t1: T1;
        t2: T2;
        testProperty: number;
    }

}
