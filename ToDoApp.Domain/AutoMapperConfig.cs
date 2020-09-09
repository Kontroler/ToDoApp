using AutoMapper;
using System;
using ToDoApp.Domain.Models;
using ToDoApp.Persistence.Entities;

namespace ToDoApp.Domain
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ToDo, ToDoItem>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(x => MapStatus(x.Status.Name)));
                cfg.CreateMap<ToDoItem, ToDo>()
                    .ForPath(dest => dest.Status.Name, opt => opt.MapFrom(x => x.Status.ToString()));
            });

            return config;
        }

        public static ToDoItemStatus MapStatus(string status)
        {
            if (status == ToDoItemStatus.InProgress.ToString())
            {
                return ToDoItemStatus.InProgress;
            }
            if (status == ToDoItemStatus.Done.ToString())
            {
                return ToDoItemStatus.Done;
            }
            throw new Exception("Error mapping status. Unknown value.");
        }
    }
}