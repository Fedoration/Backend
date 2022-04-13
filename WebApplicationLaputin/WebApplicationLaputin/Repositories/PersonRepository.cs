using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.DbContextBases;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Repositories
{
    public class PersonRepository
    {
        private readonly DbContextBase context;

        public PersonRepository(DbContextBase context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons
                .Select(x => new Person
                {
                    Login = x.Login,
                    Password = x.Password,
                    Role = x.Role
                })
                .ToArray();
        }

        public Person GetById(int id)
        {
            var user = context.Persons
                .FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return null;
            }

            return new Person
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
        }

        public async Task<int> Create(Person user)
        {

            var person = new Person
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };

            context.Add(person);
            await context.SaveChangesAsync();

            return person.Id;
        }


        public async Task<int> Update(Person user, int id)
        {

            var person = context.Persons
                .FirstOrDefault(x => x.Id == id);

            if (person is null)
            {
                return -1;
            }

            person.Login = user.Login;
            person.Password = user.Password;
            person.Role = user.Role;

            await context.SaveChangesAsync();

            return person.Id;
        }

        public async Task<int> Delete(int id)
        {
            var person = context.Persons
                .FirstOrDefault(x => x.Id == id);

            if (person is null)
            {
                return -1;
            }

            context.Remove(person);
            await context.SaveChangesAsync();

            return id;
        }
    }

}

