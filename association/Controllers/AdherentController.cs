using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using association.Models;

namespace association.Controllers
{
    public class AdherentController : Controller
    {
       
        private Adherent alu = new Adherent();
       // public Adherent() => alu = new Adherent();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "List des Adherents";
            return View(alu.listar());
        }
        //[HttpPost]
        //public ActionResult Index(string nom_complet, string sexe, string num_tel, string Email, string password, DateTime date_naissance,
        //   DateTime date_inscr, int Villes, float paid, int role)
        //{
        //    if (alu.Insertar(nom_complet, sexe, num_tel, Email, password, date_naissance,
        //    date_inscr, Villes, paid, role))
        //    {
        //        ViewBag.alerta = "success";
        //        ViewBag.res = "Étudiant inscrit";
        //    }
        //    else
        //    {
        //        ViewBag.alerta = "danger";
        //        ViewBag.res = "Étudiant non inscrit";
        //    }
        //    return View(alu.listar());
        //}
        //public ActionResult add(int code_adherent)
        //{
        //    ViewBag.alerta = "info";
        //    ViewBag.res = "Ahouter l'adherent";
        //    return View(alu.un_registro(code_adherent));
        //}
        public ActionResult Edit(int code_adherent)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Mettre à jour l'adherent";
            return View(alu.un_registro(code_adherent));
        }
        [HttpPost]
        public ActionResult Edit(int code_adherent, string nom_complet, string sexe, string num_tel, string Email, string password, string date_naissance,
            DateTime date_inscr, int Villes, float paid, int role)
        {
            if (alu.Edit( code_adherent,  nom_complet,  sexe,  num_tel,  Email,  password,  date_naissance,
             date_inscr,  Villes,  paid,  role))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Données étudiantes mises à jour";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Une erreur s'est operation:( ";
            }
            return View(alu.un_registro(code_adherent));
        }
        public ActionResult Delete(int code_adherent)
        {
            if (alu.Delete(code_adherent))
            {
                return RedirectToAction("Index", "Adherent");
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "l'adherent est dans une section";
                return View(alu.un_registro(code_adherent));
            }
        }
    }
}