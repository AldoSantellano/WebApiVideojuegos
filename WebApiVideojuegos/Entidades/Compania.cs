namespace WebApiVideojuegos.Entidades
{
    public class Compania
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public List<Videojuego> videojuegos { get; set; }

    }
}
