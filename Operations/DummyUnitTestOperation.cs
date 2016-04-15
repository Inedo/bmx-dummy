using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Inedo.BuildMaster.Data;
using Inedo.BuildMaster.Extensibility;
using Inedo.BuildMaster.Extensibility.Operations;
using Inedo.Diagnostics;
using Inedo.Documentation;

namespace Inedo.BuildMasterExtensions.Dummy.Operations
{
    [ScriptAlias("Execute-UnitTests")]
    [ScriptNamespace("Dummy", PreferUnqualified = false)]
    [DisplayName("Dummy Unit Test")]
    [Description("Runs a series of unit tests.")]
    [Tag("dummy")]
    public sealed class DummyUnitTestOperation : ExecuteOperation
    {
        [ScriptAlias("Tests")]
        public IEnumerable<string> TestsToRun { get; set; }
        [ScriptAlias("Group")]
        public string GroupName { get; set; }

        public override async Task ExecuteAsync(IOperationExecutionContext context)
        {
            if (this.TestsToRun == null || !this.TestsToRun.Any())
            {
                this.LogInformation("No tests to run.");
                return;
            }

            var tests = from s in this.TestsToRun
                        let p = s.Split(new[] { '|' }, 3)
                        where p.Length >= 1
                        select new
                        {
                            Status = p[0],
                            Name = p.Length > 1 ? p[1] : null,
                            Result = p.Length > 2 ? p[2] : null
                        };

            this.LogInformation("Running tests...");

            int i = 1;
            foreach (var test in tests)
            {
                var name = test.Name ?? ("Test #" + i);
                var result = test.Result ?? string.Empty;
                string code;

                if (test.Status == Domains.TestStatusCodes.Passed)
                {
                    this.LogInformation(name);
                    if (!string.IsNullOrWhiteSpace(result))
                        this.LogDebug(result);

                    code = Domains.TestStatusCodes.Passed;
                }
                else if (test.Status == Domains.TestStatusCodes.Inconclusive)
                {
                    this.LogWarning(name);
                    if (!string.IsNullOrWhiteSpace(result))
                        this.LogWarning(result);

                    code = Domains.TestStatusCodes.Inconclusive;
                }
                else
                {
                    this.LogError(name);
                    if (!string.IsNullOrWhiteSpace(result))
                        this.LogError(result);

                    code = Domains.TestStatusCodes.Failed;
                }

                var start = DateTime.UtcNow;
                await Task.Delay(500);
                var end = DateTime.UtcNow;

                DB.BuildTestResults_RecordTestResult(
                    Execution_Id: context.ExecutionId,
                    Group_Name: this.GroupName,
                    Test_Name: name,
                    TestStatus_Code: code,
                    TestResult_Text: result,
                    TestStarted_Date: start,
                    TestEnded_Date: end
                );

                i++;
            }

            this.LogInformation("Tests complete.");
        }

        protected override ExtendedRichDescription GetDescription(IOperationConfiguration config)
        {
            return new ExtendedRichDescription(
                new RichDescription(
                    "Run ",
                    new Hilite(config[nameof(this.GroupName)]),
                    " Tests"
                )
            );
        }
    }
}
