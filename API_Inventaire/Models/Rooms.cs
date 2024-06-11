namespace API_Inventaire.Models
{
    public class rooms
    {

        public int id { get; set; }
        public string name { get; set; }
        public bool isenabled { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public int parcid { get; set; }
    }
}
