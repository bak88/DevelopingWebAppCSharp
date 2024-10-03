using Microsoft.AspNetCore.Mvc;

namespace lecture1._2_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController : ControllerBase
    {
        static Dictionary<string, string> data = new Dictionary<string, string>();

        [HttpPost(template: "Post")] // Создание
        public ActionResult Post(string key, string value)
        {
            try
            {
                data.Add(key, value);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpGet(template: "Get")] // Чтение
        public ActionResult<string> Get(string key)
        {
            if (data.ContainsKey(key))
                return Ok(data[key]);
            else
                return StatusCode(404);            
        }

        [HttpPut(template: "Put")] // Обновление если существует, иначе создает
        public ActionResult Put (string key, string value)
        {
            if (data.ContainsKey(key))            
                data[key] = value;
            else
                data.Add(key, value);
            return Ok();
        }

        [HttpPatch(template: "Patch")] // Обновление если существует
        public ActionResult Patch(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                return Ok();
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpDelete(template: "Delete")] // Удаление
        public ActionResult Delete(string key)
        {
            if (data.ContainsKey(key))
            {
                data.Remove(key);
                return Ok();
            }
            else
            {
                return StatusCode(404);
            }
        }
    }
}
