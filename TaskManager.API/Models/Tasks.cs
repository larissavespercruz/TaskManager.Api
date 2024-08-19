namespace TaskManager.API.Models
{
    public class Tasks
    {
        public Tasks(string name, string details)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Details = details;
            DateOfCreate = DateTime.Now;
            DateOfDone = null;
            Done = false;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Details { get; private set; }

        public bool Done { get; private set; }

        public DateTime DateOfCreate { get; private set; }

        public DateTime? DateOfDone { get; private set; }

        public void UpdateTasks(string name, string details, bool? done)
        {
            Name = name;
            Details = details;
            Done = done ?? false;
            DateOfDone = Done ? DateTime.Now : null;
        }
    }
}
