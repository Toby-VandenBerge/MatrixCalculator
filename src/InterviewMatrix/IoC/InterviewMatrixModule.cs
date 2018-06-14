using Autofac;
using InterviewMatrix.Commands;
using System.Linq;
using System.Reflection;

namespace InterviewMatrix.IoC
{
    public class InterviewMatrixModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(ThisAssembly)
            //    .Where(t => t.GetTypeInfo()
            //        .ImplementedInterfaces.Any(
            //            i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommand<>)))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
        }
    }
}
