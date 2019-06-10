using Autofac;
using Entities;
using Repositories;
using Interfaces;

namespace WPF_Project
{
    class Container
    {
        public IContainer Get => container;

        #region container initializer
        public Container()
        {
            var builder = new ContainerBuilder();
            Dependencies(builder);
            container = builder.Build();
        }
        #endregion

        private void Dependencies(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<CollectionsDatabaseEntities>().InstancePerLifetimeScope();
            builder.RegisterType<AlbumRepository>().As<IRepository<AlbumSet>>().InstancePerLifetimeScope();
        }

        #region private fields
        private readonly IContainer container;
        #endregion
    }
}
