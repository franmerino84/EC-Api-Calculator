using EC.Api.Calculator.Infrastructure.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EC.Api.Calculator.Infrastructure.Ioc
{
    public static class AssemblyDependenciesRegistrar
    {
        public static void AddDependenciesFromAssemblyOfType<T>(this IServiceCollection services) =>
           services.AddDependenciesFromAssemblyOfType(typeof(T));

        public static void AddDependenciesFromAssemblyOfType(this IServiceCollection services, Type typeInsideTargetAssembly) =>
            services.AddDependenciesFromAssembly(typeInsideTargetAssembly.Assembly);

        public static void AddDependenciesFromAssembly(this IServiceCollection services, string assemblyName)
        {
            Assembly? assembly = AppDomain.CurrentDomain.GetAssemblies().
                    SingleOrDefault(assembly => assembly.GetName().Name == assemblyName)
                    ?? throw new AssemblyNotFoundException(assemblyName);

            services.AddDependenciesFromAssembly(assembly);
        }

        public static void AddDependenciesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            assembly.GetTypes().Where(type => typeof(IDependenciesRegistrar).IsAssignableFrom(type))
                .ToList()
                .ForEach(type => GetDependenciesRegistrarInstance(type).Register(services));
        }

        private static IDependenciesRegistrar GetDependenciesRegistrarInstance(Type type)
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);

            return constructor == null
                ? throw new ConstructorWithoutParametersDoesntExistException(type)
                : (IDependenciesRegistrar)constructor.Invoke(Array.Empty<object>());
        }
    }
}
