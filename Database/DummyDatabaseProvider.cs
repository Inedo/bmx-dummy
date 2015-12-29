using System;
using System.ComponentModel;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.Database;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties(
        "Dummy Database",
        "Fakes a database provider.")]
    public sealed class DummyDatabaseProvider : DatabaseProviderBase, IChangeScriptProvider, IRestoreProvider
    {
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("Initialized")]
        public bool IsInitialized { get; set; }
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("Throw NotImplementedExceptions")]
        public bool ThrowNotImplementedExceptions { get; set; }

        public void InitializeDatabase()
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException("The Dummy Provider cannot be initialized.");
        }

        public bool IsDatabaseInitialized() => this.IsInitialized;

        public ChangeScript[] GetChangeHistory()
        {
            return new[]
            {
                new ChangeScript(1, 1, "Script #1", new DateTime(2008, 1, 1), true),
                new ChangeScript(1, 2, "Script #2", new DateTime(2008, 1, 1), false),
                new ChangeScript(2, 3, "Script #3", new DateTime(2008, 1, 2), false)
            };
        }

        public long GetSchemaVersion() => 2;

        public ExecutionResult ExecuteChangeScript(long numericReleaseNumber, int scriptId, string scriptName, string scriptText)
        {
            if (numericReleaseNumber < 2)
                return new ExecutionResult(ExecutionResult.Results.Skipped, "Older Script");
            else if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();
            else
                return new ExecutionResult(ExecutionResult.Results.Success, "Faked Successfully!");

        }

        public void BackupDatabase(string databaseName, string destinationPath)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();
        }

        public void RestoreDatabase(string databaseName, string sourcePath)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();
        }

        public override void ExecuteQueries(string[] queries)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();
        }

        public override void ExecuteQuery(string query)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();
        }

        public override bool IsAvailable() => true;

        public override void ValidateConnection()
        {
        }

        public override string ToString()
        {
            return string.Format(
                "A database provider that {0} initialized and {1} throw exceptions",
                this.IsInitialized ? "is" : "is not",
                this.ThrowNotImplementedExceptions ? "will" : "will not");
        }
    }
}
