using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreshMeatServer.Core
{
    [Route("api/[controller]")]
    public class EntityBaseApiController<T, VM> : Controller where T : class, IEntityBase, new() where VM : class, IViewModel, new()
    {
        public readonly IEntityBaseRepository<T> Db;
        public readonly string IncludedProperties;

        public EntityBaseApiController(IEntityBaseRepository<T> db, string includedProps = "")
        {
            Db = db;
            IncludedProperties = includedProps;
        }

        /*[HttpGet]
        public IActionResult GetAll()
        {

            var models = Db.Get();

            var result = Mapper.Map<IEnumerable<VM>>(models);
            return Ok(result.ToList());
        }*/

        [HttpGet]
        public virtual IActionResult GetAllInclude(bool included = false)
        {

            var models = included ? Db.GetIncluding(IncludedProperties) : Db.Get();

            var result = Mapper.Map<IEnumerable<VM>>(models);
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id, bool included = false)
        {

            var model = included ? Db.Find(id, IncludedProperties) : Db.Find(id);
            var vm = Mapper.Map<VM>(model); ;
            return Ok(vm);
        }
        
        [HttpPost]
        public virtual IActionResult Create([FromBody] VM vm)
        {
            if (vm == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            T model;
            try
            {
                model = Mapper.Map<T>(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            Db.Add(model);

            if (!Db.Save())
                return StatusCode(500, "Something was wrong on server");


            return Created(Request.Path + "/" + model.Id, model);
        }
        
        [HttpPut("{id}")]
        public virtual IActionResult Update(Guid id, [FromBody] VM vm)
        {

            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            //

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var find = Db.Find(id);
            if (find == null)
            {
                return NotFound();
            }
            //
            T model;
            try
            {
                model = Mapper.Map<T>(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            Db.Update(model);

            if (!Db.Save())
            {
                return StatusCode(500, "Something was wrong on server");
            }
            return NoContent();

        }

        
        [HttpPatch("{id}")]
        public virtual IActionResult Patch(Guid id, [FromBody] JsonPatchDocument<VM> vm)
        {
            if (id == Guid.Empty || vm == null)
            {
                return BadRequest();
            }

            var find = Db.Find(id);

            if (find == null)
            {
                return NotFound();
            }

            var toPatch = Mapper.Map<VM>(find);

            vm.ApplyTo(toPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = Mapper.Map<T>(toPatch);

            Db.Update(model);

            if (!Db.Save())
            {
                return StatusCode(500, "Something was wrong on server");
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            var find = Db.Find(id);
            if (find == null)
            {
                return NotFound();
            }

            Db.Delete(find);

            if (!Db.Save())
            {
                return StatusCode(500, "Something was wrong on server");
            }

            return NoContent();
        }

    }
}
