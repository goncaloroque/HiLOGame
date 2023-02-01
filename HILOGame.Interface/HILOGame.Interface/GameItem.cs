using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HILOGame.Interface
{
    internal class GameItem
    {
        public string? ID { get; set; }

        public string? Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

    }
}
