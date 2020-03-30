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
            SetLang("LegacyMenu.12", "单人作弊");
            SetLang("LegacyMenu.13", "多人作弊");
            SetLang("LegacyInterface.50", "试一下你");
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
            alphaForm.Size = new System.Drawing.Size(1500, 20);
            //alphaForm.ShowDialog();
            //new Main();
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
    }
}

