namespace API_Inventaire.Models
{
    public class devices
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mac { get; set; }
        public string ip { get; set; }
        public string os { get; set; }
        public bool isenabled { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public int roomid { get; set; }
    }
}

