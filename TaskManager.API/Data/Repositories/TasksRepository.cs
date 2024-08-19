using MongoDB.Driver;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IMongoCollection<Tasks> _tasks;

        public TasksRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _tasks = database.GetCollection<Tasks>("tarefas");
        }
        public void AddTasks(Tasks task)
        {
            _tasks.InsertOne(task);
        }

        public void Update(string id, Tasks taskUpdated)
        {
            _tasks.ReplaceOne(task => task.Id == id, taskUpdated);
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _tasks.Find(tasks => true).ToList();
        }

        public Tasks GetById(string id)
        {
            return _tasks.Find(tasks => tasks.Id == id).FirstOrDefault();
        }

        public void DeleteById(string id)
        {
           _tasks.DeleteOne(tasks => tasks.Id == id);
        }
    }
}
