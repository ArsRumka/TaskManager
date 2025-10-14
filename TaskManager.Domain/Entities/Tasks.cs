namespace TaskManager.Domain.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateAt { get; set; }

        public Tasks() { }

        public Tasks(string title, string description)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
            CreateAt = DateTime.Now;
        }

    }
}
