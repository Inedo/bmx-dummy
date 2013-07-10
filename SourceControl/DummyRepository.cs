using Inedo.BuildMaster.Extensibility.Providers.SourceControl;

namespace Inedo.BuildMasterExtensions.Dummy
{
    public sealed class DummyRepository : RepositoryBase
    {
        private readonly string name;

        public DummyRepository() { }
        public DummyRepository(string name)
        {
            this.name = name;
        }

        public override string RepositoryName { get { return this.name; } }
    }
}
