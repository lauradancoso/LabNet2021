using Practica.MVC.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica.MVC.Logic
{
    public class CategoriesLogic : BaseLogic, IABM<Categories>
    {
        public void Add(Categories newT)
        {
            context.Categories.Add(newT);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categorieToDelete = context.Categories.Find(id);
            categorieToDelete.Products.Clear();
            context.SaveChanges();
            context.Categories.Remove(categorieToDelete);
            context.SaveChanges();

        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }
        public Categories GetOne(int id)
        {
            return context.Categories.FirstOrDefault(c=>c.CategoryID == id);
        }

        public void Update(Categories updatedT)
        {
            var categorieToUpdate = context.Categories.Find(updatedT.CategoryID);

            categorieToUpdate.CategoryName = updatedT.CategoryName;
            categorieToUpdate.Description = updatedT.Description;
            categorieToUpdate.Picture = updatedT.Picture;

            context.SaveChanges();

        }
    }
}
