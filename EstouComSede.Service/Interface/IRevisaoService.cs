using EstouComSede.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstouComSede.Service.Interface
{
    public interface IRevisaoService
    {
        List<Revisao> ObterTodas();
        RetornoRevisao Inserir(Revisao solicitacao);
        RetornoRevisao Aprovar(int id);
        RetornoRevisao Recusar(int id);
    }
}
