using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Context;
using App.Models;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Apresentação_Alunos.Controllers
{
    public class RespostaController : Controller
    {
        private readonly AppDbContext _context;

        public RespostaController(AppDbContext context)
        {
            _context = context;
        }

        public string ObterIP()
        {
            string ip = "";
            // Get all network interfaces on the machine
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                    foreach (var ipAddress in ipProperties.UnicastAddresses)
                    {
                        if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ip = ipAddress.Address.ToString();
                        }
                    }
                }
            }
            return ip;
        }

        // GET: Resposta
        public async Task<IActionResult> Index()
        {
            /*
            List<Resposta> respostas = _context.Respostas.ToList();
            foreach (var resposta in respostas)
            {
                resposta.Sorteado = null;
                _context.Update(resposta);
            }
            _context.SaveChanges();
            */

            return _context.Respostas != null ?
                        View(await _context.Respostas.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Respostas'  is null.");
        }

        // GET: Resposta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Respostas == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .FirstOrDefaultAsync(m => m.RespostaId == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        public IActionResult Sorteio()
        {
            Random random = new Random();

            // Recupere todas as respostas do banco de dados para a memória
            List<Resposta> respostas = _context.Respostas.Where(x => x.Sorteado == null).ToList();

            if (!respostas.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            // Embaralhe a lista de respostas de forma aleatória
            respostas = respostas.OrderBy(x => random.Next()).ToList();

            // Se houver pelo menos uma resposta, selecione a primeira (aleatória) para a view
            Resposta respostaAleatoria = respostas.First();

            respostaAleatoria.Sorteado = true;
            _context.Update(respostaAleatoria);
            _context.SaveChanges();

            return View(respostaAleatoria);
        }



        // GET: Resposta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resposta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Resposta resposta)
        {

            if (!_context.Respostas.Where(resp => resp.IP == ObterIP()).Any())
            {
                resposta.IP = ObterIP();

                _context.Add(resposta);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Resposta");


        }

        // GET: Resposta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Respostas == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas.FindAsync(id);
            if (resposta == null)
            {
                return NotFound();
            }
            if (resposta.IP != ObterIP())
            {
                return RedirectToAction("Index", "Resposta");
            }
            else
            {
                return View(resposta);
            }

        }

        // POST: Resposta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RespostaId,Nome,Resp1,Resp2,Resp3,Resp4,Resp5,Resp6")] Resposta resposta)
        {
            if (id != resposta.RespostaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(resposta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaExists(resposta.RespostaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resposta);
        }

        // GET: Resposta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Respostas == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .FirstOrDefaultAsync(m => m.RespostaId == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Resposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Respostas == null)
            {
                return Problem("Entity set 'AppDbContext.Respostas'  is null.");
            }
            var resposta = await _context.Respostas.FindAsync(id);
            if (resposta != null)
            {
                _context.Respostas.Remove(resposta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaExists(int id)
        {
            return (_context.Respostas?.Any(e => e.RespostaId == id)).GetValueOrDefault();
        }
    }
}
