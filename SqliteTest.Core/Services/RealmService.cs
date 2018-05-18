using Newtonsoft.Json;
using Realms;

using SqliteTest.Contracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SqliteTest.Core.Services
{
    public class RealmService : IRealmService
    {
        #region Constructors

        public RealmService()
        {
            Realm = Realm.GetInstance();
            Initialize();
        }

        #endregion Constructors

        #region Properties

        public Realm Realm { get; private set; }

        public IQueryable<Breed> Breeds
        {
            get { return Realm.All<Breed>(); } 
        }

        public IQueryable<Dog> Dogs
        {
            get { return Realm.All<Dog>(); }
        }

        #endregion Properties

        #region Init

        private void Initialize()
        {
            try
            {
                //  check if we have data
                if (Realm.All<Breed>().Count() == 0)
                {
                    Realm.Write(() =>
                    {
                        //  get breeds
                        var serializer = new JsonSerializer();
                        using (var stream = GetResource("Breeds.json"))
                        {
                            if (stream == null) throw new System.Exception("Could not initialize breeds.");
                            using (var reader = new StreamReader(stream))
                            {
                                using (var jreader = new JsonTextReader(reader))
                                {
                                    foreach (var breed in serializer.Deserialize<List<Breed>>(jreader))
                                    {
                                        Realm.Add(breed);
                                    }
                                }
                            }
                        }
                        using (var stream = GetResource("Dogs.json"))
                        {
                            if (stream == null) throw new System.Exception("Could not initialize dogs.");
                            using (var reader = new StreamReader(stream))
                            {
                                using (var jreader = new JsonTextReader(reader))
                                {
                                    foreach (var dog in serializer.Deserialize<List<Dog>>(jreader))
                                    {
                                        Realm.Add(dog);
                                    }
                                }
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Stream GetResource(string name)
        {
            var assembly = GetType().Assembly;
            foreach (var resource in assembly.GetManifestResourceNames())
            {
                if (resource.EndsWith(name))
                {
                    return assembly.GetManifestResourceStream(resource);
                }
            }
            return null;
        }

        #endregion Init
    }
}
