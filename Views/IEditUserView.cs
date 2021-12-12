using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    interface IEditUserView
    {
        public User GetUserForEditing();

        public void ShowUser(User edittedUser);
    }
}
