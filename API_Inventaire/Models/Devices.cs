namespace API_Inventaire.Models
{
    public class Devices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MAC { get; set; }
        public string IP { get; set; }
        public string OS { get; set; }
        public bool IsEnable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int RoomId { get; set; }
    }
}

