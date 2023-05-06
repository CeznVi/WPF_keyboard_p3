using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Клавиатурный_Тренажерь_Wpf.Entity;
using Клавиатурный_Тренажерь_Wpf.Repo;

namespace Клавиатурный_Тренажерь_Wpf.Controller
{
    class PlayerController
    {
        public static Player CreatePlayer(string login, string email, Guid? id = null)
        {

            Player _player = new Player() { Login = login, Email = email };
            
            if (id == null)
            {
                _player.Id = Guid.NewGuid();
            }
            else
                _player.Id = new Guid(id.Value.ToString());

            if(!PlayerRepository.IsPlayerExeting(_player))
                PlayerRepository.SavePlayer(_player);

            return _player;
        }

        public static void UpdatePlayer(Player player, Result result) 
        { 

            player.Results.Add(result);

            PlayerRepository.SavePlayer(player);

        }

    }
}
