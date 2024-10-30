using BusinessObjects;
using Repositories;
using System.Windows;


namespace WPFApp
{
    public partial class LoginWindow : Window
    {
        private readonly IAccountRepository _accountRepository;
        public LoginWindow()
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountMember? account = _accountRepository.GetAccountMemberById(txtUser.Text);
            if (account != null && account.MemberPassword.Equals(txtPass.Password) && account.MemberRole == 1)
            {
                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("You are not permission!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}