using Microsoft.Xna.Framework;
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
    class EzficNPC : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if(npc.type == NPCID.SkeletronHand)
            {
                
            }
            if (npc.type == NPCID.SkeletronHead)
            {
                
            }
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (npc.type == NPCID.SkeletronHead)
            {
                if(npc.Hitbox.Contains(Main.MouseWorld.ToPoint()))
                {
                    Terraria.Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, "这是个难的过分的Boss", Main.MouseScreen.X + 30, Main.MouseScreen.Y + 80,
                new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor),
                Color.Black, new Vector2(0, 0), 1f * Main.UIScale);
                }
            }
        }
    }
}
