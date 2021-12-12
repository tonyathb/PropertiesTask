using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertiesTask
{
    class EditUserController
    {
        private UsersRepository usersRepository;
        private IEditUserView editUserView;

        public EditUserController(IEditUserView editUserView)
        {
            this.usersRepository = new UsersRepository(new SqlConnectionManager());
            this.editUserView = editUserView;
        }

        public void ShowUser()
        {
            editUserView.ShowUser(usersRepository.Get(6));
        }

        public void Edit()
        {
            User userForEditing = editUserView.GetUserForEditing();
            usersRepository.Update(6, userForEditing);
            User updatedUser = usersRepository.Get(6);
            editUserView.ShowUser(updatedUser);
        }
    }
}
