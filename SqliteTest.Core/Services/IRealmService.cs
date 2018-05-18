using Realms;
using SqliteTest.Contracts.Models;
using System.Linq;

namespace SqliteTest.Core.Services
{
    public interface IRealmService
    {
        Realm Realm { get; }

        IQueryable<Breed> Breeds { get; }

        IQueryable<Dog> Dogs { get; }
    }
}
