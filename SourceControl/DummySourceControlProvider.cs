using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.SourceControl;
using Inedo.BuildMaster.Files;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties("Dummy SCM Provider", "A fake provider that does absolutely nothing.")]
    public sealed class DummySourceControlProvider : SourceControlProviderBase, IMultipleRepositoryProvider<DummyRepository>
    {
        [Persistent]
        public DummyRepository[] Repositories { get; set; }

        RepositoryBase[] IMultipleRepositoryProvider.Repositories
        {
            get { return this.Repositories; }
            set { this.Repositories = (DummyRepository[])value; }
        }

        public override char DirectorySeparator
        {
            get { return '/'; }
        }

        public override void GetLatest(string sourcePath, string targetPath)
        {
        }
        public override DirectoryEntryInfo GetDirectoryEntryInfo(string sourcePath)
        {
            return new DirectoryEntryInfo("/", "/", null, null);
        }
        public override byte[] GetFileContents(string filePath)
        {
            return new byte[0];
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
            return "Dummy SCM Provider";
        }
    }
}
