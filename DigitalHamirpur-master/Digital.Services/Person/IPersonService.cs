using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Digital.Service
{
    public interface IPersonService : IDisposable
    {
        Person GetPerson(int id);
        Person GetPersonById(int id);
        bool Save(Person person);

        
       
    }
}
