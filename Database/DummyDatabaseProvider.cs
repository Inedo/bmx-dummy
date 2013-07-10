using System;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Providers.Database;
using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Web;
using System.Collections.Generic;
using System.Text;


namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties("Dummy Database", "Fakes a database provider.")]
    [CustomEditor(typeof(DummyDatabaseProviderEditor))]
    public sealed class DummyDatabaseProvider : DatabaseProviderBase, IChangeScriptProvider, IRestoreProvider
    {
        /// <summary>
        /// Indicates whether the provider is initialized
        /// </summary>
        [Persistent]
        public bool IsInitialized { get; set; }

        /// <summary>
        /// Indicates whether the provider should throw exceptions
        /// </summary>
        [Persistent]
        public bool ThrowNotImplementedExceptions { get; set; }

        public  void InitializeDatabase()
        {
            if (ThrowNotImplementedExceptions) throw new NotImplementedException("Dummy Provider cannot be initialized; only its properties changed.");
        }

        public  bool IsDatabaseInitialized()
        {
            return IsInitialized;
        }

        public  ChangeScript[] GetChangeHistory()
        {
            return new ChangeScript[]
            {
                new DummyDatabaseChangeScript(1, 1, "Script #1", new DateTime(2008, 1, 1), true),
                new DummyDatabaseChangeScript(1, 2, "Script #2", new DateTime(2008, 1, 1), false),
                new DummyDatabaseChangeScript(2, 3, "Script #3", new DateTime(2008, 1, 2), false),
            };
        }

        public  long GetSchemaVersion()
        {
            return 2;
        }

        public  ExecutionResult ExecuteChangeScript(long numericReleaseNumber, int scriptId, string scriptName, string scriptText)
        {
            if (numericReleaseNumber < 2)
                return new ExecutionResult(ExecutionResult.Results.Skipped, "Older Script");
            else if (ThrowNotImplementedExceptions)
                throw new NotImplementedException();
            else
                return new ExecutionResult(ExecutionResult.Results.Success, "Faked Successfully!");

        }

        public  void BackupDatabase(string databaseName, string destinationPath)
        {
            if (ThrowNotImplementedExceptions) throw new NotImplementedException();
        }

        public  void RestoreDatabase(string databaseName, string sourcePath)
        {
            if (ThrowNotImplementedExceptions) throw new NotImplementedException();
        }

        public override void ExecuteQueries(string[] queries)
        {
            if (ThrowNotImplementedExceptions) throw new NotImplementedException();
        }

        public override void ExecuteQuery(string query)
        {
            if (ThrowNotImplementedExceptions) throw new NotImplementedException();
        }

        public override bool IsAvailable()
        {
            return true;
        }

        public override void ValidateConnection()
        {

        }

        public override string ToString()
        {
            return string.Format(
                "A database provider that {0} initialized and {1} throw exceptions",
                IsInitialized ? "is" : "is not",
                ThrowNotImplementedExceptions ? "will" : "will not");
        }
    }
}
