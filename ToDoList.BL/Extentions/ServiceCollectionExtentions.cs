using Microsoft.Extensions.DependencyInjection;
using ToDoList.BL.DTO;
using ToDoList.BL.Interfaces;
using ToDoList.BL.Services;
using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Models;
using ToDoList.DAL.Repositories;

public static class ServiceCollectionExtentions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IToDoListService, ToDoListService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IToDoListRepository, ToDoListRepository>();
    }
}