using Microsoft.AspNetCore.Mvc;
using Papelaria.Database;
using papelaria.Models;

namespace Papelaria.Controllers
{
    [ApiController]
    [Route("api/cargo")]
    public class CargoController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Cargo cargo)
        {
            CargoDB cargoDB = new CargoDB();
            bool response = cargoDB.Add(cargo);

            if (response)
            {
                return new JsonResult(new { success = true, data = "Cargo cadastrado com sucesso!" });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Erro ao cadastrar o cargo." });
            }
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get(int id)
        {
            CargoDB cargoDB = new CargoDB();
            Cargo cargo = cargoDB.Get(id);

            if (cargo != null && cargo.Id > 0)
            {
                return new JsonResult(new { success = true, data = cargo });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Cargo não encontrado." });
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            CargoDB cargoDB = new CargoDB();
            List<Cargo> cargos = cargoDB.GetAll();

            if (cargos.Count > 0)
            {
                return new JsonResult(new { success = true, data = cargos });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Nenhum cargo encontrado." });
            }
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Cargo cargo)
        {
            CargoDB cargoDB = new CargoDB();
            bool response = cargoDB.Update(cargo);

            if (response)
            {
                return new JsonResult(new { success = true, data = "Cargo atualizado com sucesso!" });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Erro ao atualizar o cargo." });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            CargoDB cargoDB = new CargoDB();
            bool response = cargoDB.Delete(id);

            if (response)
            {
                return new JsonResult(new { success = true, data = "Cargo deletado com sucesso!" });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Erro ao deletar o cargo." });
            }
        }
    }
}
