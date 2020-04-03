using Terraria;

namespace Ezfic
{
    public class Talk
    {
        public Talk(string type, int time)
        {
            Player player = Main.LocalPlayer;
            player.GetModPlayer<EzficPlayer>().nowSaying = type;
            player.GetModPlayer<EzficPlayer>().talkActive = time;
        }
    }
}
