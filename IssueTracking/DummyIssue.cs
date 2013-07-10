using System;
using Inedo.BuildMaster.Extensibility.Providers.IssueTracking;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    internal sealed class DummyIssue : IssueTrackerIssue
    {
        private bool resolved;

        public DummyIssue(string releaseNo)
            : base("1", null, "Dummy Issue", null, releaseNo)
        {
            if (string.IsNullOrEmpty(releaseNo)) throw new ArgumentNullException("releaseNo");

            var lastChar = releaseNo.Substring(releaseNo.Length - 1, 1);
            int lastCharInt = int.TryParse(lastChar, out lastCharInt) ? lastCharInt : -1;
            this.resolved = lastCharInt >= 0 && (lastCharInt % 2) == 0;
        }

        public override string IssueStatus
        {
            get { return this.resolved ? "Resolved" : "Unresolved"; }
        }

        public override string IssueDescription
        {
            get
            {
                var desc = string.Format("This is just a dummy issue for release {0}. ", this.ReleaseNumber);
                if (this.resolved)
                    desc += "It is resolved because the last character of the release number is divisible by 2.";
                else
                    desc += "It is unresolved because the last character of the release number either not divisible by 2, or is not numeric.";

                return desc;
            }
        }
    }
}
