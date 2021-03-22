using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TranNgocTin_5851071074.Models;

namespace TranNgocTin_5851071074.Controllers
{
    public class HomeController : Controller
    {
        
        db dbop = new db();
        string msg;
        public IActionResult Index()
        {
            Employee emp = new Employee();
            emp.flag = "get";
            DataSet ds = new DataSet();
            ds = dbop.emGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in  ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    sr_no = Convert.ToInt32(dr["sr_no"]),
                    emp_name = dr["emp_name"].ToString(),
                    city = dr["city"].ToString(),
                    state = dr["state"].ToString(),
                    country = dr["country"].ToString(),
                    department = dr["department"].ToString(),
                });
            }
            return View(list);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] Employee emp)
        {
            try
            {
                emp.flag = "insert";
                dbop.empIU(emp, out msg);
                TempData["msg"] = msg;
            }catch(Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind] Employee emp)
        {
            try
            {
                emp.sr_no = id;
                emp.flag = "update";
                dbop.empIU(emp, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        
        public IActionResult Edit(int id)
        {
            Employee emp = new Employee();
            emp.sr_no = id;
            emp.flag = "getid";
            DataSet ds = dbop.emGet(emp, out msg);
            foreach( DataRow dr in ds.Tables[0].Rows)
            {
                emp.sr_no = Convert.ToInt32(dr["sr_no"]);
                emp.emp_name = dr["emp_name"].ToString();
                emp.city = dr["city"].ToString();
                emp.state  = dr["state"].ToString();
                emp.country = dr["country"].ToString();
                emp.department  = dr["department"].ToString();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(int id, [Bind] Employee emp)
        {
            try
            {
                emp.sr_no = id;
                emp.flag = "delete";
                dbop.emGet(emp, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return RedirectToAction("Index");
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
