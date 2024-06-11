namespace API_Inventaire.Models
{
    public class Rooms
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ParcId { get; set; }
    }
}
