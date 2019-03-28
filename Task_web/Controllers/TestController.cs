using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_web.Models;

namespace Task_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IList<TestModel> _testModels;

        public TestController(IList<TestModel> testModels)
        {
            _testModels = testModels;
        }

        /*
        *
        * необходимо релизовать CRUD для testModels
        *
        */

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="_name">Имя объекта</param>
        /// <returns>Ответ с созданным объектом</returns>
        [HttpPost]
        public ActionResult<TestModel> Create(string _name)
        {
            TestModel item = new TestModel { Id = Guid.NewGuid(), Name = _name };
            _testModels.Add(item);

            return CreatedAtRoute("GetItem", item);
        }

        /// <summary>
        /// Получить объект
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Объект запроса</returns>
        [HttpGet(Name = "GetItem")]
        public IActionResult Get(Guid id)
        {
            var item = _testModels.Where(i => i.Id == id).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        /// <summary>
        /// Обновить объект
        /// </summary>
        /// <param name="_id">Идентификатор объекта</param>
        /// <param name="_newName">Новое имя объекта</param>
        /// <returns>Результат запроса</returns>
        [HttpPut]
        public IActionResult Update(Guid _id, string _newName)
        {
            if (_id == Guid.Empty || string.IsNullOrEmpty(_newName))
            {
                return BadRequest();
            }

            if (_testModels is List<TestModel>)
            {
                int index = (_testModels as List<TestModel>).FindIndex(a => a.Id == _id);

                if (index < 0)
                {
                    return NotFound();
                }

                _testModels[index].Name = _newName;
            }
            else
                return BadRequest();

            return new NoContentResult();
        }

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="_id">Идентификатор объекта</param>
        /// <returns>Результат запроса</returns>
        [HttpDelete]
        public IActionResult Delete(Guid _id)
        {
            if (_testModels is List<TestModel>)
            {
                int index = (_testModels as List<TestModel>).FindIndex(a => a.Id == _id);

                if (index < 0)
                {
                    return NotFound();
                }

                _testModels.RemoveAt(index);
            }
            else
                return BadRequest();

            return new NoContentResult();
        }
    }
}