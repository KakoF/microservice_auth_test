using System.Threading.Tasks;
using apiAuth.Models;
using FireSharp.Interfaces;

namespace apiAuth.Repositories.Interfaces
{
  public interface IFirebaseConnection
  {
    FireSharp.FirebaseClient Init();
  }
}