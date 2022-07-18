using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cadastroClientes.Infra.CrossCutting.Validations.Validation
{
    public static class NameValidation
    {
        public static StatusValidation IsValidName(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                return new StatusValidation
                {
                    valido = false,
                    mensagem = "Por favor, digite um nome.",
                };

            }
            if (nome.Length > 50)
            {
                return new StatusValidation
                {
                    valido = false,
                    mensagem = "O nome não pode conter mais de 50 caracteres.",
                };

            }
            for (int i = 0; i < nome.Length; i++)
            {
                if (Regex.IsMatch(nome[i].ToString(), @"^[0-9]+$") == true)
                {
                    return new StatusValidation
                    {
                        valido = false,
                        mensagem = "O nome não pode conter caracteres especiais e nem números.",
                    };

                }
            }
            return new StatusValidation
            {
                valido = true,
                mensagem = "",
            };

        }

    }
}
