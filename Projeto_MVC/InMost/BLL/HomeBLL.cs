﻿using InMost.DAO;
using InMost.Entity;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.BLL
{
    class HomeBLL
    {
        public HomeModel CarregaUsuario(HomeModel model)
        {
            HomeDAO DAO = new HomeDAO();

            DataTable data = DAO.CarregaPerfil(ModelToEntity(model));
            DataTable lista = DAO.CarregaLista(ModelToEntity(model));

            if(data != null && lista != null)
                if (data.Rows.Count > 0)
                {
                    model.Nome = data.Rows[0].ItemArray[0].ToString();
                    model.Apelido = data.Rows[0].ItemArray[1].ToString();
                    model.Url_foto = data.Rows[0].ItemArray[2].ToString();

                    foreach(DataRow linha in lista.Rows  )
                    {
                        Membros m = new Membros();
                        m.Nome = linha.ItemArray[0].ToString();
                        m.Apelido = linha.ItemArray[1].ToString();
                        m.Url_foto = linha.ItemArray[2].ToString();
                        m.Email = model.Email;
                        if(model.membros == null)
                            model.membros = new List<Membros>();
                        model.membros.Add(m);
                    }

                    DataTable preferencia = DAO.CarregaPreferencia();

                    foreach(DataRow linha in preferencia.Rows)
                    {
                        Preferencias pref = new Preferencias();
                        pref.Codigo = (int)linha.ItemArray[0];
                        pref.Descricao = linha.ItemArray[1].ToString();
                        pref.Icone = linha.ItemArray[2].ToString();
                        if (model.interesse == null)
                            model.interesse = new List<Preferencias>();
                        model.interesse.Add(pref);
                    }

                    return model;
                }

            return null;
        }

        public HomeEntity ModelToEntity(HomeModel model)
        {
            HomeEntity entity = new HomeEntity();

            entity.Nome = model.Nome;
            entity.Email = model.Email;
            entity.Apelido = model.Apelido;
            entity.Url_foto = model.Url_foto;

            return entity;
        }
    }
}
