namespace UGL.ServiceLocator
{
    public class ServiceBuilder
    {

        public ServiceBuilder Register<T>(T instance)
        {
            ServiceLocator.instance.Register(instance);
            return this;
        }

        public ServiceBuilder RegisterInterfaces<T>(T instance)
        {
            ServiceLocator.instance.RegisterInterfaces(instance);
            return this;
        }

    }
}