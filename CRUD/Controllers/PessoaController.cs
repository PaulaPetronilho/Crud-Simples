using Projeto_CRUD.Models;
using System.Web.Mvc;

namespace Projeto_CRUD.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository respository = new PessoaRepository();
        // GET: Pessoa
        public ActionResult Index()
        {
            return View(respository.GetAll());
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                respository.Save(pessoa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            
            var pessoa = respository.GetById(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return View("Edit", pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                respository.Update(pessoa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            respository.DeleteById(id);
            return Json(respository.GetAll());
        }
    }

}
