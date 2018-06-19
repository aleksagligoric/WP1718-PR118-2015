namespace WebAPI.Models
{
    public class Lokacija
    {
        public Adresa adresa { get; set; }

        public double x { get; set; }
        public double y { get; set; }

        public Lokacija(Adresa adresa, double x, double y)
        {
            this.adresa = adresa;
            this.x = x;
            this.y = y;
        }
        public Lokacija() { }
    }
}