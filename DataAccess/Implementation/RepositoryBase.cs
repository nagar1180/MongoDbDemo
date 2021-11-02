using DataAccess.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
   public abstract class RepositoryBase<T>
    {
        private readonly string collection;
        private readonly IDatabaseSettings databaseSettings;
        public RepositoryBase(string collection, IDatabaseSettings databaseSettings)
        {
            this.collection = collection;
            this.databaseSettings = databaseSettings;
        }
        public IMongoCollection<T> Collections
        {
            get
            {
              return  DataBase.GetCollection<T>(collection);
            }
        }
        public MongoClient Client
        {
            get
            {
                return new MongoClient(databaseSettings.ConnectionString);
            }
        }
        public IMongoDatabase DataBase
        {
            get
            {
                return Client.GetDatabase(databaseSettings.DatabaseName);
            }
        }

        public FindOptions<T> GetFilter(int limit = 10)
        {
            return new FindOptions<T> { Limit = limit };
        }

        public UpdateOptions Upsert
        {

            get
            {
                return new UpdateOptions { IsUpsert = true };
            }
        }
    }
}
