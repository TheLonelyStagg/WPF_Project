using Autofac;

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
        }

        #region private fields
        private readonly IContainer container;
        #endregion
    }
}
