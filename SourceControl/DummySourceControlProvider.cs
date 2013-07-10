using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.SourceControl;
using Inedo.BuildMaster.Files;
using Inedo.BuildMaster.Web;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties("Dummy SCM Provider", "A fake provider that does absolutely nothing.")]
    [CustomEditor(typeof(DummySourceControlProviderEditor))]
    public sealed class DummySourceControlProvider : MultipleRepositoryProviderBase<DummyRepository>
    {
        public override char DirectorySeparator
        {
            get { return '/'; }
        }

        public override void GetLatest(string sourcePath, string targetPath)
        {
        }
        public override DirectoryEntryInfo GetDirectoryEntryInfo(string sourcePath, bool recurse)
        {
            return this.GetDirectoryEntryInfo(sourcePath);
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
