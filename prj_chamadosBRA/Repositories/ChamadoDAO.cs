﻿using prj_chamadosBRA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_chamadosBRA.Repositories
{
    public class ChamadoDAO
    {
        ApplicationDbContext db;
        public ChamadoDAO(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Chamado> BuscarChamados()
        {
            List<Chamado> chamados = (from e in db.Chamado select e).ToList();
            foreach (var chamado in chamados)
            {
                ApplicationUser resp = chamado.ResponsavelChamado;
                ApplicationUser respAb = chamado.ResponsavelAberturaChamado;
                chamado.ResponsavelChamado = resp;
                chamado.ResponsavelAberturaChamado = respAb;
            }
            return chamados;
        }

        public List<Chamado> BuscarChamadosDoUsuario(ApplicationUser user)
        {
            List<Chamado> chamados = (from e in db.Chamado where e.ResponsavelAberturaChamado.Id == user.Id select e).ToList();
            foreach (var chamado in chamados)
            {
                ApplicationUser resp = chamado.ResponsavelChamado;
                ApplicationUser respAb = chamado.ResponsavelAberturaChamado;
                chamado.ResponsavelChamado = resp;
                chamado.ResponsavelAberturaChamado = respAb;
            }
            return chamados;
        }

        public List<Chamado> BuscarChamadosDeObras(List<Obra> obras)
        {
            List<Chamado> chamados = (from e in db.Chamado where obras.Contains(e.ObraDestino) select e).ToList();
            foreach (var chamado in chamados)
            {
                ApplicationUser resp = chamado.ResponsavelChamado;
                ApplicationUser respAb = chamado.ResponsavelAberturaChamado;
                chamado.ResponsavelChamado = resp;
                chamado.ResponsavelAberturaChamado = respAb;
            }
            return chamados;
        }

        public Chamado BuscarChamadoId(int id)
        {
            Chamado chamado = (from e in db.Chamado where e.Id == id select e).SingleOrDefault();
            return chamado;
        }

        public Chamado DetalhesChamado(int id)
        {
            Chamado chamado = (from e in db.Chamado where e.Id == id select e).SingleOrDefault();
            return chamado;
        }

        public Boolean salvarChamado(Chamado chamado)
        {
            db.Chamado.Add(chamado);
            db.SaveChanges();
            return true;
        }

        //public void eliminarSetor(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.Entry(this.DetalhesSetor(id)).State = System.Data.Entity.EntityState.Deleted;
        //        ctx.SaveChanges();
        //    }
        //}

        //public void atualizarSetor(int id, Setor setor)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        Setor setorUpdate = (from e in ctx.Setor where e.Id == id select e).SingleOrDefault();
        //        setorUpdate.Nome = setor.Nome;
        //        setorUpdate.Descricao = setor.Descricao;
        //        setorUpdate.Responsavel = setor.Responsavel;
        //        setorUpdate.EmailResponsavel = setor.EmailResponsavel;
        //        setorUpdate.EmailSetor = setor.EmailSetor;
        //        ctx.SaveChanges();
        //    }
        //}

    }
}