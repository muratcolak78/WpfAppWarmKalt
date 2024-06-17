using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfAppWarmKalt
{
    /// <summary>
    /// Interaktionslogik für SpielFenster.xaml
    /// </summary>
    public partial class SpielFenster : Window
    {
        public SpielFenster()
        {
            InitializeComponent();
            lblUserName.Content = UserManager.User.userName;
            lblMode.Content = UserManager.SpielMode;
            UserManager.RandomNumber= GenerateGame.SpielMode(UserManager.SpielMode);
            MessageBox.Show(UserManager.RandomNumber.ToString());
        }

      

        private void txtbxEingegebeneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserManager.AttemptNumber++;
                int number = UserManager.RandomNumber;

                if (int.TryParse(txtbxEingegebeneNumber.Text, out int txtNumber))
                {
                    if (txtNumber == number)
                    {
                        MessageBox.Show("Tebrikler, doğru sayıyı bildiniz!");
                        UserManager.User.AddGame(new Game(UserManager.SpielMode, UserManager.AttemptNumber));
                        StartNewGame();
                    }
                    else
                    {
                        if (UserManager.EingegebeneNumber != 0)
                        {

                            lblWarmOderKalt.Content = WarmController.Controller(txtNumber, number, UserManager.EingegebeneNumber, number);
                            UserManager.EingegebeneNumber = txtNumber;
                        }
                        else
                        {
                            lblWarmOderKalt.Content = "Kalt";
                            UserManager.EingegebeneNumber = txtNumber;
                        }
                           
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir sayı girin.");
                }

                txtbxEingegebeneNumber.Clear(); // TextBox'ı temizle
            }
        }
        private void StartNewGame()
        {
            MessageBoxResult result = MessageBox.Show("Oyuna devam etmek istiyor musunuz?", "Oyun Daveti", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Kullanıcı evet derse buraya oyunun devam etmesiyle ilgili kodlar gelebilir
                MessageBox.Show("Oyun devam ediyor...");
                UserManager.newGame();
                lblWarmOderKalt.Content = "";
                UserManager.RandomNumber = GenerateGame.SpielMode(UserManager.SpielMode);
                MessageBox.Show(UserManager.RandomNumber.ToString());

            }
            else if (result == MessageBoxResult.No)
            {
                // Kullanıcı hayır derse oyunu sonlandırmak için gerekli işlemler yapılabilir
                MessageBox.Show("Oyundan çıkılıyor...");
                UserManager.newUserGame();
                new MainWindow().Show();    
                this.Close();
                //Application.Current.Shutdown(); // Uygulamayı kapatma
            }
        }

       
    }
}

