using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


    }
}
