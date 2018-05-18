using Realms;
using System;

namespace SqliteTest.Contracts.Models
{
    public class Breed : RealmObject
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string NameSort
        {
            get
            {
                return (string.IsNullOrEmpty(Name)) ? "?" : Name[0].ToString().ToUpper();
            }
        }
    }
}
