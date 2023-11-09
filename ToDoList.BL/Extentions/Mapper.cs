using AutoMapper;
using ToDoList.BL.DTO;
using ToDoList.DAL.Models;

public static class Mapper
{
    private static readonly IMapper _mapper;

    static Mapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<UserDTO, User>();
            cfg.CreateMap<ToDoList.DAL.Models.ToDoList, ToDoListDTO>();
            cfg.CreateMap<ToDoListDTO, ToDoList.DAL.Models.ToDoList>();
        });

        _mapper = config.CreateMapper();
    }

    public static UserDTO MapUserToDTO(User user)
    {
        return _mapper.Map<UserDTO>(user);
    }

    public static User MapDTOToUser(UserDTO userDTO)
    {
        return _mapper.Map<User>(userDTO);
    }

    public static List<UserDTO> MapUsersToDTO(IEnumerable<User> users)
    {
        return _mapper.Map<List<UserDTO>>(users);
    }

    public static List<User> MapDTOToUsers(List<UserDTO> userDTOs)
    {
        return _mapper.Map<List<User>>(userDTOs);
    }

    public static List<ToDoListDTO> MapToDoListsToDTO(IEnumerable<ToDoList.DAL.Models.ToDoList> toDoLists)
    {
        return _mapper.Map<List<ToDoListDTO>>(toDoLists);
    }

    public static List<ToDoList.DAL.Models.ToDoList> MapDTOToToDoLists(List<ToDoListDTO> ToDoListDTOs)
    {
        return _mapper.Map<List<ToDoList.DAL.Models.ToDoList>>(ToDoListDTOs);
    }

    public static ToDoListDTO MapToDoListToDTO(ToDoList.DAL.Models.ToDoList toDoList)
    {
        return _mapper.Map<ToDoListDTO>(toDoList);
    }

    public static ToDoList.DAL.Models.ToDoList MapDTOToToDoList(ToDoListDTO toDoListDTO)
    {
        return _mapper.Map<ToDoList.DAL.Models.ToDoList>(toDoListDTO);
    }
}