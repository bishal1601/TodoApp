using System.ComponentModel.DataAnnotations.Schema;
using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Services;

public class TodoService: ITodoService
{
    public void Create(TodoDto dto)
    {
        dto.Id = Guid.NewGuid();
        dto.TaskDate = DateTime.Now;
        Database.Todos.Add(dto);
    }
}