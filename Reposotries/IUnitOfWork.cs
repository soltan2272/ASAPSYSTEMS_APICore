using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposotries
{
    public interface IUnitOfWork
    {
        IGenericRepostory<Person> GetPersonRepo();
        IGenericRepostory<Address> GetAddressRepo();
        Task Save();
    }
}
