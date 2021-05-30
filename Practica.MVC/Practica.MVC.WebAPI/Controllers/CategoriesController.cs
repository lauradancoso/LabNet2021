using Practica.MVC.Entities;
using Practica.MVC.Logic;
using Practica.MVC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Practica.MVC.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesLogic logic = new CategoriesLogic();

        public IHttpActionResult Get()
        {
            try
            {
                List<Categories> categories = logic.GetAll();
                List<CategoriesResponse> categoriesRequest = categories.Select(c => new CategoriesResponse
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description

                }).ToList();

                return Ok(categoriesRequest);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
        }

        public IHttpActionResult Get(int id)
        {
            
            try
            {
                Categories category = logic.GetOne(id);

                if (category == null) {
                    return NotFound();
                }

                CategoriesResponse categoryRequest = new CategoriesResponse
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description

                };

                return Ok(categoryRequest);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CategoriesResponse categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Categories categoryEntity = new Categories
                {
                    CategoryName = categoryRequest.CategoryName,
                    Description = categoryRequest.Description
                };
                logic.Add(categoryEntity);

                return Ok();

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult Edit([FromBody] CategoriesResponse categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Categories categoryEntity = new Categories
                {
                    CategoryID = categoryRequest.CategoryID,
                    CategoryName = categoryRequest.CategoryName,
                    Description = categoryRequest.Description
                };
                logic.Update(categoryEntity);

                return Ok();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
