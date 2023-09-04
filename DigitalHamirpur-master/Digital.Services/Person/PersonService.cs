using Digital.Data.Models;
using Digital.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Digital.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> repoPerson;

        public PersonService(IRepository<Person> _repoPerson)
        {
            repoPerson = _repoPerson;           
        }


        public Person GetPerson(int id)
        {
            return repoPerson.Query()
                .Filter(e => e.PersonId == id)
                //.Include(x => x.UserLogins)
                .Get()
                .FirstOrDefault();
        }

        public Person GetPersonById(int id)
        {
            return repoPerson.Query()
                //.Include(x => x.UsersLogin)
                .Filter(e => e.PersonId == id)
                .Get()
                .FirstOrDefault();             
               
        }

        public bool Save(Person person)
        {
            try
            {
                if (person.PersonId > 0)
                    repoPerson.Update(person);
                else
                    repoPerson.Insert(person);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            if (repoPerson != null)
            {
                repoPerson.Dispose();
            }
        }
    }
}
