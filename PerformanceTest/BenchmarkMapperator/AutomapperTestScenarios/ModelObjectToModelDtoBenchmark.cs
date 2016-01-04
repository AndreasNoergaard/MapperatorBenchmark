using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BenchmarkAutomapper;
using BenchmarkAutomapper.MapperatorMapsOneLayered;
using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;

namespace BenchmarkMapperator.AutomapperTestScenarios
{
    [BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.RyuJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class ModelObjectToModelDtoBenchmark
    {
        [Params(1)]
        public int DataSetSize;

        private List<ModelObject> _valuesToMap;

        [Setup]
        public void Setup()
        {
            _valuesToMap = GetSource(DataSetSize);
            InitializeAutomapper();
        }

        private static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Model1, Dto1>();
				cfg.CreateMap<Model2, Dto2>();
				cfg.CreateMap<Model3, Dto3>();
				cfg.CreateMap<Model4, Dto4>();
				cfg.CreateMap<Model5, Dto5>();
				cfg.CreateMap<Model6, Dto6>();
				cfg.CreateMap<Model7, Dto7>();
				cfg.CreateMap<Model8, Dto8>();
				cfg.CreateMap<Model9, Dto9>();
				cfg.CreateMap<Model10, Dto10>();
				cfg.CreateMap<ModelObject, ModelDto>();
			});
			Mapper.AssertConfigurationIsValid();
		}
        

        private List<ModelObject> GetSource(int dataSetSize)
        {
            var result = new List<ModelObject>();

            for (var i = 0; i < dataSetSize; i++)
            {
                result.Add(
                     new ModelObject
                     {
                         BaseDate = new DateTime(2007, 4, 5),
                         Sub = new ModelSubObject
                         {
                             ProperName = "Some name",
                             SubSub = new ModelSubSubObject
                             {
                                 IAmACoolProperty = "Cool daddy-o"
                             }
                         },
                         Sub2 = new ModelSubObject
                         {
                             ProperName = "Sub 2 name"
                         },
                         SubWithExtraName = new ModelSubObject
                         {
                             ProperName = "Some other name"
                         },
                     });
            }
            return result;
        }

        [Benchmark]
        public void NativeBenchmark()
        {
            _valuesToMap.Select(ManualFlatteningMapper.MapHelper).ToList();
        }

        [Benchmark]
        public void MapperatorBenchmark()
        {
            _valuesToMap.Select(ModelObjectToModelDtoMapper.Instance.Map).ToList();

        }

        [Benchmark]
        public void AutomapperBenchmark()
        {
            _valuesToMap.Select(Mapper.Map<ModelObject, ModelDto>).ToList();

        }
    }
}
