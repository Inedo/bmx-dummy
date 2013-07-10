using System;
using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.IssueTracking;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties(
        "Dummy Issue Tracker", 
        "Not a real provider, just returns a single issue.")]
    public sealed class DummyIssueTrackingProivder
        : IssueTrackingProviderBase, ICategoryFilterable
    {
        #region IssueTrackingProviderBase
        public override Issue[] GetIssues(string releaseNumber)
        {
            return new Issue[] { new DummyIssue(releaseNumber) };
        }

        public override bool AreAllIssuesClosed(string releaseNumber)
        {
            foreach (Issue issue in GetIssues(releaseNumber))
                if (!IsIssueClosed(issue)) return false;
            return true;
        }

        public override bool IsIssueClosed(Issue issue)
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
        #endregion

        #region ICategoryFilterable Members

        private string[] _CategoryIdFilter;

        public string[] CategoryIdFilter
        {
            get { return _CategoryIdFilter; }
            set { _CategoryIdFilter = value; }
        }

        public string[] CategoryTypeNames
        {
            get { return new string[] { "Level1", "Level2" }; }
        }

        public CategoryBase[] GetCategories()
        {
            return new DummyCategory[]{
                new DummyCategory("C1", "Category 1", new DummyCategory[]{
                    new DummyCategory("C1a", "SubCategory 1a", null),
                    new DummyCategory("C1b", "SubCategory 1b", null) 
                }),
                new DummyCategory("C2", "Category 2", new DummyCategory[]{
                    new DummyCategory("C2a", "SubCategory 2a", null),
                    new DummyCategory("C2b", "SubCategory 2b", null) 
                })
            };
        }

        #endregion

        public override string ToString()
        {
            return "Not a real provider, just returns a single issue.";
        }
    }

    [Serializable]
    internal sealed class DummyCategory : CategoryBase
    {
        public DummyCategory(string categoryId, string categoryName, CategoryBase[] subCategories)
            : base(categoryId, categoryName, subCategories) {}
    }
}
