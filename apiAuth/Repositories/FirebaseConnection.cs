using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Repositories.Interfaces;
using apiAuth.Services.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;


namespace apiAuth.Repositories
{
    public class FirebaseConnection : IFirebaseConnection
    {
        private IFirebaseConfig _config =  new FirebaseConfig{
            AuthSecret = Startup.StaticConfig.GetSection("firebaseAuthSecret").Value,
            BasePath = Startup.StaticConfig.GetSection("firebasePath").Value
        };
        public FireSharp.FirebaseClient Init()
        {
            return new FireSharp.FirebaseClient(_config);
        }
    }
}