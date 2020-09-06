using AutoMapper;
using DryIoc;
using ToDoApp.Domain.Managers;
using ToDoApp.Persistence;

namespace ToDoApp.Domain
{
    public static class DryIocDomainExtensions
    {
        public static void AddDomain(this IContainer c)
        {
            c.AddPersistence();

            c.RegisterInstance<IMapper>(new Mapper(AutoMapperConfig.CreateConfiguration()));

            c.Register<IToDoItemDomainManager, ToDoItemDomainManager>();
        }
    }
}