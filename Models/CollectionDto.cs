using System;

namespace Api.Models
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }        

    } 
    public class ProcessoDto
    {
        public string Id { get; set; }
        public string NomeCliente { get; set; }
        public string NumProcesso { get; set; }
        public DateTime DataDecisao { get; set; }
        public string Descricao { get; set; }
        public string ProximoPasso { get; set; }
        public string LinkProcesso { get; set; }

    }public class EscolhaUsuarioDto
    {
        public string Id { get; set; }        
        public string Advogado { get; set; }
        public string Cliente { get; set; }        
        
    }
}