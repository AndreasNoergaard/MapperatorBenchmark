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
    
    
    public class Model6ToDto6Mapper : MapperBase<Model6, Dto6>
    {
        
        private Model6ToDto6Mapper()
        {
        }
        
        public static Model6ToDto6Mapper Instance
        {
            get
            {
                return Nested.InstanceInNested;
            }
        }
        
        protected override void Map(Model6 source, ref Dto6 target)
        {
            target.Value = source.Value;
        }
        
        private class Nested
        {
            
            internal static readonly Model6ToDto6Mapper InstanceInNested = new Model6ToDto6Mapper();
            
            static Nested()
            {
            }
        }
    }
}