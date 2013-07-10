using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.IssueTracking;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties(
        "Dummy Issue Tracker", 
        "Not a real provider, just returns a single issue.")]
    public sealed class DummyIssueTrackingProvider : IssueTrackingProviderBase, ICategoryFilterable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyIssueTrackingProvider"/> class.
        /// </summary>
        public DummyIssueTrackingProvider()
        {
        }

        public string[] CategoryIdFilter { get; set; }

        public string[] CategoryTypeNames
        {
            get { return new[] { "Level1", "Level2" }; }
        }

        public override IssueTrackerIssue[] GetIssues(string releaseNumber)
        {
            return new[] { new DummyIssue(releaseNumber) };
        }

        public override bool AreAllIssuesClosed(string releaseNumber)
        {
            foreach (var issue in GetIssues(releaseNumber))
                if (!IsIssueClosed(issue)) return false;
            return true;
        }

        public override bool IsIssueClosed(IssueTrackerIssue issue)
        {
            return issue.IssueStatus == "Resolved";
        }

        public override bool IsAvailable()
        {
            return true;
        }

        public override void ValidateConnection()
        {
        }

        public IssueTrackerCategory[] GetCategories()
        {
            return new[]{
                new IssueTrackerCategory("C1", "Category 1", new[]{
                    new IssueTrackerCategory("C1a", "SubCategory 1a", null),
                    new IssueTrackerCategory("C1b", "SubCategory 1b", null) 
                }),
                new IssueTrackerCategory("C2", "Category 2", new[]{
                    new IssueTrackerCategory("C2a", "SubCategory 2a", null),
                    new IssueTrackerCategory("C2b", "SubCategory 2b", null) 
                })
            };
        }

        public override string ToString()
        {
            return "Not a real provider, just returns a single issue.";
        }
    }
}
