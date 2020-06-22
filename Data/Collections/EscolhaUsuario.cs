namespace Api.Data.Collections
{
    public class EscolhaUsuario
    {
         public EscolhaUsuario(
            string id,
            string advogado,
            string cliente            
            )
        {            
            this.Advogado = advogado;
            this.Cliente = cliente;           
        }
        public string Id { get; set; }
        public string Advogado { get; set; }
        public string Cliente { get; set; }
    } 
       
}