using System;
using System.Windows;
using Клавиатурный_Тренажерь_Wpf.Entity;

namespace Клавиатурный_Тренажерь_Wpf.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для GameResult.xaml
    /// </summary>
    public partial class GameResult : Window
    {
        public GameResult(Result r)
        {
            InitializeComponent();

            UpdateUICulture();

            LabelGameResult_lvlText.Content = r.lvl;
            LabelGameResult_FailsText.Content = r.fails;
            LabelGameResult_SpeedText.Content = r.speed;
            LabelGameResult_GameDurationText.Content =  $"{r.gameDuratoin.Seconds * -1} sec";
        }

        private void UpdateUICulture()
        {
            //this.Title = Strings.MainWindowTitle;

        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
