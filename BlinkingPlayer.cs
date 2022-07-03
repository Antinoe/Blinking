using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Audio;
using System.Runtime.CompilerServices;

namespace Blinking
{
    public class BlinkingPlayer : ModPlayer
    {
		public bool blinking = false;
		public int blinkTimer = 0;
		public int blinkCooldown = BlinkingConfig.Instance.blinkCooldown;
		
		public static BlinkingPlayer ModPlayer(Player Player)
		{
			return Player.GetModPlayer<BlinkingPlayer>();
		}
		
		//Resetting the Booleans is important, as some of them may not reset by themselves.
		/*public override void ResetEffects()
		{
			blinking = false;
		}*/
		
		public override void PostUpdateMiscEffects() //Core.
		{
			//Various attempts to get this working are below. (Found out that IL Editing is required.. eugh...)
			//PlayerTextureID = PlayerTextureID.EyeBlink;
			//PlayerTextureID playerTexID = PlayerTextureID.EyeBlink;
			//PlayerTextureID.EyeBlink;
			//PlayerEyeHelper.EyeFrameToShow = PlayerTextureID.EyeBlink;
			//PlayerEyeHelper.EyeFrameToShow == PlayerEyeHelper.EyeFrame.EyeClosed;
			//_state == EyeState.JustTookDamage;
			//PlayerEyeHelper._state = 1;
			//PlayerEyeHelper.EyeState = 1;
			//PlayerEyeHelper.EyeFrameToShow == 1;
			//Player.eyeHelper.EyeFrameToShow = 1;
			
			if (blinking)
			{
				blinkCooldown = BlinkingConfig.Instance.blinkCooldown;
				if (BlinkingConfig.Instance.enableBlinkAggro)
				{
					Player.aggro -= BlinkingConfig.Instance.blinkAggro;
				}
				if (BlinkingConfig.Instance.applyBlackout)
				{
					Player.blackout = true;
				}
				if (BlinkingConfig.Instance.applyObstructed)
				{
					Player.AddBuff(BuffID.Obstructed, 1);
				}
			}
			
			//Manual Blinking
			if (Blinking.Blink.Current && BlinkingConfig.Instance.enableBlinking && BlinkingConfig.Instance.enableManualBlinking)
			{
				blinking = true;
			}
			
			if (Blinking.Blink.JustPressed && BlinkingConfig.Instance.enableBlinking && BlinkingConfig.Instance.enableManualBlinking)
			{
				blinkTimer = BlinkingConfig.Instance.blinkTimer;
			}
			
			//Automatic Blinking
			if (blinkCooldown <= 0 && BlinkingConfig.Instance.enableBlinking && BlinkingConfig.Instance.enableAutomaticBlinking)
			{
				blinkTimer = BlinkingConfig.Instance.blinkTimer;
			}
			if (BlinkingConfig.Instance.enableBlinking && blinkCooldown >= 0)
			{
				blinkCooldown--;
			}
			
			//Blink Timer (How long to Blink.)
			if (blinkTimer > 0 && BlinkingConfig.Instance.enableBlinking && BlinkingConfig.Instance.enableAutomaticBlinking)
			{
				blinkTimer--;
				blinking = true;
			}
			else if (!Blinking.Blink.Current)
			{
				blinking = false;
			}
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
			if (BlinkingConfig.Instance.enableBlinkingFromDamage)
			{
				blinkTimer = BlinkingConfig.Instance.blinkTimer;
			}
        }
		
		//IL Editing stuff. (Gross...)
		/*public override void ResetEffects()
		{
			EyeFrameHelper1.SetEyeFrame(Player.eyeHelper, 1);
			EyeFrameHelper2.SetEyeFrame(Player.eyeHelper, 1);
		}
		
		public static class EyeFrameHelper1
		{
			private static readonly PropertyInfo eyeFrameProperty =
				typeof(PlayerEyeHelper).GetProperty(nameof(PlayerEyeHelper.EyeFrameToShow), BindingFlags.Instance | BindingFlags.Public)!;
			
			private static readonly MethodInfo eyeFrameSetterMethod = eyeFrameProperty.SetMethod!;
			
			public static void SetEyeFrame(PlayerEyeHelper eyeHelper, int eyeFrame)
			{
				eyeFrameSetterMethod.Invoke(eyeHelper, new object[] { eyeFrame });
			}
		}
		
		public static class EyeFrameHelper2
		{
			private static readonly PropertyInfo eyeFrameProperty =
				typeof(PlayerEyeHelper).GetProperty(nameof(PlayerEyeHelper.EyeFrameToShow), BindingFlags.Instance | BindingFlags.Public)!;
			
			private static readonly MethodInfo eyeFrameSetterMethod = eyeFrameProperty.SetMethod!;
			private static readonly object[]   singleSlotArray      = new object[1];
			
			public static void SetEyeFrame(PlayerEyeHelper eyeHelper, int eyeFrame)
			{
				singleSlotArray[0] = eyeFrame;
				eyeFrameSetterMethod.Invoke(eyeHelper, singleSlotArray);
			}
		}*/
	}
}