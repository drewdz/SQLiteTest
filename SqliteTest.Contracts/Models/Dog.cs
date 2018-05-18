using Realms;
using System;

namespace SqliteTest.Contracts.Models
{
    public class Dog : RealmObject
    {
        public long Id { get; set; }

        public long BreedId { get; set; }

        public string Name { get; set; }
    }
}
