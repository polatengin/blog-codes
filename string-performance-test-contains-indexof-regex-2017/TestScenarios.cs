using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StringPerformanceTest
{
    public class TestScenarios
    {
        private string TestString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur scelerisque libero eros, et efficitur mi laoreet ac";

        private int TestIterationCount = 10_000_000;

        private void TestAndPrint(Action Test, string testName)
        {
            var watch = new Stopwatch();

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForFullGCComplete();

            watch.Restart();

            Test();

            Console.WriteLine($"{testName} testi {watch.ElapsedMilliseconds / 10D} ms. sürdü");
        }

        public void InvokeTests()
        {
            TestAndPrint(() => { StringIndexOfTest("dolor"); }, nameof(StringIndexOfTest) + "-NoMatch");

            TestAndPrint(() => { StringIndexOfTest("engin"); }, nameof(StringIndexOfTest) + "-Match");

            TestAndPrint(() => { StringContainsTest("dolor"); }, nameof(StringContainsTest) + "-NoMatch");

            TestAndPrint(() => { StringContainsTest("engin"); }, nameof(StringContainsTest) + "-Match");

            TestAndPrint(() => { RegexIsMatchTest("dolor"); }, nameof(RegexIsMatchTest) + "-NoMatch");

            TestAndPrint(() => { RegexIsMatchTest("engin"); }, nameof(RegexIsMatchTest) + "-Match");

            TestAndPrint(() => { RegexIsMatchCompiledTest("dolor"); }, nameof(RegexIsMatchCompiledTest) + "-NoMatch");

            TestAndPrint(() => { RegexIsMatchCompiledTest("engin"); }, nameof(RegexIsMatchCompiledTest) + "-Match");
        }

        private void RegexIsMatchCompiledTest(string comparedTo)
        {
            for(var iLoop = 0; iLoop < this.TestIterationCount; iLoop++)
            {
                Regex.IsMatch(TestString, comparedTo, RegexOptions.Compiled);
            }
        }

        private void RegexIsMatchTest(string comparedTo)
        {
            for(var iLoop = 0; iLoop < this.TestIterationCount; iLoop++)
            {
                Regex.IsMatch(TestString, comparedTo);
            }
        }

        private void StringIndexOfTest(string comparedTo)
        {
            for(var iLoop = 0; iLoop < this.TestIterationCount; iLoop++)
            {
                TestString.IndexOf(comparedTo);
            }
        }

        private void StringContainsTest(string comparedTo)
        {
            for(var iLoop = 0; iLoop < this.TestIterationCount; iLoop++)
            {
                TestString.Contains(comparedTo);
            }
        }
    }
}