using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperZCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SuperZApi.Controllers
{
    public class SuperZController : ApiController
    {
        [Route("services/articles", Name = "articles")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public JToken GetArticlesList2()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            try {
                
                IArticlesClass article = new ArticlesClass();
                var lst = article.ListArticles();
                res.Add("articles", Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));
                res.Add("success", "true");
                res.Add("total_elements", lst.Count().ToString());
                
            }
            catch (WebException ex) {

                string a = HttpStatusCode.NotFound.ToString();
                var resp = (HttpWebResponse)ex.Response;
                res.Add("success", "false");
                res.Add("error_code", Convert.ToInt32(resp.StatusCode).ToString());
                res.Add("ERROR_MESSAGE", ex.Message);
            }

            return JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(res, Formatting.Indented));
        }

        [Route("services/stores", Name = "stores")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public JToken GetStoresList2()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            try
            {

                IStoresClass store = new StoresClass();
                var lst = store.ListStores();
                res.Add("stores", Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));
                res.Add("success", "true");
                res.Add("total_elements", lst.Count().ToString());

            }
            catch (WebException ex)
            {

                string a = HttpStatusCode.NotFound.ToString();
                var resp = (HttpWebResponse)ex.Response;
                res.Add("success", "false");
                res.Add("error_code", Convert.ToInt32(resp.StatusCode).ToString());
                res.Add("ERROR_MESSAGE", ex.Message);
            }

            return JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(res, Formatting.Indented));
        }

        [Route("services/stores/{id}", Name = "storesid")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public JToken GetStoresList2(int id)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            try
            {
                IStoresClass store = new StoresClass();
                var lst = new List<SuperZEnt.Stores> { store.ListStores().Find(x => x.id == id)};
                res.Add("stores", Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));
                res.Add("success", "true");
                res.Add("total_elements", lst.Count().ToString());

            }
            catch (WebException ex)
            {

                string a = HttpStatusCode.NotFound.ToString();
                var resp = (HttpWebResponse)ex.Response;
                res.Add("success", "false");
                res.Add("error_code", Convert.ToInt32(resp.StatusCode).ToString());
                res.Add("ERROR_MESSAGE", ex.Message);
            }

            return JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(res, Formatting.Indented));
        }


        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public List<SuperZEnt.Articles> GetArticlesList()
        {
            IArticlesClass article = new ArticlesClass();
            return article.ListArticles();
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public int Save(SuperZEnt.Articles article)
        {
            IArticlesClass art = new ArticlesClass();
            return art.Save(article);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool Edit(SuperZEnt.Articles article)
        {
            IArticlesClass art = new ArticlesClass();
            return art.Edit(article) > 0 ? true : false;
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool Delete(SuperZEnt.Articles article)
        {
            IArticlesClass art = new ArticlesClass();
            return art.Delete(article.id) > 0 ? true : false;
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public List<SuperZEnt.Stores> GetStoresList()
        {
            IStoresClass article = new StoresClass();
            return article.ListStores();
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public int SaveStore(SuperZEnt.Stores article)
        {
            IStoresClass art = new StoresClass();
            return art.Save(article);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool EditStore(SuperZEnt.Stores article)
        {
            IStoresClass art = new StoresClass();
            return art.Edit(article) > 0 ? true : false;
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool DeleteStore(SuperZEnt.Stores article)
        {
            IStoresClass art = new StoresClass();
            return art.Delete(article.id) > 0 ? true : false;
        }
    }
}