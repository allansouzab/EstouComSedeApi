using EstouComSede.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstouComSede.Repository.Interface
{
    public interface IRevisaoRepository
    {
        List<Revisao> GetAll();
        RetornoRevisao Insert(Revisao solicitacao);
        RetornoRevisao Approve(int id);
        RetornoRevisao Reprove(int id);
    }
}