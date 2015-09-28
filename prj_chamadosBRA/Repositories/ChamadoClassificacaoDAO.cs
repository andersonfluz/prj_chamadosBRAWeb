﻿using prj_chamadosBRA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_chamadosBRA.Repositories
{
    public class ChamadoClassificacaoDAO
    {
        ApplicationDbContext db;
        public ChamadoClassificacaoDAO(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ChamadoClassificacaoDAO()
        {
            this.db = new ApplicationDbContext();
        }

        public ChamadoClassificacao BuscarClassificacao(int id)
        {
            ChamadoClassificacao classificacao = (from e in db.ChamadoClassificacao where e.Id == id select e).SingleOrDefault();
            return classificacao;
        }

        public List<ChamadoClassificacao> BuscarClassificacoes()
        {
            List<ChamadoClassificacao> classificacoes = (from e in db.ChamadoClassificacao select e).ToList();
            return classificacoes;
        }

        public List<ChamadoClassificacao> BuscarClassificacoesPorObra(Obra obra)
        {
            List<ChamadoClassificacao> classificacoes = (from e in db.ChamadoClassificacao where e.Obra.IDO == obra.IDO select e).ToList();
            return classificacoes;
        }

        public List<ChamadoClassificacao> BuscarClassificacoesPorObras(List<Obra> obras)
        {
            List<int> idObras = (from e in obras select e.IDO).ToList();
            List<ChamadoClassificacao> classificacoes = (from e in db.ChamadoClassificacao where idObras.Contains(e.Obra.IDO) select e).ToList();
            return classificacoes;
        }

        public Boolean salvarClassificacao(ChamadoClassificacao classificacao)
        {
            db.ChamadoClassificacao.Add(classificacao);
            db.SaveChanges();
            return true;
        }

        public void atualizarClassificacao(int id, ChamadoClassificacao classificacao)
        {
            try
            {
                ChamadoClassificacao classificacaoUpdate = (from e in db.ChamadoClassificacao where e.Id == id select e).SingleOrDefault();
                classificacaoUpdate.Descricao = classificacao.Descricao;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}