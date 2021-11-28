using Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Imagenes.Negocio
{
    public interface IImagenesService
    {
        Task<Imagen> GetImagen(int id_articulo); 
    }
}
