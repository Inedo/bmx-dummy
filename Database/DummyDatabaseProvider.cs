using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Inedo.BuildMaster.Extensibility.DatabaseConnections;
using Inedo.Serialization;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [DisplayName("Dummy Database")]
    [Description("Fakes a database provider.")]
    public sealed class DummyDatabaseProvider : DatabaseConnection, IChangeScriptExecuter, IBackupRestore
    {
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("Initialized")]
        public bool IsInitialized { get; set; }
        [Persistent]
        [Category("Dummy Options")]
        [DisplayName("When true, throw a NotImplementedException whenever this connection is used.")]
        public bool ThrowNotImplementedExceptions { get; set; }

        public int MaxChangeScriptVersion => 1;

        public override Task ExecuteQueryAsync(string query, CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
        public Task ExecuteChangeScriptAsync(ChangeScriptId scriptId, string scriptName, string scriptText, CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
        public Task<ChangeScriptState> GetStateAsync(CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult(new ChangeScriptState(this.IsInitialized, this.MaxChangeScriptVersion));
        }
        public Task InitializeDatabaseAsync(CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
        public Task UpgradeSchemaAsync(IReadOnlyDictionary<int, Guid> canoncialGuids, CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
        public Task BackupDatabaseAsync(string databaseName, string destinationPath, CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
        public Task RestoreDatabaseAsync(string databaseName, string sourcePath, CancellationToken cancellationToken)
        {
            if (this.ThrowNotImplementedExceptions)
                throw new NotImplementedException();

            return Task.FromResult<object>(null);
        }
    }
}
