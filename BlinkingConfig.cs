using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Blinking
{
    [Label("Server Config")]
    public class BlinkingConfig : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ServerSide;
		
        public static BlinkingConfig Instance;
		
        [Header("General")]
		
        [Label("Enable Blinking")]
        [Tooltip("If false, Players cannot Blink.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableBlinking {get; set;}
		
        [Label("Enable Manual Blinking")]
        [Tooltip("If false, Players cannot manually Blink.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableManualBlinking {get; set;}
		
        [Label("Enable Automatic Blinking")]
        [Tooltip("If false, Players will not automatically Blink.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableAutomaticBlinking {get; set;}
		
        [Label("Enable Blinking From Damage")]
        [Tooltip("If false, Players will not Blink when receiving damage.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableBlinkingFromDamage {get; set;}
		
        [Label("Blink Timer")]
        [Tooltip("How long Blinking lasts.\n[Default: 15]")]
        [Slider]
        [DefaultValue(15)]
        [Range(5, 40)]
        [Increment(5)]
        public int blinkTimer {get; set;}
		
        [Label("Blink Cooldown")]
        [Tooltip("How long until Automatic Blinking occurs.\n[Default: 240]")]
        [Slider]
        [DefaultValue(240)]
        [Range(20, 240)]
        [Increment(20)]
        public int blinkCooldown {get; set;}
		
        [Header("Gameplay")]
		
        [Label("Enable Blink Aggression Reduction")]
        [Tooltip("If true, manually Blinking will reduce Aggression, decreasing the chance for NPCs to target the Player.\n[Default: Off]")]
        [DefaultValue(false)]
        public bool enableBlinkAggro {get; set;}
		
        [Label("Blink Aggression Reduction")]
        [Tooltip("How much holding Blink reduces Player Aggression.\n[Default: 400]")]
        [Slider]
        [DefaultValue(400)]
        [Range(50, 1000)]
        [Increment(50)]
        public int blinkAggro {get; set;}
		
        [Header("Effects")]
		
        [Label("Visual Blinking")]
        [Tooltip("If false, the eyes of Players will not visibly close upon Blinking.\n[Default: On]")]
        [DefaultValue(true)]
        public bool applyBlackout {get; set;}
		
        [Label("Apply Obstructed Debuff")]
        [Tooltip("If true, upon Blinking, the Player's vision will be drastically reduced down to a small circle.\n[Default: On]")]
        [DefaultValue(true)]
        public bool applyObstructed {get; set;}
    }
}