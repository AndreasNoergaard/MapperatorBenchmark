using System;
using BenchmarkDotNet;
using AM = BenchmarkMapperator.AutomapperTestScenarios;
using FM = BenchmarkMapperator.FastMapperTestScenarios;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(200, 10000);
            RunMapperatorsBenchmarkSelector(args);
            //RunAllMapperatorsBenchmarks();
        }

        private static void RunMapperatorsBenchmarkSelector(string[] args)
        {
            var competitionSwitch = new BenchmarkCompetitionSwitch(new[]
            {
                typeof(AM.ModelObjectToModelDtoBenchmark),
                typeof(FM.CustomerToCustomerDTOBenchmark),
            });
            competitionSwitch.Run(args);
            Console.ReadLine();
        }

        private static void RunAllMapperatorsBenchmarks()
        {
            new BenchmarkRunner().RunCompetition(new AM.ModelObjectToModelDtoBenchmark());
            new BenchmarkRunner().RunCompetition(new FM.CustomerToCustomerDTOBenchmark());
        }
    }
}
