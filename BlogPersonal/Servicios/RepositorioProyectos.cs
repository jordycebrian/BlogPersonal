using BlogPersonal.Models;

namespace BlogPersonal.Servicios
{
    public class RepositorioProyectos:IRepositorioProyectos
    {
        public List<Proyectos> ObtenerProyectos()
        {
            return new List<Proyectos> 
            {
                new Proyectos {Titulo = "App Manejo Presupuestos",Descripcion = "Manage your finances with awareness and save your money", ImagenUrl="/Imagenes/proyecto1.png", Link="https://github.com/jordycebrian/ManejoPresupuestos"},
                new Proyectos {Titulo = "Farmacai Gomez",Descripcion = "Punto Venta Farmacia Gomez c#", ImagenUrl="/Imagenes/reddit.png", Link="https://github.com/jordycebrian/FarmaciaGomez"},
                new Proyectos {Titulo = "Api Magic Villa",Descripcion = "CRUD API Magic Villa", ImagenUrl="/Imagenes/steam.png", Link="https://github.com/jordycebrian/MagicVilla"},
                new Proyectos {Titulo = "Nyt",Descripcion = "Proyecto realizado en c#", ImagenUrl="/Imagenes/nyt.png", Link="https://nyt.com"},
            };
        }
    }
}
