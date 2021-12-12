using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    public class User
    {
        private long id;
        private string name;
        private string lastName;
        private string email;
        private UserRole userRole;

        public User() { }

        public User(long id, string name, string lastName, string email, UserRole userRole)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.userRole = userRole;
        }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        internal UserRole UserRole { get => userRole; set => userRole = value; }

        public override string ToString()
        {
            return $"User [id = {Id}, Name = {Name}, Last name = {LastName}, email = {Email}, role = {UserRole}]";
        }
    }
}
