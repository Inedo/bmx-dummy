using System;

using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Providers.Database;
using Inedo.BuildMaster.Extensibility.Providers;
using System.Collections.Generic;
using System.Text;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [Serializable]
    public sealed class DummyDatabaseChangeScript : ChangeScript
    {
        internal DummyDatabaseChangeScript(Int64 numericReleaseNumber, int scriptId, string name, DateTime executionDate, bool successfullyExecuted)
            : base(numericReleaseNumber, scriptId, name, executionDate, successfullyExecuted)
        {}

    }
}
