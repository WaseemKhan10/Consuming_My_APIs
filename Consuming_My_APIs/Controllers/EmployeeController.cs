using Microsoft.AspNetCore.Mvc;
using Consuming_My_APIs.HelperClass;
using Consuming_My_APIs.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace Consuming_My_APIs.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeHelperClass EmployeHelper = new EmployeeHelperClass();
        public async Task<ActionResult> Index()
        {
            List<ModelEmployee> deptlist = new List<ModelEmployee>();
            //Getting Base Address
            HttpClient client = EmployeHelper.Initial();
            HttpResponseMessage res = await client.GetAsync("");
            if (res.IsSuccessStatusCode)
            {
                //Reading Data using HttpResponseMessage
                var result = res.Content.ReadAsStringAsync().Result;
                //Deserializing 
                deptlist = JsonConvert.DeserializeObject<List<ModelEmployee>>(result);
            }
            return View(deptlist);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ModelEmployee EmpModelObj)
        {
            HttpClient client = EmployeHelper.Initial();
            var postTask = client.PostAsJsonAsync<ModelEmployee>("", EmpModelObj);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.DeleteAsync("https://localhost:7104/api/ControllerEmployee/" + id);
                return RedirectToAction("Index");
            }
           catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var employeeModel_Variable = new List<ModelEmployee>();
            HttpClient getbaseaddress = new HttpClient();
            HttpResponseMessage res = await getbaseaddress.GetAsync("https://localhost:7104/api/ControllerEmployee/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result.ToString();
                employeeModel_Variable = JsonConvert.DeserializeObject<List<ModelEmployee>>(result);
            }
            return View(employeeModel_Variable);
        }

        [HttpPost]
        public IActionResult EditDetails(List<ModelEmployee> ModelEmployeeobj)
        {
            try
            {
                HttpClient Get_Address_Using_Helper_Class = EmployeHelper.Initial();
                var postTask = Get_Address_Using_Helper_Class.PutAsJsonAsync("", ModelEmployeeobj);
                postTask.Wait();
                var resultdata = postTask.Result;
                if (resultdata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception)
            {
                throw;
            }
            //Redirecting to Add View to Create new User
            return View("Add");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employeeModel_Variable = new List<ModelEmployee>();
            HttpClient get_base_address = new HttpClient();
            HttpResponseMessage responseMsg = await get_base_address.GetAsync("https://localhost:7104/api/ControllerEmployee/" + id);
            if (responseMsg.IsSuccessStatusCode)
            {
                var resultData = responseMsg.Content.ReadAsStringAsync().Result.ToString();
                employeeModel_Variable = JsonConvert.DeserializeObject<List<ModelEmployee>>(resultData);
            }
            return View(employeeModel_Variable);
        }
    }
}
