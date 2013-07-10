using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Extensibility.Actions.Testing;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ActionProperties(
        "Dummy Testing",
        "Runs a series of unit tests.",
        "Dummy")]
    public sealed class DummyTestingAction : UnitTestActionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyTestingAction"/> class.
        /// </summary>
        public DummyTestingAction()
        {
        }

        /// <summary>
        /// Gets or sets the newline-separated lists of tests
        /// </summary>
        /// <remarks>
        /// Each test is represented as a pipe-delimited string with:
        ///   0: P or F (Pass or Fail)
        ///   1: Test Name (optional)
        ///   2: Test Result (optional)
        /// </remarks>
        [Persistent]
        [Category("Tests to Run")]
        [DisplayName("Tests")]
        [Description("Each test is represented as a pipe-delimited string with: "
                    + "<br /> 0: P or F (Pass or Fail)"
                    + "<br /> 1: Test Name (optional)"
                    + "<br /> 2: Test Result (optional)")]
        public string[] TestsToRun { get; set; }

        public override string ToString()
        {
            return "Run " + this.GroupName + " tests";
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
                var testLog = test.Length > 2
                        ? test[2]
                        : string.Empty;

                var testName = test.Length > 1
                        ? test[1]
                        : string.Format("Test #{0}", testNum);
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

                var start = DateTime.Now;
                Thread.Sleep(500);
                var end = DateTime.Now;

                this.RecordResult(
                    testName,
                    pass,
                    testLog,
                    start,
                    end
                );
            }

            this.LogInformation("Tests complete.");
        }
    }
}
