using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameProject;

namespace GameClient
{
    /// <summary>
    /// An object representing the game table
    /// </summary>
    class DurakTable
    {

        public Cards InPlay { get; private set; }

        public Cards InDiscard { get; private set; }

        public DurakTable()
        {
            InPlay = new Cards();
            InDiscard = new Cards();
        }

        public Card LastPlayed()
        {
            return InPlay[InPlay.Count - 1];
        }


    }
}
