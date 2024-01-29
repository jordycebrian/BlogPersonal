using BlogPersonal.Models;
using BlogPersonal.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Diagnostics;

namespace BlogPersonal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly EmailSettings _emailSettings;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IOptions<EmailSettings> emailSettings)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this._emailSettings = emailSettings.Value;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new ProyectosLista()
            {
                Proyectos = proyectos,
            };


            return View(modelo);
        }

        [HttpPost]
        public IActionResult Contacto(Contacto pContacto)
        {
            var email = _emailSettings.Email;
            var password = _emailSettings.Password;
            if (ModelState.IsValid)
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(pContacto.Nombre,pContacto.Email));
                emailMessage.To.Add(new MailboxAddress("Jordy Rodriguez", "cebrian1313@gmail.com"));
                emailMessage.Subject = "Nuevo mensaje de contacto";
                emailMessage.Body = new TextPart("plain"){
                    Text = $"Nombre : {pContacto.Nombre}\nCorreo electronico : {pContacto.Email}\nMensaje : {pContacto.Mensaje}"
                };


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    if(email != null && password != null)
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate(email, password);
                        client.Send(emailMessage);
                        client.Disconnect(true);
                    }
                    else
                    {
                        return RedirectToAction("ErrorVista");
                    }
                }


                return View("EmailEnviado");
            }


            return View(pContacto);
        }

        public IActionResult EmailEnviado()
        {
            return View();
        }

        public IActionResult ErrorVista()
        {
            return View();
        }

        public IActionResult DescargarCV()
        {
            var rutaCV = Path.Combine("wwwroot","Recursos","MY_CV.pdf");

            var tipoMime = "applicaction/pdf";

            var nombreDescarga = "MY_CV.pdf";

            return File(System.IO.File.ReadAllBytes(rutaCV), tipoMime, nombreDescarga);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}