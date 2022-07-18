using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroClientes.Domain.EntitiesDTO
{
    public class ClienteDetalhesDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; } = new DateTime();
        public string cpf { get; set; }
        public string rg { get; set; }
        public List<TelefoneDTO> listaTelefones { get; set; } = new List<TelefoneDTO>();
        public List<EnderecoDTO> listaEnderecos { get; set; } = new List<EnderecoDTO>();
        public string facebook { get; set; }
        public string linkedin { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
    }
}
