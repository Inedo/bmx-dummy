using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Documentation;
using Inedo.BuildMaster.Extensibility.Actions.Testing;
using Inedo.BuildMaster.Web;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [DisplayName("Dummy Testing")]
    [Description("Runs a series of unit tests.")]
    [Tag("dummy")]
    [CustomEditor(typeof(DummyTestingActionEditor))]
    public sealed class DummyTestingAction : UnitTestActionBase
    {
        [Persistent]
        public string[] TestsToRun { get; set; }

        public override ExtendedRichDescription GetActionDescription()
        {
            return new ExtendedRichDescription(
                new RichDescription(
                    "Run ",
                    new Hilite(this.GroupName),
                    " Tests"
                )
            );
        }

        protected override void RunTests()
        {
            if (this.TestsToRun == null || this.TestsToRun.Length == 0)
            {
                this.LogInformation("No tests to run.");
                return;
            }

            this.LogInformation("Running tests...");
            var sr = new StringReader(string.Join(Environment.NewLine, this.TestsToRun));
            int testNum = 0;
            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                    break;

                testNum++;

                var test = line.Split(new[] { '|' }, 3);
                bool pass = test[0].StartsWith("P");
                var testLog = test.Length > 2 ? test[2] : string.Empty;

                var testName = test.Length > 1 ? test[1] : string.Format("Test #{0}", testNum);

                if (pass)
                {
                    this.LogInformation(testName);
                    if (!string.IsNullOrEmpty(testLog))
                        this.LogDebug(testLog);
                }
                else
                {
                    this.LogError(testName);
                    if (!string.IsNullOrEmpty(testLog))
                        this.LogError(testLog);
                }

                this.ThrowIfCanceledOrTimeoutExpired();

                var start = DateTime.UtcNow;
                Thread.Sleep(500);
                var end = DateTime.UtcNow;

                this.RecordResult(testName, pass, testLog, start, end);
            }

            this.LogInformation("Tests complete.");
        }
    }
}
