/* 8) Identify enum TestCaseStatus {Pass, Fail, Blocked, WP, Unexecuted}.
Assign status “Pass” for variable test1Status and output result on the console.*/
namespace Fundamentals.SecondLesson
{
    internal class TestStatus
    {
        private enum TestCaseStatus
        {
            Pass,
            Fail,
            Blocked,
            WP,
            Unexecuted
        }
        public static void Run()
        {
            TestCaseStatus test1Status = TestCaseStatus.Pass;

            Console.WriteLine("🧪 Test case #1 result:");
            Console.WriteLine($"Status: {test1Status}");
        }
    }
}