using System;
using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Dummy
{
    internal sealed class DummyTestingActionEditor : ActionEditorBase
    {
        private ValidatingTextBox txtTestGroup;
        private ValidatingTextBox txtTestsToRun;

        public override void BindToForm(ActionBase extension)
        {
            var dummy = (DummyTestingAction)extension;

            this.txtTestGroup.Text = dummy.GroupName;
            this.txtTestsToRun.Text = string.Join(Environment.NewLine, dummy.TestsToRun ?? new string[0]);
        }

        public override ActionBase CreateFromForm()
        {
            return new DummyTestingAction
            {
                GroupName = this.txtTestGroup.Text,
                TestsToRun = this.txtTestsToRun.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        protected override void CreateChildControls()
        {
            this.txtTestGroup = new ValidatingTextBox
            {
                MaxLength = 50,
                Required = true
            };

            this.txtTestsToRun = new ValidatingTextBox
            {
                DefaultText = "ex: P|Passing test|This test always passes.",
                TextMode = TextBoxMode.MultiLine,
                Rows = 5
            };

            this.Controls.Add(
                new SlimFormField("Test group:", this.txtTestGroup),
                new SlimFormField("Tests to run:", this.txtTestsToRun)
                {
                    HelpText = HelpText.FromHtml(
                        "Each test is represented as a pipe-delimited string with: " +
                        "<br /> 0: P or F (Pass or Fail)" +
                        "<br /> 1: Test Name (optional)" +
                        "<br /> 2: Test Result (optional)"
                    )
                }
            );
        }
    }
}
