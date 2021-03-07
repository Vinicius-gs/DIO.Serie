using System;
using System.Collections.Generic;
using DIO.Sertes.Classes;
using DIO.Sertes.Interfaces;

namespace DIO.Sertes.Classes
{
  public class SerieRepositorio : IReposistorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id , Serie entidade )
        {
            listaSerie[id] = entidade;
        }
        public void Excluir(int id )
        {
            listaSerie[id].Excluir();
        }
        public void Inserir(Serie entidade )
        {
            listaSerie.Add(entidade);
        }
        public List<Serie> Lista()
        {
           return listaSerie;
        }
        public int ProximoId( )
        {
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id  )
        {
            return listaSerie[id];
        }
    }
}