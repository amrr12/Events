using Microsoft.Extensions.Logging;

namespace Events.Models
{
    public class Owner : User
    {
       

        public virtual ICollection<Show>? Shows { get; set; } = new List<Show>();
    }
}
