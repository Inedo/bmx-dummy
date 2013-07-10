using System;
using System.Collections.Generic;
using System.Text;

using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Extensibility.Predicates;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [PredicateProperties(
        "Dummy Predicate",
        "A dummy predicate that will always return the specified boolean value.")]
    [CustomEditor(typeof(DummyPredicateEditor))]
    [Serializable]
    public sealed class DummyPredicate : PredicateBase
    {
        private bool _EvaluateValue;
        /// <summary>
        /// Gets or sets the value returned when the predicate is evaluated
        /// </summary>
        [Persistent]
        public bool EvaluateValue
        {
            get { return _EvaluateValue; }
            set { _EvaluateValue = value; }
        }

        public override bool Evaluate(ExecutionContext context)
        {
            return _EvaluateValue;
        }

        public override string ToString()
        {
            return "Dummy predicate that is always \"" + _EvaluateValue.ToString().ToLower() + "\"";
        }
    }
}
