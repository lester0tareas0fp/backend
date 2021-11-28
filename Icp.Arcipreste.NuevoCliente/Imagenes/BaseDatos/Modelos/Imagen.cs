using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos.Modelos
{
    public class Imagen
    {
        [Key]
        public int ID_IMAGEN { get; set; }
        public int ID_ARTICULO { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
        public string IMAGEN { get; set; }
        public string FORMATO { get; set; }
    }
}
