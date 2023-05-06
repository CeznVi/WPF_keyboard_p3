using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Клавиатурный_Тренажерь_Wpf.Entity
{

    [Serializable]
    public class Player
    {
        public Player()
        {
            Results = new();
        }

        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public List<Result> Results { get; set; }

    }
}
