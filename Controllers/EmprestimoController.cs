﻿using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDBContext _db;
    public EmprestimoController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprstimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprstimos.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id ==null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprstimos.FirstOrDefault(x => x.Id==id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo) 
        {
            if (ModelState.IsValid)
            {
                _db.Emprstimos.Update(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }
        [HttpGet]
        public IActionResult Excluir (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprstimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimo)
        {
            if(emprestimo ==null)
            {
                return NotFound();
            }
            _db.Emprstimos.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
