using System;
using System.ComponentModel;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Extensibility.Predicates;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    [DisplayName("Dummy Predicate")]
    [Description("A dummy predicate that will always return the specified boolean value.")]
    public sealed class DummyPredicate : PredicateBase
    {
        [Persistent]
        [Category("Evaluate Value")]
        [DisplayName("Evaluate Value")]
        [Description("Check the box to have this predicate always evaluate to true.")]
        public bool EvaluateValue { get; set; }

        public override bool Evaluate(IActionExecutionContext context) => this.EvaluateValue;
        public override string ToString() => "Dummy predicate that is always " + this.EvaluateValue.ToString().ToLowerInvariant();
    }
}
