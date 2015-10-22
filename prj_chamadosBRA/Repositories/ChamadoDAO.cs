﻿using prj_chamadosBRA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Chamado> BuscarChamados(string filtro, bool encerrado, string sortOrder)
        {
            var chamados = (from e in db.Chamado where e.StatusChamado == encerrado select e);
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().Contains(filtro)
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }

            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id);
                    break;
            }

            return chamados.ToList();
        }

        public List<Chamado> BuscarChamadosTipoChamado(int? tipoChamado, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = (from e in db.Chamado where e.StatusChamado == encerrado && e.TipoChamado == tipoChamado select e);
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().Contains(filtro)
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id);
                    break;
            }

            return chamados.ToList();
        }

        public List<Chamado> BuscarChamadosDoUsuario(ApplicationUser user, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = (from e in db.Chamado where e.ResponsavelAberturaChamado.Id == user.Id && e.StatusChamado == encerrado select e);
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().Contains(filtro)
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id);
                    break;
            }

            return chamados.ToList();
        }

        public List<Chamado> BuscarChamadosDoUsuarioTipoChamado(ApplicationUser user, int? tipoChamado, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = (from e in db.Chamado where e.ResponsavelAberturaChamado.Id == user.Id && e.StatusChamado == encerrado && e.TipoChamado == tipoChamado select e);
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().Contains(filtro)
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id);
                    break;
            }
            return chamados.ToList();
        }

        public List<Chamado> BuscarChamadosDeObras(List<Obra> obras, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = new List<Chamado>();
            foreach (var obra in obras)
            {
                var chamadosList = (from e in db.Chamado where obra.IDO == e.ObraDestino.IDO && e.StatusChamado == encerrado select e);
                chamados.AddRange(chamadosList);
            }
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower()))).ToList();
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id).ToList();
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura).ToList();
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome).ToList();
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto).ToList();
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome).ToList();
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao).ToList();
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao).ToList();
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id).ToList();
                    break;
            }
            return chamados.ToList();
        }

        public List<Chamado> BuscarChamadosDeObrasTipoChamado(List<Obra> obras, int? tipoChamado, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = new List<Chamado>();
            foreach (var obra in obras)
            {
                var chamadosList = (from e in db.Chamado where obra.IDO == e.ObraDestino.IDO && e.StatusChamado == encerrado && e.TipoChamado == tipoChamado select e).ToList();
                chamados.AddRange(chamadosList);
            }
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower()))).ToList();
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = (List<Chamado>)chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = (List<Chamado>)chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.Id);
                    break;
            }
            return chamados;
        }

        public List<Chamado> BuscarChamadosDeSetores(List<Setor> setores, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = new List<Chamado>();
            foreach (var setor in setores)
            {
                var chamadosList = (from e in db.Chamado where setor.Id == e.SetorDestino.Id && e.StatusChamado == encerrado select e).ToList();
                chamados.AddRange(chamadosList);
            }
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower()))).ToList();
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = chamados.OrderByDescending(s => s.Id).ToList();
                    break;
                case "dataAbertura":
                    chamados = chamados.OrderByDescending(s => s.DataHoraAbertura).ToList();
                    break;
                case "solicitante":
                    chamados = chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome).ToList();
                    break;
                case "assunto":
                    chamados = chamados.OrderBy(s => s.Assunto).ToList();
                    break;
                case "responsavel":
                    chamados = chamados.OrderBy(s => s.ResponsavelChamado.Nome).ToList();
                    break;
                case "obra":
                    chamados = chamados.OrderBy(s => s.ObraDestino.Descricao).ToList();
                    break;
                case "setor":
                    chamados = chamados.OrderBy(s => s.SetorDestino.Descricao).ToList();
                    break;
                default:
                    chamados = chamados.OrderBy(s => s.Id).ToList();
                    break;
            }
            return chamados;
        }

        public List<Chamado> BuscarChamadosDeSetoresTipoChamado(List<Setor> setores, int? tipoChamado, string filtro, bool encerrado, string sortOrder)
        {
            var chamados = new List<Chamado>();
            foreach (var setor in setores)
            {
                var chamadosList = (from e in db.Chamado where setor.Id == e.SetorDestino.Id && e.StatusChamado == encerrado && e.TipoChamado == tipoChamado select e).ToList();
                chamados.AddRange(chamadosList);
            }
            if (filtro != null)
            {
                chamados = chamados.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower()))).ToList();
            }
            switch (sortOrder)
            {
                case "id":
                    chamados = (List<Chamado>)chamados.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamados = (List<Chamado>)chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamados = (List<Chamado>)chamados.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamados = (List<Chamado>)chamados.OrderByDescending(s => s.DataHoraAbertura);
                    break;
            }
            return chamados;
        }

        public List<Chamado> BuscarChamadosTecnicoRM(List<Obra> obras, string filtro, bool encerrado, string sortOrder)
        {
            var idObra = obras[0].IDO;
            var chamadosList = (from e in db.Chamado where (e.ObraDestino.IDO == idObra || e.TipoChamado == 1) && e.StatusChamado == encerrado select e);

            if (filtro != null)
            {
                chamadosList = chamadosList.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }

            switch (sortOrder)
            {
                case "id":
                    chamadosList = chamadosList.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamadosList = chamadosList.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamadosList = chamadosList.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamadosList = chamadosList.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamadosList = chamadosList.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamadosList = chamadosList.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamadosList = chamadosList.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamadosList = chamadosList.OrderBy(s => s.Id);
                    break;
            }
            return chamadosList.ToList();
        }

        public List<Chamado> BuscarChamadosTecnicoRMTipoChamado(List<Obra> obras, int? tipoChamado, string filtro, bool encerrado, string sortOrder)
        {
            var idObra = obras[0].IDO;
            var chamadosList = (from e in db.Chamado where (e.ObraDestino.IDO == idObra || e.TipoChamado == 1) && e.StatusChamado == encerrado && e.TipoChamado == tipoChamado select e);

            if (filtro != null)
            {
                chamadosList = chamadosList.Where(s => s.Id.ToString().ToLower().Contains(filtro.ToLower())
                                                           || s.Assunto.ToLower().Contains(filtro.ToLower())
                                                           || s.Descricao.ToLower().Contains(filtro.ToLower())
                                                           || (s.ResponsavelAberturaChamado != null && s.ResponsavelAberturaChamado.Nome.ToLower().Contains(filtro.ToLower()))
                                                           || (s.ResponsavelChamado != null && s.ResponsavelChamado.Nome.ToLower().Contains(filtro.ToLower())));
            }
            switch (sortOrder)
            {
                case "id":
                    chamadosList = chamadosList.OrderByDescending(s => s.Id);
                    break;
                case "dataAbertura":
                    chamadosList = chamadosList.OrderByDescending(s => s.DataHoraAbertura);
                    break;
                case "solicitante":
                    chamadosList = chamadosList.OrderBy(s => s.ResponsavelAberturaChamado.Nome);
                    break;
                case "assunto":
                    chamadosList = chamadosList.OrderBy(s => s.Assunto);
                    break;
                case "responsavel":
                    chamadosList = chamadosList.OrderBy(s => s.ResponsavelChamado.Nome);
                    break;
                case "obra":
                    chamadosList = chamadosList.OrderBy(s => s.ObraDestino.Descricao);
                    break;
                case "setor":
                    chamadosList = chamadosList.OrderBy(s => s.SetorDestino.Descricao);
                    break;
                default:
                    chamadosList = chamadosList.OrderBy(s => s.Id);
                    break;
            }
            return chamadosList.ToList();
        }

        public Chamado BuscarChamadoId(int id)
        {
            var chamado = (from e in db.Chamado where e.Id == id select e).SingleOrDefault();
            return chamado;
        }

        public Boolean salvarChamado(Chamado chamado)
        {
            db.Chamado.Add(chamado);
            db.SaveChanges();
            return true;
        }

        public void atualizarChamado(int id, Chamado chamado)
        {
            var chamadoUpdate = (from e in db.Chamado where e.Id == id select e).SingleOrDefault();
            chamadoUpdate.ObsevacaoInterna = chamado.ObsevacaoInterna;
            chamadoUpdate.SetorDestino = chamado.SetorDestino;
            chamadoUpdate.ObraDestino = chamado.ObraDestino;
            chamadoUpdate.ResponsavelChamado = chamado.ResponsavelChamado;
            chamadoUpdate.TipoChamado = chamado.TipoChamado;
            //db.Entry(chamado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void encerrarChamado(int id, Chamado chamado)
        {
            var chamadoUpdate = (from e in db.Chamado where e.Id == id select e).SingleOrDefault();
            chamadoUpdate.DataHoraAtendimento = chamado.DataHoraAtendimento;
            chamadoUpdate.Classificacao = chamado.Classificacao;
            chamadoUpdate.SubClassificacao = chamado.SubClassificacao;
            chamadoUpdate.DataHoraBaixa = chamado.DataHoraBaixa;
            chamadoUpdate.ObraDestino = chamado.ObraDestino;
            chamadoUpdate.Solucao = chamado.Solucao;
            chamadoUpdate.StatusChamado = true;
            chamadoUpdate.ErroOperacional = chamado.ErroOperacional;
            db.SaveChanges();
        }
    }
}