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
using Клавиатурный_Тренажерь_Wpf.Controller;
using Клавиатурный_Тренажерь_Wpf.Entity;
using Клавиатурный_Тренажерь_Wpf.Lang;
using Клавиатурный_Тренажерь_Wpf.Repo;

namespace Клавиатурный_Тренажерь_Wpf.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public Player Player { get; set; } = null;

        public AuthWindow()
        {
            InitializeComponent();
            UpdateUICulture();
        }

        private void Button_New_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text.Length < 3 || TextBox_Login.Text.Length > 12)
            {
                TextBox_Login.Foreground = new SolidColorBrush(Colors.White);
                TextBox_Login.Background = new SolidColorBrush(Colors.Red);
            }
            else if (TextBox_Email.Text.Length < 8)
            {
                TextBox_Email.Foreground = new SolidColorBrush(Colors.White);
                TextBox_Email.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

                if (PlayerRepository.IsPlayerExeting(new Player { Login = TextBox_Login.Text }))
                {
                    Player = null;
                    MessageBox.Show("Такой логин уже есть");
                    TextBox_Login.Text = string.Empty;
                    TextBox_Email.Text = string.Empty;
                }
                else
                {
                    Player = PlayerController.CreatePlayer(TextBox_Login.Text, TextBox_Email.Text);
                    this.Close();
                }
            }
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {

            if (PlayerRepository.IsPlayerExeting(new Player { Login = TextBox_Login.Text }))
            {
                Player = PlayerRepository.LoadPlayer(TextBox_Login.Text);
                this.Close();
            }
            else
            {
                Player = null;
                MessageBox.Show("Такого логина не существует");
                TextBox_Login.Text = string.Empty;
                TextBox_Email.Text = string.Empty;
            }

        }


        private void UpdateUICulture()
        {
            this.Title = Strings.AuthWindowTitle;
            Label_Login.Content = Strings.Label_Login;
            Label_Email.Content = Strings.Label_Email;
            Button_New.Content = Strings.Button_New_Click;
            Button_Auth.Content = Strings.Button_Auth_Click;
        }
    }
}
