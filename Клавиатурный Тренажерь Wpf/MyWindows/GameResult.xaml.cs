using System;
using System.Windows;
using Клавиатурный_Тренажерь_Wpf.Entity;
using Клавиатурный_Тренажерь_Wpf.Lang;

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
            this.Title = Strings.GameResultTitle;
            LabelGameResult_Fails.Content = Strings.LabelGameResult_Fails;
            LabelGameResult_lvl.Content = Strings.LabelGameResult_lvl;
            LabelGameResult_Speed.Content = Strings.LabelGameResult_SpeedText;
            LabelGameResult_GameDuration.Content = Strings.LabelGameResult_GameDuration;
            LabelGameResult_Title.Content = Strings.LabelGameResult_Title;
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
