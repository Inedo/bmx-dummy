using Inedo.BuildMaster.Extensibility.Providers;
using Inedo.BuildMaster.Extensibility.Providers.SourceControl;
using Inedo.BuildMaster.Files;

namespace Inedo.BuildMasterExtensions.Dummy
{
    [ProviderProperties("Dummy SCM Provider", "A fake provider that does absolutely nothing.")]
    public sealed class DummySourceControlProvider : SourceControlProviderBase
    {
        public override char DirectorySeparator => '/';
        public override void GetLatest(string sourcePath, string targetPath)
        {
        }
        public override DirectoryEntryInfo GetDirectoryEntryInfo(string sourcePath) => new DirectoryEntryInfo("/", "/", null, null);
        public override byte[] GetFileContents(string filePath) => new byte[0];
        public override bool IsAvailable() => true;
        public override void ValidateConnection()
        {
        }
        public override string ToString() => "Dummy SCM Provider";
    }
}
