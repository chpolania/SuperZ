using SuperZEnt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SuperZ.Controllers
{
    public class StoresController : Controller
    {
        // GET: Stores
        public ActionResult Index()
        {
            return View(GetaData<Stores>("/api/SuperZ/GetStoresList"));
        }

        // GET: Stores/Details/5
        public ActionResult Details(int id)
        {
            return View(GetaData<Stores>("/api/SuperZ/GetStoresList").Find(x => x.id == id));
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        public ActionResult Create(Stores model)
        {
            try
            {
                int stateTransaction = SaveDataInt<Stores>("api/SuperZ/SaveStore", model);
                if (stateTransaction != -1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Duplicate row id.");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetaData<Stores>("/api/SuperZ/GetStoresList").Find(x => x.id == id));
        }

        // POST: Stores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Stores model)
        {
            try
            {
                bool stateTransaction = SaveData<Stores>("api/SuperZ/EditStore", model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int id)
        {
            Stores ar = new Stores();
            ar.id = id;
            bool stateTransaction = SaveData<Stores>("api/SuperZ/DeleteStore", ar);
            return RedirectToAction("Index");
        }

        // POST: Stores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public List<T> GetaData<T>(string method)
        {
            List<T> ret = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apipath"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(method).Result;
                if (response.IsSuccessStatusCode)
                {
                    ret = response.Content.ReadAsAsync<List<T>>().Result;
                }
            }
            return ret;
        }

        public bool SaveData<T>(string method, T data)
        {
            string ret = string.Empty;
            using (var client = new HttpClient())
            {
                Uri urlInvocada = new Uri(ConfigurationManager.AppSettings["apipath"] + method);
                HttpResponseMessage response = client.PostAsync(urlInvocada.AbsoluteUri, data, new JsonMediaTypeFormatter()).Result;
                if (response.IsSuccessStatusCode)
                {
                    ret = response.Content.ReadAsAsync<string>().Result;
                }
            }

            return ret.ToUpper() == "TRUE" ? true : false;
        }

        public int SaveDataInt<T>(string method, T data)
        {
            string ret = string.Empty;
            using (var client = new HttpClient())
            {
                Uri urlInvocada = new Uri(ConfigurationManager.AppSettings["apipath"] + method);
                HttpResponseMessage response = client.PostAsync(urlInvocada.AbsoluteUri, data, new JsonMediaTypeFormatter()).Result;
                if (response.IsSuccessStatusCode)
                {
                    ret = response.Content.ReadAsAsync<string>().Result;
                }
            }

            return Convert.ToInt16(ret);
        }
    }
}
