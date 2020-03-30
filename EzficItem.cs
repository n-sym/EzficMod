using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ezfic
{
    class EzficItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.StarCannon)
            {
                
            }
    
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(item.type == ItemID.StarCannon)
            {
                tooltips.Add(new TooltipLine(Ezfic.mod, "FishingPower", "顶级玩家的选择"));
            }
        }
    }
}
