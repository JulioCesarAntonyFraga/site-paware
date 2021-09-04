using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaPaware.Data;
using SistemaPaware.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SistemaPaware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["Sucesso"] != null)
                ViewBag.Sucesso = TempData["Sucesso"];

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MensagemUsuario msg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bot = new TelegramBotClient("1966533906:AAGfqCxWug0Y8VkO05V-CLXCZpyALkUwTu8");
                    await bot.SendTextMessageAsync("-587563323", $"Nova Mensagem:\nNome do cliente: " +
                        $"{msg.Nome}\nEmail do cliente: {msg.Email}\nAssunto: {msg.Assunto}\nMensagem: {msg.Mensagem}");
                }
                catch (Exception e)
                {
                    ViewBag.Erro = $"Algum erro ocorreu! erro: {e}";

                    return View(msg);
                }

                TempData["Sucesso"] = "Mensagem enviada com sucesso!";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Não preencha todos os campos antes de enviar uma mensagem!";

            return View(msg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
