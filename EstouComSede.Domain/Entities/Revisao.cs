using System;
using System.Collections.Generic;
using System.Text;

namespace EstouComSede.Domain.Entities
{
    public class Revisao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    }
}
