//------------------------------------------------------------------------------
// <auto-generated>
//     Code generated by Mapperator. Go to http://mapperator.net for more information.
//     Version: 1.0.0-beta
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mapperator.Core;

namespace BenchmarkAutomapper.MapperatorMapsOneLayered
{
    
    
    public class Model1ToDto1Mapper : MapperBase<Model1, Dto1>
    {
        
        private Model1ToDto1Mapper()
        {
        }
        
        public static Model1ToDto1Mapper Instance
        {
            get
            {
                return Nested.InstanceInNested;
            }
        }
        
        protected override void Map(Model1 source, ref Dto1 target)
        {
            target.Value = source.Value;
        }
        
        private class Nested
        {
            
            internal static readonly Model1ToDto1Mapper InstanceInNested = new Model1ToDto1Mapper();
            
            static Nested()
            {
            }
        }
    }
}
