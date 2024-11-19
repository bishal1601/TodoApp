using TodoApplication.Models;

namespace TodoApplication.Services.Interfaces;

public interface ITodoService
{
    void Create(TodoDto dto);
}