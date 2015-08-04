﻿using prj_chamadosBRA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_chamadosBRA.Repositories
{
    public class ChamadoSubClassificacaoDAO
    {
        ApplicationDbContext db;
        public ChamadoSubClassificacaoDAO(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ChamadoSubClassificacaoDAO()
        {
            this.db = new ApplicationDbContext();
        }

        public List<ChamadoSubClassificacao> BuscarSubClassificacoes()
        {
            List<ChamadoSubClassificacao> subclassificacoes = (from e in db.ChamadoSubClassificacao select e).ToList();
            return subclassificacoes;
        }

        public ChamadoSubClassificacao BuscarSubClassificacao(int id)
        {
            ChamadoSubClassificacao subclassificacao = (from e in db.ChamadoSubClassificacao where e.Id == id select e).SingleOrDefault();
            return subclassificacao;
        }

        public List<ChamadoSubClassificacao> BuscarSubClassificacoesPorClassificacao(int idClassificacao)
        {
            List<ChamadoSubClassificacao> chamadoSubClassificacoes = (from e in db.ChamadoSubClassificacao where e.ChamadoClassificacao.Id == idClassificacao select e).ToList();
            return chamadoSubClassificacoes;
        }

        public Boolean salvarSubClassificacao(ChamadoSubClassificacao subclassificacao)
        {
            db.ChamadoSubClassificacao.Add(subclassificacao);
            db.SaveChanges();
            return true;
        }
    }
}