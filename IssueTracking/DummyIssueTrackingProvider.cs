using System.Collections.Generic;
using Inedo.BuildMaster.Extensibility;
using Inedo.BuildMaster.Extensibility.IssueTrackerConnections;
using Inedo.BuildMaster.Extensibility.Providers;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties(
        "Dummy Issue Tracker",
        "Not a real provider, just returns a single issue.")]
    public sealed class DummyIssueTrackingProvider : IssueTrackerConnectionBase
    {
        public override IEnumerable<IIssueTrackerIssue> EnumerateIssues(IssueTrackerConnectionContext context)
        {
            return new[] { new DummyIssue(context.ReleaseNumber) };
        }
        public override ExtensionComponentDescription GetDescription()
        {
            return new ExtensionComponentDescription("Not a real provider, just returns a single issue.");
        }
        public override bool IsAvailable() => true;
        public override void ValidateConnection()
        {
        }
    }
}
