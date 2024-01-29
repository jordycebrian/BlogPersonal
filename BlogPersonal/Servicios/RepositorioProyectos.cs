using BlogPersonal.Models;

namespace BlogPersonal.Servicios
{
    public class RepositorioProyectos:IRepositorioProyectos
    {
        public List<Proyectos> ObtenerProyectos()
        {
            return new List<Proyectos> 
            {
                new Proyectos {Titulo = "Amazon",Descripcion = "Proyecto tienda online para amazon relizado en c#", ImagenUrl="/Imagenes/amazon.png", Link="https://amazon.com"},
                new Proyectos {Titulo = "Reedit",Descripcion = "Red Social relizado en c#", ImagenUrl="/Imagenes/reddit.png", Link="https://reddit.com"},
                new Proyectos {Titulo = "Steam",Descripcion = "Proyecto tienda de videojuegos en c#", ImagenUrl="/Imagenes/steam.png", Link="https://store.steampowered.com/"},
                new Proyectos {Titulo = "Nyt",Descripcion = "Proyecto realizado en c#", ImagenUrl="/Imagenes/nyt.png", Link="https://nyt.com"},
            };
        }
    }
}
