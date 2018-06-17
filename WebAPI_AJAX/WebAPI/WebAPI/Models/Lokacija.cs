namespace WebAPI.Models
{
    public class Lokacija
    {
        public string adresa { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public Lokacija(string adresa, int x, int y)
        {
            this.adresa = adresa;
            this.x = x;
            this.y = y;
        }
    }
}