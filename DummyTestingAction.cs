using System;
using System.IO;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Extensibility.Actions.Testing;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ActionProperties(
        "Dummy Testing",
        "Runs a series of unit tests.",
        "Dummy")]
    [CustomEditor(typeof(DummyTestingActionEditor))]
    public sealed class DummyTestingAction : UnitTestActionBase
    {
        private string _TestsToRun;
        [Persistent]
        /// <summary>
        /// Gets or sets the newline-separated lists of tests
        /// </summary>
        /// <remarks>
        /// Each test is represented as a pipe-delimited string with:
        ///   0: P or F (Pass or Fail)
        ///   1: Test Name (optional)
        ///   2: Test Result (optional)
        /// </remarks>
        public string TestsToRun
        {
            get { return _TestsToRun; }
            set { _TestsToRun = value; }
        }

        public override string ToString()
        {
            return "Run " + GroupName + " Tests.";
        }
        
        protected override void RunTests()
        {
            if (TestsToRun == null)
            {
                LogInformation("No tests to run!");
                return;
            }

            LogInformation("Running Tests...");
            StringReader sr = new StringReader(TestsToRun);
            int testNum = 0;
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null) break;
                testNum++;

                string[] test = line.Split(new char[] { '|' }, 3);
                bool pass = test[0].StartsWith("P");
                string testLog = test.Length > 2
                        ? test[2]
                        : string.Empty;

                string testName = test.Length > 1
                        ? test[1]
                        : string.Format("Test #{0}", testNum);
                if (pass)
                {
                    LogInformation(testName);
                    if (!string.IsNullOrEmpty(testLog)) LogDebug(testLog);
                }
                else
                {
                    LogError(testName);
                    if (!string.IsNullOrEmpty(testLog)) LogError(testLog);
                }

                DateTime start = DateTime.Now;
                System.Threading.Thread.Sleep(500);
                DateTime end = DateTime.Now;

                RecordResult(
                    testName,
                    pass,
                    testLog,
                    start,
                    end);
                    
            }
            LogInformation("Tests complete.");
        }
    }
}
