using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BL.DTO;

namespace ToDoList.BL.Interfaces
{
    public interface IToDoListService
    {
        public Task<ToDoListDTO> GetToDoListAsync(int Id);

        public Task<List<ToDoListDTO>> GetToDoListForUserAsync(string email);

        public Task<List<ToDoListDTO>> GetAllToDoListsAsync();

        public Task<ToDoListDTO> CreateToDoListAsync(ToDoListDTO todo);

        public Task<ToDoListDTO> UpdateToDoListAsync(ToDoListDTO todo);

        public Task<ToDoListDTO> DeleteToDoListAsync(int id);

        public Task<ToDoListDTO> FinishToDoItemAsync(int id);
    }
}
