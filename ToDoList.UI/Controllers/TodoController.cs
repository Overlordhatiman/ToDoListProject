using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.BL.DTO;
using ToDoList.BL.Interfaces;
using ToDoList.UI.Models;

namespace ToDoList.UI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly IUserService _userService;

        public ToDoController(IToDoListService toDoListService, IUserService userService)
        {
            _toDoListService = toDoListService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todoLists = await _toDoListService.GetToDoListForUserAsync(User.Identity.Name);

            return View(todoLists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Id,IsFinished")] ToDoListDTO todo)
        {
            todo.User = await _userService.GetUserAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                await _toDoListService.CreateToDoListAsync(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var todo = await _toDoListService.GetToDoListAsync((int)id);

            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoListService.DeleteToDoListAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _toDoListService.GetToDoListAsync((int)id);

            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Title,Description,Id,IsFinished")] ToDoListDTO todo)
        {
            if (todo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _toDoListService.UpdateToDoListAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _toDoListService.GetToDoListAsync((int)id);

            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }


        public async Task<IActionResult> Finish(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updatedToDoItem = await _toDoListService.FinishToDoItemAsync((int)id);

            if (updatedToDoItem == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
