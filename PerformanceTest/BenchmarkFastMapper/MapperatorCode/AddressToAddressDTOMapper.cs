//------------------------------------------------------------------------------
// <auto-generated>
//     Code generated by Mapperator. Go to http://mapperator.net for more information.
//     Version: 1.0.0-beta
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using BenchmarkFastMapper.Classes;
using Mapperator.Core;


namespace MapperProject.Mappers
{
    
    
    public class AddressToAddressDTOMapper : MapperBase<BenchmarkFastMapper.Classes.Address, BenchmarkFastMapper.Classes.AddressDTO>
    {
        
        private AddressToAddressDTOMapper()
        {
        }
        
        public static AddressToAddressDTOMapper Instance
        {
            get
            {
                return Nested.InstanceInNested;
            }
        }
        
        protected override void Map(BenchmarkFastMapper.Classes.Address source, ref BenchmarkFastMapper.Classes.AddressDTO target)
        {
            target.Id = source.Id;
            target.City = source.City;
            target.Country = source.Country;
        }
        
        private class Nested
        {
            
            internal static readonly AddressToAddressDTOMapper InstanceInNested = new AddressToAddressDTOMapper();
            
            static Nested()
            {
            }
        }
    }
}