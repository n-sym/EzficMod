using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ReLogic.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows;
using System.Windows.Forms;
using System.Reflection;

namespace Ezfic
{
    public class Ezfic: Mod
    {
        public static Mod mod;
        static Texture2D logo1;
        static Texture2D logo2;
        public Ezfic()
        {
            mod = this;
        }
        public override void Load()
        {
            logo1 = Main.logoTexture;
            logo2 = Main.logo2Texture;
            Main.logoTexture = GetTexture("logo1");
            Main.logo2Texture = GetTexture("logo2");
            Main.versionNumber = "Cheateria V1.4";
            Main.versionNumber2 = "Cheateria";
            Main.itemTexture[197] = GetTexture("Textureinstead/Item_197");
           /* Main.npcTexture[35] = GetTexture("Textureinstead/NPC_35");
            Main.npcTexture[36] = GetTexture("Textureinstead/NPC_36");
            Main.NPCLoaded[35] = true;
            Main.NPCLoaded[36] = true;
            Main.goreTexture[54] = GetTexture("Textureinstead/Gore_54");
            Main.goreTexture[55] = GetTexture("Textureinstead/Gore_55");
            Main.goreTexture[56] = GetTexture("Textureinstead/Gore_56");
            Main.goreTexture[57] = GetTexture("Textureinstead/Gore_57");
            Main.goreLoaded[54] = true;
            Main.goreLoaded[55] = true;
            Main.goreLoaded[56] = true;
            Main.goreLoaded[57] = true;*/
            SetLang("LegacyMenu.12", "单人作弊");
            SetLang("LegacyMenu.13", "多人作弊");
            SetLang("LegacyInterface.50", "试一下你");
            SetLang("NPCName.SkeletronHead", "这是个难的过分的Boss");
            SetLang("NPCName.SkeletronHand", "手");
            SetLang("Achievements.FISH_OUT_OF_WATER_Description", "打败猪龙鱼公爵，记得使用铁轨，不然会死的很快。");
            SetLang("Achievements.BONED_Name", "骷髅之星星炮");
            SetLang("Achievements.BONED_Description", "打败骷髅王，这是个难的过分的Boss，不过手没了就好了，可以庄心躲骷髅，记得用星星炮，别说你没有史莱姆王。");
            SetLang("Achievements.OBTAIN_HAMMER_Name", "停！EZ时间到！");
            SetLang("Achievements.OBTAIN_HAMMER_Description", "制作一把实锤，并用它实锤Ningishu以获得金钱，知名度，热度。");
        }
        public override void PostUpdateEverything()
        {
        }
        public override void Unload()
        {
            base.Unload();
            Main.logoTexture = logo1;
            Main.logo2Texture = logo2;
            Form alphaForm = new Form();
            alphaForm.Text = "实锤你尝试卸载此mod!不过mod确实已被你卸载。(你或许没有卸载？谁在乎呢)";
            Main.instance.Window.Title = "实锤你尝试卸载此mod!不过mod确实已被你卸载。(你或许没有卸载？谁在乎呢)";
            alphaForm.Size = new System.Drawing.Size(1500, 20);
            //alphaForm.ShowDialog();
            //new Main();
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            string talk = player.GetModPlayer<EzficPlayer>().nowSaying;
            float v = GetStringLength(Main.fontMouseText, talk, 0.8f);
            if (player.GetModPlayer<EzficPlayer>().talkActive > 0)
            {
                Terraria.Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, talk, (player.Center.X - Main.screenPosition.X) / Main.UIScale - (0.5f * v * Main.GameZoomTarget), (player.position.Y - Main.screenPosition.Y) / Main.UIScale - (30 * Main.GameZoomTarget),
                new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor),
                Color.Black, new Vector2(0, 0), 0.8f * Main.GameZoomTarget);
            }
        }
        public static bool SetLang(string key, string text)
        {
            FieldInfo alphaInfo = typeof(LanguageManager).GetField("_localizedTexts", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, LocalizedText> dic = (Dictionary<string, LocalizedText>)alphaInfo.GetValue(LanguageManager.Instance);
            LocalizedText alphaText;
            if (dic.TryGetValue(key, out alphaText))
            {
                MethodInfo betaInfo = alphaText.GetType().GetMethod("SetValue", BindingFlags.NonPublic | BindingFlags.Instance);
                object[] alphaObj = { text };
                betaInfo.Invoke(alphaText, alphaObj);
                dic.Remove(key);
                dic.Add(key, alphaText);
                return true;
            }
            return false;
        }
        public static float GetStringLength(DynamicSpriteFont font, string text, float scale)
        {
            return font.MeasureString(text).X * scale;
        }
        public static float GetStringHeight(DynamicSpriteFont font, string text, float scale)
        {
            return font.MeasureString(text).Y * scale;
        }
        public static Vector2 GetStringSize(DynamicSpriteFont font, string text, float scale)
        {
            return font.MeasureString(text) * scale;
        }
    }
}

