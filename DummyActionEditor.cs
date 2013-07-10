using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyActionEditor : ActionEditorBase
    {
        private ValidatingTextBox txtActionDescription;
        private ValidatingTextBox txtTextToLog;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyActionEditor"/> class.
        /// </summary>
        public DummyActionEditor()
        {
        }

        public override void BindToForm(ActionBase action)
        {
            var dAction = (DummyAction)action;
            this.txtActionDescription.Text = dAction.ActionDescription;
            this.txtTextToLog.Text = dAction.TextToLog;
        }
        public override ActionBase CreateFromForm()
        {
            return new DummyAction
            {
                ActionDescription = this.txtActionDescription.Text,
                TextToLog = this.txtTextToLog.Text
            };
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.txtActionDescription = new ValidatingTextBox { Required = true };

            this.txtTextToLog = new ValidatingTextBox
            {
                TextMode = TextBoxMode.MultiLine,
                Width = Unit.Pixel(350),
                Rows = 4,
                Columns = 40
            };

            this.Controls.Add(
                new FormFieldGroup(
                    "Dummy Action Options",
                    "Log Text is logged one line at a time at a rate of one per second. Blank lines are not logged.",
                    true,
                    new StandardFormField("Action Description:", this.txtActionDescription),
                    new StandardFormField("Text to Log:", this.txtTextToLog)
                )
            );
        }
    }
}
