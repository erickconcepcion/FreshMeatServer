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
        public readonly IEntityBaseService<T> Service;
        public readonly string IncludedProperties;

        public EntityBaseApiController(IEntityBaseService<T> service, string includedProps = "")
        {
            Service = service;
            IncludedProperties = includedProps;
        }

        
        [HttpGet]
        public virtual IActionResult GetAllInclude(bool included = false)
        {

            var models = included ? Service.GetIncluding(IncludedProperties) : Service.Get();

            var result = Mapper.Map<IEnumerable<VM>>(models);
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id, bool included = false)
        {

            var model = included ? Service.Find(id, IncludedProperties) : Service.Find(id);
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
            Service.Add(model);

            if (!Service.Save())
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


            var find = Service.Find(id);
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
            
            Service.Update(model);

            if (!Service.Save())
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

            var find = Service.Find(id);

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

            Service.Update(model);

            if (!Service.Save())
            {
                return StatusCode(500, "Something was wrong on server");
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            var find = Service.Find(id);
            if (find == null)
            {
                return NotFound();
            }

            Service.Delete(find);

            if (!Service.Save())
            {
                return StatusCode(500, "Something was wrong on server");
            }

            return NoContent();
        }

    }
}
