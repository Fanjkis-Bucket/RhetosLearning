using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System;
using System.ComponentModel.Composition;

namespace BookStore.Service.Concepts
{

    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecords")]

    public class MonitoredRecordsInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }  
    }


    [Export(typeof(IConceptMacro))]
    public class MonitoredRecordsMacro : IConceptMacro<MonitoredRecordsInfo>
    {

        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordsInfo conceptInfo, IDslModel existingConcepts) 
        {

            var concepts = new List<IConceptInfo>();

            concepts.Add
            (
                new AllPropertiesLoggingInfo()
            );

            concepts.Add
            (
                new DateTimePropertyInfo()
            ) ;


            return concepts;
        }
    }
    
}
