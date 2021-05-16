using Practica.MVC.Entities;
using Practica.MVC.Logic;
using Practica.MVC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Practica.MVC.WebAPI.Controllers
{
    [EnableCors(origins:"http://localhost:4200", headers:"*",methods:"*")]
    public class CategoriesController : ApiController
    {
        CategoriesLogic logic = new CategoriesLogic();

        public IHttpActionResult Get()
        {
            try
            {
                List<Categories> categories = logic.GetAll();
                List<CategoriesRequest> categoriesRequest = categories.Select(c => new CategoriesRequest
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

                CategoriesRequest categoryRequest = new CategoriesRequest
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
        public IHttpActionResult Post([FromBody] CategoriesRequest categoryRequest)
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
        public IHttpActionResult Edit([FromBody] CategoriesRequest categoryRequest)
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
