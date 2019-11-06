using EstouComSede.Domain.Entities;
using EstouComSede.Repository.Interface;
using EstouComSede.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstouComSede.Service.Concrete
{
    public class RevisaoService : IRevisaoService
    {
        private readonly IRevisaoRepository revisaoRepository;

        public RevisaoService(IRevisaoRepository _revisaoRepository)
        {
            revisaoRepository = _revisaoRepository;
        }

        public RetornoRevisao Aprovar(int id)
        {
            return revisaoRepository.Approve(id);
        }

        public RetornoRevisao Inserir(Revisao solicitacao)
        {
            return revisaoRepository.Insert(solicitacao);
        }

        public List<Revisao> ObterTodas()
        {
            return revisaoRepository.GetAll();
        }

        public RetornoRevisao Recusar(int id)
        {
            return revisaoRepository.Reprove(id);
        }
    }
}
