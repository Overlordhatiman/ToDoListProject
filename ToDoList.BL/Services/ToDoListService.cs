using ToDoList.BL.DTO;
using ToDoList.BL.Interfaces;
using ToDoList.DAL.Interfaces;

namespace ToDoList.BL.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<ToDoListDTO> CreateToDoListAsync(ToDoListDTO toDoList)
        {
            if (toDoList == null)
            {
                throw new ArgumentNullException(nameof(toDoList));
            }

            return Mapper.MapToDoListToDTO(await _toDoListRepository.Add(Mapper.MapDTOToToDoList(toDoList)));
        }

        public async Task<ToDoListDTO> DeleteToDoListAsync(int toDoListId)
        {
            var toDoList = await GetToDoListAsync(toDoListId);

            if (toDoList == null)
            {
                return null;
            }

            return Mapper.MapToDoListToDTO(await _toDoListRepository.Delete(toDoListId));
        }

        public async Task<List<ToDoListDTO>> GetAllToDoListsAsync()
        {
            return Mapper.MapToDoListsToDTO(await _toDoListRepository.GetAll());
        }

        public async Task<List<ToDoListDTO>> GetToDoListForUserAsync(string email)
        {
            var toDoLists = await _toDoListRepository.Get(x => x.User.Email == email);

            return Mapper.MapToDoListsToDTO(toDoLists);
        }

        public async Task<ToDoListDTO> GetToDoListAsync(int toDoListId)
        {
            return Mapper.MapToDoListToDTO(await _toDoListRepository.GetById(toDoListId));
        }

        public async Task<ToDoListDTO> UpdateToDoListAsync(ToDoListDTO toDoList)
        {
            if (toDoList == null)
            {
                throw new ArgumentNullException(nameof(toDoList));
            }

            return Mapper.MapToDoListToDTO(await _toDoListRepository.UpdateData(Mapper.MapDTOToToDoList(toDoList)));
        }

        public async Task<ToDoListDTO> FinishToDoItemAsync(int id)
        {
            var todo = await _toDoListRepository.GetById(id);
            todo.IsFinished = true;

            return Mapper.MapToDoListToDTO(await _toDoListRepository.UpdateData(todo));
        }
    }
}
