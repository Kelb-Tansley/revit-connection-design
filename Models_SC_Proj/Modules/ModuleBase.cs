using Prism.Ioc;
using Prism.Modularity;

namespace Models_SC_Proj.Modules
{
    public abstract class ModuleBase : IModule
    {
        public ModuleBase()
        {

        }

        public abstract string Name { get; }
        public abstract string DisplayName { get; }

        public virtual void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public virtual void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
