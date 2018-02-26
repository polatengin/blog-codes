using System;

namespace StringPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test başlıyor!");

            var scenarios = new TestScenarios();
            scenarios.InvokeTests();

            Console.WriteLine("Test tamamlandı!");

            Console.ReadLine();
        }
    }
}
