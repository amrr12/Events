namespace Events.Models
{
    public class Application
    { 
        public int Id { get; set; }
        public virtual Performer Performer { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
        public int PerformerId { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
