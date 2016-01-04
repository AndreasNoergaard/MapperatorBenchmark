using System;
using BenchmarkAutomapper;
using Mapperator.CodeGen;
using Mapperator.MapSpec;

namespace MapperatorGen
{
    class Program
    {
        #region Automappers benchmark code
        private static MappingConfiguration SetupFlatteningMapOneLayered()
        {
            var matcher = new SimpleMatcher();
            matcher.AddPossibleTargetSuffix("ProperName");
            MappingConfiguration config = new MappingConfiguration();
            var map1 = new MappingSpecification<Model1, Dto1>();
            var map2 = new MappingSpecification<Model2, Dto2>();
            var map3 = new MappingSpecification<Model3, Dto3>();
            var map4 = new MappingSpecification<Model4, Dto4>();
            var map5 = new MappingSpecification<Model5, Dto5>();
            var map6 = new MappingSpecification<Model6, Dto6>();
            var map7 = new MappingSpecification<Model7, Dto7>();
            var map8 = new MappingSpecification<Model8, Dto8>();
            var map9 = new MappingSpecification<Model9, Dto9>();
            var map10 = new MappingSpecification<Model10, Dto10>();
            var mapObject = new MappingSpecification<ModelObject, ModelDto>();
            map1.AddMapsBasedOnMatches(matcher);
            map2.AddMapsBasedOnMatches(matcher);
            map3.AddMapsBasedOnMatches(matcher);
            map4.AddMapsBasedOnMatches(matcher);
            map5.AddMapsBasedOnMatches(matcher);
            map6.AddMapsBasedOnMatches(matcher);
            map7.AddMapsBasedOnMatches(matcher);
            map8.AddMapsBasedOnMatches(matcher);
            map9.AddMapsBasedOnMatches(matcher);
            map10.AddMapsBasedOnMatches(matcher);
            mapObject.AddMap(source => source.BaseDate, target => target.BaseDate);
            mapObject.AddMap(source => source.Sub.ProperName, target => target.SubProperName);
            mapObject.AddMap(source => source.Sub2.ProperName, target => target.Sub2ProperName);
            mapObject.AddMap(source => source.SubWithExtraName.ProperName, target => target.SubWithExtraNameProperName);
            mapObject.AddMap(source => source.Sub.SubSub.IAmACoolProperty, target => target.SubSubSubIAmACoolProperty);
            config.AddMappingSpecification(map1);
            config.AddMappingSpecification(map2);
            config.AddMappingSpecification(map3);
            config.AddMappingSpecification(map4);
            config.AddMappingSpecification(map5);
            config.AddMappingSpecification(map6);
            config.AddMappingSpecification(map7);
            config.AddMappingSpecification(map8);
            config.AddMappingSpecification(map9);
            config.AddMappingSpecification(map10);
            config.AddMappingSpecification(mapObject);

            return config;
        }

        private static MappingConfiguration SetupFlatteningMapTwoLayered()
        {
            var matcher = new SimpleMatcher();
            matcher.AddPossibleTargetSuffix("ProperName");
            MappingConfiguration config = new MappingConfiguration();
            var map1 = new MappingSpecification<Model1, Dto1>();
            var map2 = new MappingSpecification<Model2, Dto2>();
            var map3 = new MappingSpecification<Model3, Dto3>();
            var map4 = new MappingSpecification<Model4, Dto4>();
            var map5 = new MappingSpecification<Model5, Dto5>();
            var map6 = new MappingSpecification<Model6, Dto6>();
            var map7 = new MappingSpecification<Model7, Dto7>();
            var map8 = new MappingSpecification<Model8, Dto8>();
            var map9 = new MappingSpecification<Model9, Dto9>();
            var map10 = new MappingSpecification<Model10, Dto10>();
            var mapObject = new MappingSpecification<ModelObject, ModelDto>();
            var mapSubObject = new MappingSpecification<ModelSubObject, String>();
            map1.AddMapsBasedOnMatches(matcher);
            map2.AddMapsBasedOnMatches(matcher);
            map3.AddMapsBasedOnMatches(matcher);
            map4.AddMapsBasedOnMatches(matcher);
            map5.AddMapsBasedOnMatches(matcher);
            map6.AddMapsBasedOnMatches(matcher);
            map7.AddMapsBasedOnMatches(matcher);
            map8.AddMapsBasedOnMatches(matcher);
            map9.AddMapsBasedOnMatches(matcher);
            map10.AddMapsBasedOnMatches(matcher);
            mapObject.AddMapsBasedOnMatches(matcher);
            mapSubObject.SetReverseDelegationMap(x => x.ProperName);
            mapObject.AddMap(source => source.Sub.SubSub.IAmACoolProperty, target => target.SubSubSubIAmACoolProperty);
            config.AddMappingSpecification(map1);
            config.AddMappingSpecification(map2);
            config.AddMappingSpecification(map3);
            config.AddMappingSpecification(map4);
            config.AddMappingSpecification(map5);
            config.AddMappingSpecification(map6);
            config.AddMappingSpecification(map7);
            config.AddMappingSpecification(map8);
            config.AddMappingSpecification(map9);
            config.AddMappingSpecification(map10);
            config.AddMappingSpecification(mapObject);
            config.AddMappingSpecification(mapSubObject);

            return config;
        }

        private static void GenerateAutomappersBenchmarkCode()
        {
            var config = SetupFlatteningMapOneLayered();
            //var config = SetupFlatteningMapTwoLayered();
            
            CheckConfigAndGenCode(config, "AutoMapper");
        }

        #endregion

        #region Fastmappers benchmark code
        private static void GenerateFastMappersBenchmarkCode()
        {
            MappingConfiguration config = new MappingConfiguration();

            var matcher = new SimpleMatcher();
            var customerSpec = new MappingSpecification<BenchmarkFastMapper.Classes.Customer, BenchmarkFastMapper.Classes.CustomerDTO>();
            customerSpec.AddMapsBasedOnMatches(matcher);
            customerSpec.AddMap(source => source.Address.City, target => target.AddressCity);

            var addressSpec = new MappingSpecification<BenchmarkFastMapper.Classes.Address, BenchmarkFastMapper.Classes.AddressDTO>();
            addressSpec.AddMapsBasedOnMatches(matcher);


            config.AddMappingSpecification(customerSpec);
            config.AddMappingSpecification(addressSpec);


            CheckConfigAndGenCode(config, "FastMapper");

        } 
        #endregion

        private static void CheckConfigAndGenCode(MappingConfiguration config, string pathSuffix, bool allPropertiesAndFieldsShouldBeMapped = true)
        {
            string missingMaps;
            var areAllMapsComplete = config.AreAllMapsComplete(out missingMaps, allPropertiesAndFieldsShouldBeMapped);
            Console.WriteLine("Is complete = " + areAllMapsComplete);
            if (!areAllMapsComplete)
            {
                Console.WriteLine("Missing maps = " + missingMaps);
            }
            else 
            {
                var solutionConfiguration = new SolutionConfiguration(@"C:\src\temp\Generated\"+pathSuffix, "temp");
                var codeGenerationConfiguration = new CodeGenerationConfiguration();
                codeGenerationConfiguration.AddNullChecksForNestedPropertiesAndFields = false;
                codeGenerationConfiguration.DefineAMethodForEachPropertyOrFieldBeingMappedByAMapper = false;
                SolutionGenerator.GenerateOnlyMappers(solutionConfiguration, config, codeGenerationConfiguration);
            }
        }

        static void Main(string[] args)
        {
            GenerateAutomappersBenchmarkCode();
            GenerateFastMappersBenchmarkCode();
        }
    }
}
