namespace WebApiVideojuegos.Entidades
{
    public class Videojuego
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int CompaniaID { get; set; }
        public Compania Compania { get; set; }

    }
}
