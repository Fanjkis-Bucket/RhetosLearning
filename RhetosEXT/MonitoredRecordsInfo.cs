using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace BookStore.Service.RhetosEXT
{

    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecords")]
    public class MonitoredRecordsInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; } 
   
    }

}
