using FluentResults;
using System.Collections.Generic;

namespace AMcom.Teste.DAL.Interface
{
    public interface IUbsRepository
    {
        Result<ICollection<Ubs>> Obter();
    }
}