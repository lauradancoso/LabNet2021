using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Entities;

namespace Practica.EF.Logic
{
    public class CategoriesContext : BaseLogic, IABM<Categories>
    {
        public void Add(Categories newT)
        {
            context.Categories.Add(newT);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var categorieToDelete = context.Categories.Find(id);
                context.Categories.Remove(categorieToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories updatedT)
        {
            try
            {
                var categorieToUpdate = context.Categories.Find(updatedT.CategoryID);
                
                categorieToUpdate.CategoryName = updatedT.CategoryName;
                categorieToUpdate.Description = updatedT.Description;
                categorieToUpdate.Picture = updatedT.Picture;

                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }  
    }
}
