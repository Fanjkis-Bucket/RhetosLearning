using Rhetos.Compiler;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Dsl;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace BookStore.Service.RhetosEXT
{
    [Export(typeof(IConceptMacro))]
    public class MonitoredRecordsMacro : IConceptMacro<MonitoredRecordsInfo>
    {

        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordsInfo conceptInfo, IDslModel existingConcepts)
        {

            var concepts = new List<IConceptInfo>();

            //if (conceptInfo.Entity is IWritableOrmDataStructure)
            //{
            //    concepts.Add
            //    (
            //        new AllPropertiesLoggingInfo()
            //    );
            //    concepts.Add
            //    (
            //       new EntityLoggingInfo { Entity = conceptInfo.Entity }
            //    );
            //    //concepts.Add
            //    //(
            //    //   new DenyUserEditPropertyInfo { Property = conceptInfo.Entity. }

            //    //);
            //    concepts.Add
            //    (
            //        new DateTimePropertyInfo { Name = "CreatedAt", DataStructure = conceptInfo.Entity }
            //    );
            //    //concepts.Add
            //    //(

            //    //    new CreationTimeInfo { Property = conceptInfo.Entity }
            //    //);
            //}


            return concepts;
        }
    }
}
