using Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos;
using Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Icp.Arcipreste.NuevoCliente.Imagenes.Negocio
{
    public class ImagenesService: IImagenesService
    {
        private ImagenesDbContext imagenesCtx { get; set; } 

        public ImagenesService(ImagenesDbContext imagenesCtx)
        {
            this.imagenesCtx = imagenesCtx;
        }

        public async Task<Imagen> GetImagen(int id_articulo)
        {
            try
            {
                var imagen = await imagenesCtx.Imagen.FirstOrDefaultAsync(x => x.ID_ARTICULO == id_articulo);

                if ( imagen == null)
                {
                    throw new Exception("No existe imagen para este artículo");
                }

                return imagen;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
