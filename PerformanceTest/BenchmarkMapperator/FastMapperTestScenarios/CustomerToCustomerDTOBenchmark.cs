using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;
using BenchmarkFastMapper;
using BenchmarkFastMapper.Classes;
using FastMapper;
using MapperProject.Mappers;

namespace BenchmarkMapperator.FastMapperTestScenarios
{
    [BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.RyuJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    [BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class CustomerToCustomerDTOBenchmark
    {
        [Params(1)]
        public int DataSetSize;

        private List<Customer> _valuesToMap;

        [Setup]
        public void Setup()
        {
            _valuesToMap = GetSource(DataSetSize);
            InitializeAutomapper();
        }

        private void InitializeAutomapper()
        {
            Mapper.CreateMap<Address, Address>();
            Mapper.CreateMap<Address, AddressDTO>();
            Mapper.CreateMap<Customer, CustomerDTO>();
        }

        private List<Customer> GetSource(int dataSetSize)
        {
            var result = new List<Customer>();

            for (var i = 0; i < dataSetSize; i++)
            {
                result.Add(new Customer()
                {
                    Address = new Address() { City = "istanbul", Country = "turkey", Id = 1, Street = "istiklal cad." },
                    HomeAddress = new Address() { City = "istanbul", Country = "turkey", Id = 2, Street = "istiklal cad." },
                    Id = 1,
                    Name = "Kıvanç",
                    Credit = 234.7m,
                    WorkAddresses = new List<Address>() { 
                    new Address() { City = "istanbul", Country = "turkey", Id = 5, Street = "istiklal cad." },
                    new Address() { City = "izmir", Country = "turkey", Id = 6, Street = "konak" }
                },
                    Addresses = new List<Address>() { 
                    new Address() { City = "istanbul", Country = "turkey", Id = 3, Street = "istiklal cad." },
                    new Address() { City = "izmir", Country = "turkey", Id = 4, Street = "konak" }
                }.ToArray()
                }
                     );
            }
            return result;
        }

        [Benchmark]
        public void NativeBenchmark()
        {
            _valuesToMap.Select(Program.MapCustomerNative).ToList();
        }

        [Benchmark]
        public void MapperatorBenchmark()
        {
            _valuesToMap.Select(CustomerToCustomerDTOMapper.Instance.Map).ToList();

        }

        [Benchmark]
        public void FastMapperBenchmark()
        {
            _valuesToMap.Select(TypeAdapter.Adapt<Customer, CustomerDTO>).ToList();

        }
    }
}
