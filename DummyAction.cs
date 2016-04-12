using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Documentation;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [DisplayName("Dummy Action")]
    [Description("A dummy action that does absolutely nothing except look like another action and log the specified text.")]
    [Tag("dummy")]
    [CustomEditor(typeof(DummyActionEditor))]
    public sealed class DummyAction : ActionBase
    {
        [Persistent]
        public string ActionDescription { get; set; }
        [Persistent]
        public string[] TextToLog { get; set; }

        public override ExtendedRichDescription GetActionDescription()
        {
            return new ExtendedRichDescription(
                new RichDescription(this.ActionDescription)
            );
        }

        protected override void Execute()
        {
            if (this.TextToLog == null || this.TextToLog.Length == 0)
                return;

            string line;
            var sr = new StringReader(string.Join(Environment.NewLine, this.TextToLog));
            while ((line = sr.ReadLine()) != null)
            {
                if (line != string.Empty)
                    this.LogInformation(line);

                this.ThrowIfCanceledOrTimeoutExpired();
                Thread.Sleep(1000);
            }
        }
    }
}
