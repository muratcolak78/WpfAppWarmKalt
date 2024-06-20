using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppWarmKalt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserManager.LoadUsers();
            UserManager.sortList();
            UserManager.Data = DG1;
            DG1.ItemsSource = UserManager.Users;
            SqlConnect.getConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            if (txtBoxName.Text != "")
            {
                if (UserManager.IsRadioButtonsSelected)
                {
                    if (UserManager.SpielMode != null)
                    {
                        if (UserManager.UserType == "vorhanden" && UserController.Controller(txtBoxName.Text))
                        {
                            //new SpielFenster().Show();
                            
                            //this.Close();
                        }
                        //else MessageBox.Show("Es wurde kein solcher Spieler gefunden");
                        
                        if (UserManager.UserType == "neue spieler")
                        {
                            User user = new User(txtBoxName.Text);
                            UserManager.Users.Add(user);
                            UserManager.User = user;
                            UserManager.SaveUsers();
                            UserManager.UpdateJson(DG1);
                            MessageBox.Show(UserManager.Users.Count.ToString());
                        }
                      
                        
                        if (UserManager.User != null && UserManager.SpielMode != null)
                        {
                            new SpielFenster().Show();
                            this.Close();
                        }
                      

                    }
                    else
                    {
                        MessageBox.Show("bitte wählen Sie situtiationen");
                    }  
                   
                }
                else
                {
                    MessageBox.Show("bitte wählen Sie situtiationen");
                }
            }else
            {
                MessageBox.Show("bitte geben Sie Ihren Name ein");
            }
          
           
            
        }

        private void rbNeueSpiler_Checked(object sender, RoutedEventArgs e)
        {
          RadioButtonController.CheckRadioButton(sender as RadioButton);
        }

        private void rbNormal_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonController.CheckRadioButton(sender as RadioButton);

        }

        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DG1.SelectedItem is User user)
            {
                txtBoxName.Text = user.userName;
                rbVorhanden.IsChecked = true;
            }
        }
    }
}