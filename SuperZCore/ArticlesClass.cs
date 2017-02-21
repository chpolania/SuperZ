
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SuperZCore
{
    public interface IArticlesClass
    {
        List<SuperZEnt.Articles> ListArticles();
        int Save(SuperZEnt.Articles article);
        int Edit(SuperZEnt.Articles article);
        int Delete(int id);
    }
    public class ArticlesClass : IArticlesClass
    {
        public List<SuperZEnt.Articles> ListArticles()
        {
            List<SuperZEnt.Articles> lista = new List<SuperZEnt.Articles>();
            using (var superArticles = new SuperZapatosEntities2())
            {
                lista = superArticles.Articles.ToList();
            }
            return lista;
        }

        public int Save(SuperZEnt.Articles article)
        {
            int ret = 0;
            using (var superArticles = new SuperZapatosEntities2())
            {
                var art = superArticles.Articles
                    .Where(b => b.id == article.id)
                    .FirstOrDefault();
                if (art == null)
                {
                    superArticles.Articles.Add(article);
                    ret = superArticles.SaveChanges();
                }
                else
                {
                    ret = -1;
                }
            }
            return ret;
        }

        public int Edit(SuperZEnt.Articles article)
        {
            int ret = 0;
            using (var superArticles = new SuperZapatosEntities2())
            {
                SuperZEnt.Articles art = superArticles.Articles.First(x => x.id == article.id);
                art.id = article.id;
                art.name = article.name;
                art.description = article.description;
                art.price = article.price;
                art.store_id = article.store_id;
                art.total_in_vault = article.total_in_shelf;
                art.total_in_shelf = article.total_in_shelf;
                ret = superArticles.SaveChanges();
            }
            return ret;
        }

        public int Delete(int id)
        {
            int ret = 0;
            using (var superArticles = new SuperZapatosEntities2())
            {
                SuperZEnt.Articles art = superArticles.Articles.First(x => x.id == id);
                superArticles.Articles.Remove(art);
                ret = superArticles.SaveChanges();
            }
            return ret;
        }
    }
}
