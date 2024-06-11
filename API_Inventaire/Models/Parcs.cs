namespace API_Inventaire.Models
{
    public class Parcs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
    }
}
