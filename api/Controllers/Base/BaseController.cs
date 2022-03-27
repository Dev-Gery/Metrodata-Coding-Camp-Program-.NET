using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<Entity> Get()
        {
            try
            {
                var result = repository.Get();
                if (result.Count() > 0)
                {
                    var response = new { Status = HttpStatusCode.OK, result, message = "Beberapa data ditemukan" };
                    return Ok(response);
                }
                else
                {
                    var response = new { Status = HttpStatusCode.NotFound, result, message = "Data tidak ditemukan" };
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                var response = new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            try
            {
                var result = repository.Get(key);
                if (result != null)
                    {
                    var response = new { Status = 200, result, Message = "Data ditemukan." };
                    return Ok(response);
                }
                else
                {
                    var response = new { Status = 404, result, Message = "Data tidak ditemukan." };
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<Entity> Post(Entity entity)
        {
            try
            {
                repository.Insert(entity);
                return Ok(new { Status = 200, Result = repository.Get(repository.GetKey(entity)), Message = "Data berhasil dimasukkan" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
        
        [HttpPut]
        public ActionResult<Entity> Put(Entity entity)
        {
            try
            {
                repository.Update(entity);
                var key = repository.GetKey(entity);
                var result = repository.Get(key);
                return Ok(new { Status = 200, Result = result, Message = "Data berhasil diubah" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ex.Message });
            }
        }

        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            try
            {
                var result = repository.Get(key);
                repository.Delete(key);
                return Ok(new { Status = 200, result, message = "Data terhapus" });
            }
            catch (Exception)
            {
                var result = repository.Get(key);
                return BadRequest(new { status = HttpStatusCode.BadRequest, result, message = "Data tidak ditemukan atau terjadi kesalahan" });
            }
        }

        [HttpDelete]
        public ActionResult<Entity> DeleteAll()
        {
            try
            {
                var result = repository.Get();
                repository.DeleteAll();
                return Ok(new { Status = 200, result, message = "Data-data yang muncul di hasil telah terhapus" });
            }
            catch (Exception)
            {
                var result = repository.Get();
                return BadRequest(new { status = HttpStatusCode.BadRequest, result, message = "Tidak ada data yang ditemukan atau terjadi kesalahan" });
            }
        }
    }
}
