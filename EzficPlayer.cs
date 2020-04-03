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
    class EzficPlayer : ModPlayer
    {
        public int talkActive = 0;
        public string nowSaying = "";
        public override void PreUpdate()
        {
            if (Main.rand.Next(600) == 0)
            {
                foreach (NPC npc in Main.npc)
                {
                    if (npc.type == NPCID.SkeletronHead && player.HeldItem.type == ItemID.StarCannon)
                    {
                        new Talk(Main.rand.NextBool() ? "“来吧，试一下你”" : "“从没试过用这把枪，打这个Boss”", 180);
                        break;
                    }
                }
            }
        }
    }
}
