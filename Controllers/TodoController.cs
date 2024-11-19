using Microsoft.AspNetCore.Mvc;
using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Repositories.Interfaces;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Controllers;

public class TodoController : Controller
{
    public TodoController(
       ITodoService todoService,
       ITodoRepository todoRepository
    )
    {
        _todoService = todoService;
        _todoRepository = todoRepository;

    }
    public ITodoService _todoService { get; }
    public ITodoRepository _todoRepository { get; }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(TodoVm vm)
    {
        if (ModelState.IsValid)
        {
            var dto = new TodoDto
            {
                TaskTitle = vm.TaskTitle,
                TaskDescription = vm.TaskDescription
            };
            _todoService.Create(dto); 

            return RedirectToAction("GetTodos"); 
        }

        return View(vm); 
    }
    
    public IActionResult GetTodos()
    {
        var todos = _todoRepository.GetAll();
        return View(todos);
    }

    public IActionResult Update(Guid id)
    {
        var todo = _todoRepository.GetbyId(id);

        if (todo == null)
        {
            return NotFound();
        }

       
        return View((TodoDto)todo);
    }
    [HttpPost]
    public IActionResult Update(TodoDto dto)
    {
        if (ModelState.IsValid)
        {
            _todoService.Update(dto);
            return RedirectToAction("GetTodos");
        }

        return View(dto); 
    }

    

    public IActionResult Delete(Guid id)
    {
        var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            Database.Todos.Remove(todo);
            return RedirectToAction("GetTodos");
        }
        else
        {
            return NotFound();
        }
        
    }
}