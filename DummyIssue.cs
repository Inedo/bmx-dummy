using System;
using Inedo.BuildMaster.Extensibility.Providers.IssueTracking;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    internal sealed class DummyIssue : Issue
    {
        public DummyIssue(string releaseNo)
        {
            if (string.IsNullOrEmpty(releaseNo)) throw new ArgumentNullException("releaseNo");

            string lastChar = releaseNo.Substring(releaseNo.Length - 1, 1);
            int lastCharInt = int.TryParse(lastChar, out lastCharInt) ? lastCharInt : -1;
            bool resolved = lastCharInt >= 0 && (lastCharInt % 2) == 0;

            this.IssueId = "1";
            this.IssueDescription =
                "This is just a dummy issue for release " + releaseNo + ". "
                + (resolved
                    ? "It is resolved because the last character of the release number is divisible by 2."
                    : "It is unresolved because the last character of the release number either not divisible by 2, or is not numeric.");
            this.IssueTitle = "Dummy Issue";
            this.ReleaseNumber = releaseNo;
            this.IssueStatus = resolved ? "Resolved" : "Unresolved";
        }
    }
}
