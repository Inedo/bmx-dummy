using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace Inedo.BuildMasterExtensions.Dummy
{
    /// <summary>
    /// A dummy action that does absolutely nothing except look like another action and log the specified text.
    /// </summary>
    [ActionProperties(
        "Dummy Action",
        "A dummy action that does absolutely nothing except look like another action and log the specified text.",
        "Dummy")]
    public sealed class DummyAction : ActionBase, IActionNameProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyAction"/> class.
        /// </summary>
        public DummyAction()
        {
        }

        /// <summary>
        /// Gets or sets the action's description.
        /// </summary>
        [Persistent]
        [DisplayName("Action Description")]
        [Category("Dummy Action Options")]
        [Description("Log Text is logged one line at a time at a rate of one per second. Blank lines are not logged.")]
        public string ActionDescription { get; set; }

        /// <summary>
        /// Gets or sets the text to log.
        /// </summary>
        [Persistent]
        [DisplayName("Text to Log")]
        [Category("Dummy Action Options")]
        public string[] TextToLog { get; set; }

        [Browsable(false)]
        string IActionNameProvider.ActionName { get { return this.ActionDescription; } }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Dummy Action: " + ActionDescription;
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
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
