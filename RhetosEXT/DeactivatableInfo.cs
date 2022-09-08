using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace BookStore.Service.RhetosEXT
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("DeactivateOnDelete")]
    public class DeactivateOnDeleteInfo : IConceptInfo
    {
        [ConceptKey]
        public DeactivatableInfo Deactivatable { get; set; }
    }
}