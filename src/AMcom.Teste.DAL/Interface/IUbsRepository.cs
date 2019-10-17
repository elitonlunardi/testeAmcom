using System.Collections.Generic;

namespace AMcom.Teste.DAL.Interface
{
    public interface IUbsRepository
    {
        ICollection<Ubs> Obter();
    }
}