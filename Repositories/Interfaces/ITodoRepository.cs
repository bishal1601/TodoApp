using TodoApplication.Models;

namespace TodoApplication.Repositories.Interfaces;

public interface ITodoRepository
{
    List<TodoDto> GetAll();
    List<TodoDto> GetbyId(Guid id);
}