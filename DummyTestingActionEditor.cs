using System.Web.UI.WebControls;
using Inedo.BuildMaster.Data;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyTestingActionEditor : ActionEditorBase
    {
        private ValidatingTextBox txtTests;
        private ValidatingTextBox txtGroupName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyTestingActionEditor"/> class.
        /// </summary>
        public DummyTestingActionEditor()
        {
            this.ValidateBeforeCreate += this.DummyTestingActionEditor_ValidateBeforeCreate;
        }

        public override void BindToForm(ActionBase action)
        {
            this.EnsureChildControls();

            var dta = (DummyTestingAction)action;
            this.txtTests.Text = dta.TestsToRun;
            this.txtGroupName.Text = dta.GroupName;
        }
        public override ActionBase CreateFromForm()
        {
            this.EnsureChildControls();

            return new DummyTestingAction
            {
                TestsToRun = this.txtTests.Text,
                GroupName = this.txtGroupName.Text
            };
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.txtGroupName = new ValidatingTextBox { Width = Unit.Pixel(350) };

            this.txtTests = new ValidatingTextBox
            {
                TextMode = TextBoxMode.MultiLine,
                Width = Unit.Pixel(350),
                Rows = 4,
                Columns = 40
            };

            this.Controls.Add(
                new FormFieldGroup(
                    "Test Group",
                    false,
                    new StandardFormField("Group Name:", this.txtGroupName)
                ),
                new FormFieldGroup(
                    "Tests to run.",
                    "Each test is represented as a pipe-delimited string with: "
                    + "<br /> 0: P or F (Pass or Fail)"
                    + "<br /> 1: Test Name (optional)"
                    + "<br /> 2: Test Result (optional)",
                    true,
                    new StandardFormField("Tests:", this.txtTests)
                )
            );
        }

        private void DummyTestingActionEditor_ValidateBeforeCreate(object sender, ValidationEventArgs<ActionBase> e)
        {
            if (this.DeployableId == 0)
            {
                e.ValidLevel = ValidationLevels.Error;
                e.Message =
                    "In order to create a unit testing action, you must use an action group " +
                    "that has a default deployable selected.  To do so, return to the Deployment " +
                    "Plans section and choose \"Create New Action Group,\" and select a default " +
                    "deployable for the new group.";
            }
        }
    }
}
