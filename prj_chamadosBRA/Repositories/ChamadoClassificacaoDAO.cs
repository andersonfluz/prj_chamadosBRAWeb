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

        public List<ChamadoClassificacao> BuscarClassificacoes()
        {
            List<ChamadoClassificacao> classificacoes = (from e in db.ChamadoClassificacao select e).ToList();
            return classificacoes;
        }
    }
}