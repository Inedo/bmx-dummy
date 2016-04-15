using System.Collections.Generic;
using System.ComponentModel;
using Inedo.BuildMaster.Extensibility.IssueTrackerConnections;
using Inedo.Documentation;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [DisplayName("Dummy Issue Tracker")]
    [Description("Not a real provider, just returns a single issue.")]
    public sealed class DummyIssueTrackingProvider : IssueTrackerConnectionBase
    {
        public override IEnumerable<IIssueTrackerIssue> EnumerateIssues(IssueTrackerConnectionContext context) => new[] { new DummyIssue(context.ReleaseNumber) };
        public override RichDescription GetDescription() => new RichDescription("Not a real provider, just returns a single issue.");
        public override bool IsAvailable() => true;
        public override void ValidateConnection()
        {
        }
    }
}
