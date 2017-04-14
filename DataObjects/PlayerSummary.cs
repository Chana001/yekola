using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class PlayerLevelCategory
    {

        public int LevelId { get; set; }

        public string Level { get; set; }

        public string Category { get; set; }

        public bool Unlocked { get; set; }


        //For view
        public string UnlockedText { get; set; }

        public int UserID { get; set; }

    }
}
