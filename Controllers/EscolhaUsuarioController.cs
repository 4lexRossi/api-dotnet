using System;
using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolhaUsuarioController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<EscolhaUsuario> _escolhaUsuariosCollection;

        public EscolhaUsuarioController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _escolhaUsuariosCollection = _mongoDB.DB.GetCollection<EscolhaUsuario>(typeof(EscolhaUsuario).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarEscolhaUsuario([FromBody] EscolhaUsuarioDto dto)
        {
            var escolhaUsuario = new EscolhaUsuario(
                dto.Id,
                dto.Advogado,
                dto.Cliente                
            );

            _escolhaUsuariosCollection.InsertOne(escolhaUsuario);
            
            return StatusCode(201, "Cadastro concluido com sucesso");
        }

        [HttpGet]
        public ActionResult ObterEscolhaUsuarios()
        {
            var escolhaUsuarios = _escolhaUsuariosCollection.Find(Builders<EscolhaUsuario>.Filter.Empty).ToList();
            
            return Ok(escolhaUsuarios);
        }
        
        [HttpGet("{id}")]
        public ActionResult ObterEscolhaUsuario(string id)
        {
            var escolhaUsuario = _escolhaUsuariosCollection.Find(Builders<EscolhaUsuario>.Filter
            .Where(_ => _.Id == id)).FirstOrDefault();            

            return Ok(escolhaUsuario);
        }

        [HttpPut]
        public ActionResult AtualizarEscolhaUsuario([FromBody] EscolhaUsuarioDto dto)
        {
            _escolhaUsuariosCollection.UpdateOne(Builders<EscolhaUsuario>.Filter
            .Where(_ => _.Id == dto.Id),
            Builders<EscolhaUsuario>.Update.Set("advogado", dto.Advogado)
                                           .Set("cliente", dto.Cliente));                                    
            
             return Ok("Cadastro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarEscolhaUsuario(string id)
        {
            _escolhaUsuariosCollection.DeleteOne(Builders<EscolhaUsuario>.Filter
            .Where(_ => _.Id == id));
            
            
             return Ok("Cadastro deletado com sucesso");
        }
    }
}
