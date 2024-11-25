using TodoApplication.Models;

namespace TodoApplication.Services.Interfaces;

public interface ITodoService
{
    void Create(TodoDto dto); 
    void Update(TodoDto dto); 
    void Delete(Guid id);
    void UpdateStatus(Guid id);
}