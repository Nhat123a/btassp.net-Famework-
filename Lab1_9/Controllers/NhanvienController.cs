using Lab1_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_9.Controllers
{
    public class NhanvienController : Controller
    {
        public static List<Nhanviencs> dsnv = new List<Nhanviencs>();
        // GET: Nhanvien
        public ActionResult Index()
        {

            return View(dsnv);
        }

        // GET: Nhanvien/Details/5
        public ActionResult Details(int id)
        {
            Nhanviencs nv = dsnv.FirstOrDefault(x => x.Manv == id);
            return View(nv);
        }

        // GET: Nhanvien/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nhanviencs nv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dsnv.Add(nv);
                    return RedirectToAction("Index");
                }
                return View(nv);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Nhanvien/Edit/5
        public ActionResult Edit(int id)
        {
            Nhanviencs nv = dsnv.FirstOrDefault(x => x.Manv == id);
            return View(nv);
        }

        // POST: Nhanvien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Nhanviencs nv)
        {
            Nhanviencs nhanvien = dsnv.FirstOrDefault(x => x.Manv == id);
            try
            {

                if (ModelState.IsValid)
                {
                    nhanvien.Hoten = nv.Hoten;
                    nhanvien.Gioitinh = nv.Gioitinh;
                    nhanvien.hSL = nv.hSL;
                    nhanvien.Phone = nv.Phone;
                    nhanvien.phong = nv.phong;
                    nhanvien.ngasinh = nv.ngasinh;
                    return RedirectToAction("Index");
                }
                return View(nv);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Nhanviencs nhanvien = dsnv.FirstOrDefault(x => x.Manv == id);

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Nhanviencs nhanvien = dsnv.FirstOrDefault(x => x.Manv == id);
                if (nhanvien != null)
                {
                    dsnv.Remove(nhanvien);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Luongcaonhat()
        {
            
            var item = dsnv.OrderByDescending(x => x.Luong).Take(2).ToList();
            if (item.Count == 0)
            {
                ViewBag.message = "Danh sách trống ";
            }
            return View(item);
        }
        //Tìm kiếm theo giới tính 
        public ActionResult Timkiem(string Gioitinh)
        {
            bool gioiTinhValue = Gioitinh == "Nam"; 
            var item = dsnv.Where(x => x.Gioitinh == gioiTinhValue).ToList();

            return View(item); 
        }
        //Theo tuổi
        public ActionResult Timkiemtuoi()
        {

            var danhSachNhanVien = dsnv
                .Where(x => (DateTime.Now - x.ngasinh).Days / 365 < 30).ToList();
            return View(danhSachNhanVien);

        }
        //Theo phòng
        public ActionResult Timkiemtheophong(string tenphong)
        {
            IEnumerable<Nhanviencs> item = null; 

            if (Enum.TryParse<Phong>(tenphong, out Phong phongEnum))
            {
                item = dsnv.Where(x => x.phong == phongEnum).ToList();
            }

            return View(item);
        }

    }
}
