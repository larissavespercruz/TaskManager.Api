namespace TaskManager.API.Models.InputModels
{
    public class TasksInputModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public bool? Done { get; set; }
    }
}
