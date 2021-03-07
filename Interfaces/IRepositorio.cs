using System.Collections.Generic;

namespace DIO.Sertes.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        
        T RetornaPorId(int Id);
        void Inserir(T entidade);
        void Excluir(int Id);
        void Atualizar(int Id, T entidade);
        void ProximoId();

    }
}