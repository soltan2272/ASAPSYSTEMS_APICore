using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposotries
{
    public class UnitOfWork : IUnitOfWork
    {

        ProjectDBContect Context;
        IGenericRepostory<Person> PersonRepo;
        IGenericRepostory<Address> AddressRepo;

        
        public UnitOfWork(ProjectDBContect context, IGenericRepostory<Person> personRepo,
          IGenericRepostory<Address> addressRepo  )
        {
            Context = context;
            PersonRepo = personRepo;
            AddressRepo = addressRepo;
            
        }
        public IGenericRepostory<Person> GetPersonRepo()
        {
            return PersonRepo;
        }

        public IGenericRepostory<Address> GetAddressRepo()
        {
            return AddressRepo;
        }
  
        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
    }
