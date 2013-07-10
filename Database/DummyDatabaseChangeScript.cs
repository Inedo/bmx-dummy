using System;
using Inedo.BuildMaster.Extensibility.Providers.Database;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    public sealed class DummyDatabaseChangeScript : ChangeScript
    {
        internal DummyDatabaseChangeScript(Int64 numericReleaseNumber, int scriptId, string name, DateTime executionDate, bool successfullyExecuted)
            : base(numericReleaseNumber, scriptId, name, executionDate, successfullyExecuted)
        {
        }
    }
}
