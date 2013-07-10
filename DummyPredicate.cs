using System;
using System.ComponentModel;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Extensibility.Predicates;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [PredicateProperties(
        "Dummy Predicate",
        "A dummy predicate that will always return the specified boolean value.")]
    [Serializable]
    public sealed class DummyPredicate : PredicateBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyPredicate"/> class.
        /// </summary>
        public DummyPredicate()
        {
        }

        /// <summary>
        /// Gets or sets the value returned when the predicate is evaluated.
        /// </summary>
        [Persistent]
        [Category("Evaluate Value")]
        [DisplayName("Evaluate Value")]
        [Description("Check the box to have this predicate always evaluate to true.")]
        public bool EvaluateValue { get; set; }

        public override bool Evaluate(IActionExecutionContext context)
        {
            return this.EvaluateValue;
        }

        public override string ToString()
        {
            return "Dummy predicate that is always " + this.EvaluateValue.ToString().ToLower();
        }
    }
}
