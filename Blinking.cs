using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Blinking
{
	public class Blinking : Mod
	{
		public static ModKeybind Blink;
		
        public override void Load()
        {
            Blink = KeybindLoader.RegisterKeybind(this, "Blink", "LeftAlt");
        }
        
        public override void Unload()
        {
            Blink = null;
        }
    }
}