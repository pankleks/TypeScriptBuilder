var TestA;
(function (TestA) {
    (function (EmployeeType) {
        EmployeeType[EmployeeType["Normal"] = 1] = "Normal";
        EmployeeType[EmployeeType["Temporary"] = 2] = "Temporary";
    })(TestA.EmployeeType || (TestA.EmployeeType = {}));
    var EmployeeType = TestA.EmployeeType;
})(TestA || (TestA = {}));
var TestB;
(function (TestB) {
    var Strange = (function () {
        function Strange() {
            this.test = {};
        }
        return Strange;
    }());
    TestB.Strange = Strange;
})(TestB || (TestB = {}));
