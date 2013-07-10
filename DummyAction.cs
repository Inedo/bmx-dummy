using System.IO;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ActionProperties(
        "Dummy Action",
        "A dummy action that does absolutely nothing except look like another action and log the specified text.",
        "Dummy")]
    [CustomEditor(typeof(DummyActionEditor))]
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
        public string ActionDescription { get; set; }

        /// <summary>
        /// Gets or sets the text to log.
        /// </summary>
        [Persistent]
        public string TextToLog { get; set; }

        public override string ToString()
        {
            return "Dummy Action: " + ActionDescription;
        }

        protected override void Execute()
        {
            if (TextToLog == null) return;

            string line;
            StringReader sr = new StringReader(TextToLog);
            while ( (line = sr.ReadLine()) != null)
            {
                if (line != string.Empty) LogInformation(line);

                System.Threading.Thread.Sleep(1000);
            }
        }

        #region IActionNameProvider Members

        string IActionNameProvider.ActionName { get { return ActionDescription;}  }
        #endregion
    }
}
