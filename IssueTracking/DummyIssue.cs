using System;
using Inedo.BuildMaster.Extensibility.IssueTrackerConnections;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    internal sealed class DummyIssue : IIssueTrackerIssue
    {
        private string releaseNumber;

        public DummyIssue(string releaseNumber)
        {
            this.releaseNumber = releaseNumber;
            var lastChar = releaseNumber.Substring(releaseNumber.Length - 1, 1);
            int lastCharInt = int.TryParse(lastChar, out lastCharInt) ? lastCharInt : -1;
            this.IsClosed = lastCharInt >= 0 && (lastCharInt % 2) == 0;
        }

        public string Id => "1";
        public string Title => "Dummy Issue";
        public string Status => this.IsClosed ? "Resolved" : "Unresolved";
        public string Url => null;
        public string Submitter => "nobody";
        public bool IsClosed { get; }
        public DateTime SubmittedDate { get; } = DateTime.UtcNow;
        public string Description
        {
            get
            {
                var desc = $"This is just a dummy issue for release {this.releaseNumber}. ";
                if (this.IsClosed)
                    desc += "It is resolved because the last character of the release number is divisible by 2.";
                else
                    desc += "It is unresolved because the last character of the release number either not divisible by 2, or is not numeric.";

                return desc;
            }
        }
    }
}
