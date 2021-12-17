
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models;
using Reposotries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IGenericRepostory <Person> PersonRepo;
        IGenericRepostory<Address> AddressRepo;
        IUnitOfWork UnitOfWork;
        public PersonController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            PersonRepo = UnitOfWork.GetPersonRepo();
            AddressRepo = UnitOfWork.GetAddressRepo();
        }


        [HttpGet("getpersons")]
        public async Task<List<Person>> Get()
        {
            var List = await PersonRepo.GetAsync();
            return List.ToList();
        }
        [HttpPost("addperson")]
        public async Task<IEnumerable<Person>> addperson(Person p)
        {
            await PersonRepo.Add(p);
            await UnitOfWork.Save();
            return await PersonRepo.GetAsync();
        }

        [HttpPut("updateperson")]
        public async Task<IEnumerable<Person>> UpdatePERSON(Person pserson)
        {
            await PersonRepo.Update(pserson);
            await UnitOfWork.Save();
            return await PersonRepo.GetAsync();
        }

        [HttpDelete("deleteperson/{id}")]
        public async Task<IEnumerable<Person>> deleteperson(int id)
        {

            await PersonRepo.Remove(await PersonRepo.GetByIDAsync(id));
            await UnitOfWork.Save();
            return await PersonRepo.GetAsync();
        }

        [HttpGet("getaddress")]
        public async Task<List<Address>> Getadress()
        {
            var List = await AddressRepo.GetAsync();
            return List.ToList();
        }

        [HttpPost("addaddress")]
            public async Task<IEnumerable<Person>> addaddress(Address address)
            {
                 
                await AddressRepo.Add(address);
                await UnitOfWork.Save();
                return await PersonRepo.GetAsync();
            }

          [HttpPut("updateaddress")]
            public async Task<IEnumerable<Person>> Updateaddress(
             [FromBody] Address address)
            {
                await AddressRepo.Update(address);
                await UnitOfWork.Save();
                return await PersonRepo.GetAsync();
            }

            [HttpDelete("deleteaddress/{id}")]
            public async Task<IEnumerable<Person>> deleteaddress(int id)
            {

                await AddressRepo.Remove(await AddressRepo.GetByIDAsync(id));
                await UnitOfWork.Save();
                return await PersonRepo.GetAsync();
            }

    }
}
