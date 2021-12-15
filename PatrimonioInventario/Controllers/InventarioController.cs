using PatrimonioInventario.Models;
using PatrimonioInventario.Models.Data;
using PatrimonioInventario.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatrimonioInventario.Controllers
{
    public class InventarioController : Controller
    {
        EntityPatrimonioDB db = new EntityPatrimonioDB();

        public ActionResult Inicio(int Ubicacion = 99)
        {
            try
            {
                SqlParameter paramUbicacion = new SqlParameter("@Ubicacion", Ubicacion);
                var data = db.Database.SqlQuery<Inventario>("spGetRegistro_Filtro @Ubicacion", paramUbicacion).ToList();

                return View(data);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        //[HttpPost]
        //public ActionResult GetRegistro(int Ubicacion)
        //{
        //    try
        //    {
        //        SqlParameter paramUbicacion = new SqlParameter("@Ubicacion", Ubicacion);
        //        var data = db.Database.SqlQuery<Inventario>("spGetRegistro_Filtro @Ubicacion", paramUbicacion).ToList();

        //        return RedirectToAction("Inicio");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex);
        //    }
        //}

        public ActionResult Agregar(Inventario obj)
        {
            //GENERA LA LISTA DE ESTADOS
            List<Ubicacion> UbicacionList = db.Ubicacion.ToList();
            ViewBag.UbicacionList = new SelectList(UbicacionList, "UbicacionId", "NombreUbicacion");

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInventario(Inventario model)
        {
            try
            {
                Inventario obj = new Inventario();
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    model.Imagen = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    model.ImageFile.SaveAs(fileName);


                    obj.Id = model.Id;
                    obj.NoControl = model.NoControl;
                    obj.Descripcion = model.Descripcion;
                    obj.Marca = model.Marca;
                    obj.Modelo = model.Modelo;
                    obj.Serie = model.Serie;
                    obj.Resguardante = model.Resguardante;
                    obj.Color = model.Color;
                    obj.Placas = model.Placas;
                    obj.Observaciones = model.Observaciones;

                    //Listado de UBICACIONES
                    obj.UbicacionId = model.Ubicacion.UbicacionId;

                    obj.Creado = DateTime.Now;
                    obj.Imagen = model.Imagen;
                    obj.Status = true;


                    if (model.Id == 0)
                    {
                        db.Inventario.Add(obj);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                SqlParameter paramId = new SqlParameter("@InventarioId", Id);
                var db = new EntityPatrimonioDB();
                var data = db.Database.ExecuteSqlCommand("spDisable_Registro @InventarioId", paramId);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction("Inicio");
        }

        public JsonResult GetAreasList(int SecretariaId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Areas> AreasList = db.Areas.Where(x => x.SecretariaId == SecretariaId).ToList();
            return Json(AreasList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Historial()
        {
            return View();
        }
    }
}