using Practica.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.MVC.Logic
{
    public class CategoriesLogic : BaseLogic, IABM<Categories>
    {
        public void Add(Categories newT)
        {
            try
            {
                context.Categories.Add(newT);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var categorieToDelete = context.Categories.Find(id);
                categorieToDelete.Products.Clear();
                context.SaveChanges();
                context.Categories.Remove(categorieToDelete);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Categories> GetAll()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Categories GetOne(int id)
        {
            return context.Categories.FirstOrDefault(c=>c.CategoryID == id);
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
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
