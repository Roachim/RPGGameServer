using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using RPGVideoGameLibrary.Interfaces;
using RPGVideoGameLibrary.MDBModels;


namespace RPGVideoGameAPI.MDBServices
{
    public class MDBUserService
    {
        #region InstanceFields

        private readonly IMongoCollection<MDBProfile> _profiles;


        #endregion

        #region Constructor

        public MDBUserService(IRPGDatabaseSettings settings)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable(settings.ConnectionString));
            var database = client.GetDatabase(settings.DatabaseName);

            _profiles = database.GetCollection<MDBProfile>(settings.ProfilesCollection);
        }


        #endregion

        #region Methods

        public List<MDBProfile> GetProfiles()
        {
            return _profiles.Find(profile => true).ToList();
        }

        #endregion
    }
}
