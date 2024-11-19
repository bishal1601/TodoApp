using Microsoft.AspNetCore.Mvc;
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
        var dto = new TodoDto();
        dto.TaskTitle = vm.TaskTitle;
        dto.TaskDescription = vm.TaskDescription;
        _todoService.Create(dto);

        return RedirectToAction("Index");
        
    }
    
    public IActionResult GetTodos()
    {
        var todos = _todoRepository.GetAll();
        return View(todos);
    }

    public IActionResult Update(Guid getid)
    {
        var id = getid;
        
        var todos = _todoRepository.GetbyId(id);
        return View(todos);
    }

    public IActionResult Delete(Guid id)
    {
        return RedirectToAction("GetTodos");
    }
}