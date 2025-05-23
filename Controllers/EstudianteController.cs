﻿using Microsoft.AspNetCore.Mvc;
using MonolitoTaller.Models.DAO;
using MonolitoTaller.Models.Entities;
using MonolitoTaller.Models.ViewModels;

namespace MonolitoTaller.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly EstudianteDAO dao;

        public EstudianteController(IConfiguration config)
        {
            dao = new EstudianteDAO(config);
        }

        public IActionResult Index()
        {
            var estudiantes = dao.ObtenerTodos();
            return View(estudiantes);
        }

        public IActionResult Details(int id)
        {
            // Obtener Estudiante
            var estudiante = dao.ObtenerPorId(id); 
            if (estudiante == null) return NotFound();

            // Obtener las asignaturas y las notas del estudiante
            var asignaturasNotas = dao.ObtenerAsignaturasYNotasPorEstudiante(id);

            // Crear un modelo para enviar a la vista
            var modelo = new EstudianteDetalleViewModel
            {
                Estudiante = estudiante,
                AsignaturasNotas = asignaturasNotas
            };

            return View(modelo);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                dao.Crear(estudiante);
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public IActionResult Edit(int id)
        {
            var estudiante = dao.ObtenerPorId(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                dao.Actualizar(estudiante);
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public IActionResult Delete(int id)
        {
            var estudiante = dao.ObtenerPorId(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            dao.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
