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
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View(GetaData<Articles>("/api/SuperZ/GetArticlesList"));
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View(GetaData<Articles>("/api/SuperZ/GetArticlesList").Find(x => x.id == id));
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.store_id = new SelectList(GetaData<Stores>("/api/SuperZ/GetStoresList"),
                                        "id", "name");
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(Articles model)
        {
            try
            {
                int stateTransaction = SaveDataInt<Articles>("api/SuperZ/save", model);
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

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            var row = GetaData<Articles>("/api/SuperZ/GetArticlesList").Find(x => x.id == id);
            ViewBag.store_id = new SelectList(GetaData<Stores>("/api/SuperZ/GetStoresList"),
                                        "id", "name", row.store_id);
            return View(row);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Articles model)
        {
            try
            {
                bool stateTransaction = SaveData<Articles>("api/SuperZ/edit", model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            Articles ar = new Articles();
            ar.id = id;
            bool stateTransaction = SaveData<Articles>("api/SuperZ/delete", ar);
            return RedirectToAction("Index");
        }

        // POST: Articles/Delete/5
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
