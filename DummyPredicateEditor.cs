using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

using Inedo.BuildMaster.Extensibility.Predicates;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyPredicateEditor : PredicateEditorBase
    {
        CheckBox chkEvaluateValue = new CheckBox();

        protected override void CreateChildControls()
        {
            CUtil.Add(
                this,
                new FormFieldGroup(
                    "Evaluate Value",
                    "Check the box to have this predicate always evaluate \"true.\"",
                    true,
                    new StandardFormField("Evaluate Value:", chkEvaluateValue)
                )
            );

            base.CreateChildControls();
        }

        public override void BindToForm(PredicateBase extension)
        {
            DummyPredicate dummyPred = (DummyPredicate)extension;
            chkEvaluateValue.Checked = dummyPred.EvaluateValue;
        }

        public override PredicateBase CreateFromForm()
        {
            DummyPredicate dummyPred = new DummyPredicate();
            dummyPred.EvaluateValue = chkEvaluateValue.Checked;

            return dummyPred;
        }
    }
}
