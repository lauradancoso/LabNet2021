﻿using Practica.MVC.Entities;
using Practica.MVC.Logic;
using Practica.MVC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Practica.MVC.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesLogic logic = new CategoriesLogic();

        public IEnumerable<CategoriesRequest> Get()
        {
            List<Categories> categories = logic.GetAll();
            List<CategoriesRequest> categoriesRequest = categories.Select(c => new CategoriesRequest
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description

            }).ToList();

            return categoriesRequest;
        }

        public CategoriesRequest Get(int id)
        {
            
            try
            {
                Categories category = logic.GetOne(id);

                if (category == null) {
                    return null;
                    //Esto estaría correcto? o debería retornar un IHTTResult en vez de Categories y hacer como el resto? no sé..
                }

                CategoriesRequest categoryRequest = new CategoriesRequest
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description

                };

                return categoryRequest;
            }
            catch (Exception)
            {

                return null;
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

                return Ok(categoryEntity);

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

                return Ok(categoryEntity);

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
    }
}
