using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SuperZCore
{
    public interface IStoresClass
    {
        List<SuperZEnt.Stores> ListStores();
        int Save(SuperZEnt.Stores store);
        int Edit(SuperZEnt.Stores store);
        int Delete(int id);
    }
    public class StoresClass : IStoresClass
    {
        public List<SuperZEnt.Stores> ListStores()
        {
            List<SuperZEnt.Stores> lista = new List<SuperZEnt.Stores>();
            using (var superStores = new SuperZapatosEntities2())
            {
                lista = superStores.Stores.ToList();
            }
            return lista;
        }

        public int Save(SuperZEnt.Stores store)
        {
            int ret = 0;
            using (var superStores = new SuperZapatosEntities2())
            {
                
                var stor = superStores.Stores
                    .Where(b => b.id == store.id)
                    .FirstOrDefault();

                if (stor == null)
                {
                    superStores.Stores.Add(store);
                    ret = superStores.SaveChanges();
                }
                else
                {
                    ret = -1;
                }
            }
            return ret;
        }

        public int Edit(SuperZEnt.Stores store)
        {
            int ret = 0;
            using (var superStores = new SuperZapatosEntities2())
            {
                SuperZEnt.Stores art = superStores.Stores.First(x => x.id == store.id);
                art.id = store.id;
                art.name = store.name;
                art.address = store.address;
                ret = superStores.SaveChanges();
            }
            return ret;
        }

        public int Delete(int id)
        {
            int ret = 0;
            using (var superStores = new SuperZapatosEntities2())
            {
                SuperZEnt.Stores art = superStores.Stores.First(x => x.id == id);
                superStores.Stores.Remove(art);
                ret = superStores.SaveChanges();
            }
            return ret;
        }
    }
}
