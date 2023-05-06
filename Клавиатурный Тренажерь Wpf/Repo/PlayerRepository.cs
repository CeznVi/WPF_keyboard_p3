using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Клавиатурный_Тренажерь_Wpf.Entity;

namespace Клавиатурный_Тренажерь_Wpf.Repo
{
    class PlayerRepository
    {

        public static void SavePlayer(Player player)
        {
            string fileName = $"/{player.Login}.xml";
            string dirPath = "../../../../SaveFile/Players";

            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                XmlSerializer serializer = new(typeof(Player));

                using (Stream stream = File.Create(dirPath + fileName))
                {
                    serializer.Serialize(stream, player);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static bool IsPlayerExeting(Player player)
        {
            string fileName = $"/{player.Login}.xml";
            string dirPath = "../../../../SaveFile/Players";

            if(File.Exists(dirPath + fileName))
                return true;
            else return false;
        }

        public static Player LoadPlayer(string login)
        {
            string fileName = $"/{login}.xml";
            string dirPath = "../../../../SaveFile/Players";

            Player player = new Player();

            try
            {
                if (!File.Exists(dirPath + fileName))
                    throw new FileNotFoundException($"Файл: {fileName} не создан.");

                XmlSerializer serializer = new(typeof(Player));

                using (Stream stream = File.OpenRead(dirPath + fileName))
                {
                    player = ((Player)serializer.Deserialize(stream));
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return player;
        }
    }
}
