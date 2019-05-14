using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data.NewVersion.Repository;
using Entity.Entities;

namespace STL.POS.Logic
{
    public class PersonManager : BaseManager
    {
        private readonly PersonRepository personRepository;

        public PersonManager()
        {
            personRepository = new PersonRepository();
        }

        public BaseEntity SetPerson(Person.PersonParameters parameter)
        {

            return
                 personRepository.SetPerson(parameter);
        }

        public int GetPersonCountryUbicationOnSysflex(int Country_Id, int State_Prov_Id, int City_Id)
        {

            return
                 personRepository.GetPersonCountryUbicationOnSysflex(Country_Id, State_Prov_Id, City_Id);
        }
        public bool IsAgentFinancial(int AgentId)
        {
            return
                personRepository.IsAgentFinancial(AgentId);
        }

        public IEnumerable<Person.PersonUbication> GetPersonCountryUbicationByUbicationSysflex(int ubicationID)
        {

            return
                 personRepository.GetPersonCountryUbicationByUbicationSysflex(ubicationID);
        }

    }
}
