using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public interface ITasksRepository
    {
        void AddTasks(Tasks task);

        void Update(string id, Tasks taskUpdated);

        IEnumerable<Tasks> GetAll();
        Tasks GetById(string id);

        void DeleteById(string id);

    }
}
