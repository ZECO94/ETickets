using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class ActorMovies
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        
        public int MovieId { get; set; }
    }
}
