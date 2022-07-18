using System;

namespace cadastroClientes.Domain.EntitiesDTO
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; } = new DateTime();
    }
}
