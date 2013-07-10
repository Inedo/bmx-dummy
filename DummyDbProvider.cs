using System;
using System.Collections.Generic;
using System.Text;

using Inedo.BuildMaster;
using Inedo.BuildMaster.ProviderManagement;
using Inedo.BuildMaster.Providers.Database;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties("Dummy Database", 
        "Represents a database provider that doesn't actually do anything.")]
    public sealed class DummyDbProvider : DatabaseProviderBase
    {
        [Persistent]
        public bool DatabaseInitialized { get; set; }

        public override void InitializeDatabase()
        {
            throw new NotImplementedException("DummyDb's properties must change inorder to be initialized.");
        }

        public override bool IsDatabaseInitialized()
        {
            return DatabaseInitialized;
        }

        [Serializable]
        public sealed class DummyChangeScript : ChangeScript
        {
            public DummyChangeScript()
            {
                
            }
        }

        public override ChangeScript[] GetChangeHistory()
        {
            return new ChangeScript[]
            {
                
            };
        }

        public override long GetSchemaVersion()
        {
            throw new NotImplementedException();
        }

        public override bool ExecuteChangeScript(long numericReleaseNumber, int scriptId, string scriptName, string scriptText)
        {
            throw new NotImplementedException();
        }

        public override void BackupDatabase(string databaseName, string destinationPath)
        {
            throw new NotImplementedException();
        }

        public override void RestoreDatabase(string databaseName, string sourcePath)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteQueries(string[] queries)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public override void ValidateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
