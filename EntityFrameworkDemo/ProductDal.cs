using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
   public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (EtradeContext context =new EtradeContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> GetbyName(string key)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> GetbyUnıtPrice(decimal price)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.UnıtPrice>=price).ToList();
            }

        }
        public List<Product> GetbyUnıtPrice(decimal min,decimal max)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.UnıtPrice>min && p.UnıtPrice<max  ).ToList();
            }

        }
        public Product GetbyId(int id)
        {
            using (EtradeContext context = new EtradeContext())
            {  var result =context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }
        public void Add(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

        }

        public void Update(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);//gönderilen product ı  veritabanındakiyle eşitliyor
               entity.State = EntityState.Modified;//entity durumunu güncellendi olarak işaretliyor ve ekliyor.
               context.SaveChanges();
            }

        }
        public void Delete(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


    }
}
