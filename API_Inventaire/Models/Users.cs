namespace API_Inventaire.Models
{
    public class users
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool isenabled { get; set; }
        public DateTime createdat { get; set; }
        public DateTime? updatedat { get; set; }
    }
}
