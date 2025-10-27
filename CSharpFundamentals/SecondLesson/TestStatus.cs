/* 8) Identify enum TestCaseStatus {Pass, Fail, Blocked, WP, Unexecuted}.
Assign status “Pass” for variable test1Status and output result on the console.*/
using System;
using System.Globalization;
namespace Fundamentals.SecondLesson
{
    internal class TestStatus
    {
                private enum TestCaseStatus
        {
            Pass = 300,
            Fail,
            Blocked,
            WP,
            Unexecuted
        }
        public static void Run()
        {

        }
    }
}