using System;
using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Dummy
{
    internal sealed class DummyActionEditor : ActionEditorBase
    {
        private ValidatingTextBox txtActionDescription;
        private ValidatingTextBox txtTextToLog;

        public override void BindToForm(ActionBase extension)
        {
            var dummy = (DummyAction)extension;

            this.txtActionDescription.Text = dummy.ActionDescription;
            this.txtTextToLog.Text = string.Join(Environment.NewLine, dummy.TextToLog ?? new string[0]);
        }
        public override ActionBase CreateFromForm()
        {
            return new DummyAction
            {
                ActionDescription = this.txtActionDescription.Text,
                TextToLog = this.txtTextToLog.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        protected override void CreateChildControls()
        {
            this.txtActionDescription = new ValidatingTextBox
            {
                MaxLength = 100,
                Required = true
            };

            this.txtTextToLog = new ValidatingTextBox
            {
                TextMode = TextBoxMode.MultiLine,
                Rows = 5
            };

            this.Controls.Add(
                new SlimFormField("Action description:", this.txtActionDescription),
                new SlimFormField("Text to log:", this.txtTextToLog)
                {
                    HelpText = "Text is logged one line at a time at a rate of one per second. Blank lines are not logged."
                }
            );
        }
    }
}
