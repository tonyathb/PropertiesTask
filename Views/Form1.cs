using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertiesTask
{
    public partial class Form1 : Form, IEditUserView
    {
        private User userBinding = new User();
        private EditUserController editUserController;

        public Form1()
        {
            InitializeComponent();
            editUserController = new EditUserController(this);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            editUserController.ShowUser();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            userBinding.Name = userNameTextBox.Text;
            userBinding.LastName = userLastNameTextBox.Text;
            userBinding.Email = userEmailTextBox.Text;
            userBinding.UserRole = UserRole.ADMIN;
            editUserController.Edit();
        }

        public User GetUserForEditing()
        {
            return userBinding;
        }

        public void ShowUser(User edittedUser)
        {
            userNameTextBox.Text = edittedUser.Name ;
            userLastNameTextBox.Text = edittedUser.LastName;
            userEmailTextBox.Text = edittedUser.Email;
            userRoleTextBox.Text = edittedUser.UserRole.ToString();
        }
    }
}
