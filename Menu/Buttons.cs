using MonkeModMenu.Classes;
using static MonkeModMenu.Settings;
using static MonkeModMenu.Mods.MoveMent;
using static MonkeModMenu.Mods.Visuals;

namespace MonkeModMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] {
                new ButtonInfo { buttonText = "Super Monk V2", method =() => SuperMonk(), isTogglable = true},
                new ButtonInfo { buttonText = "Anti-Gravity", method =() => NoGrav(), isTogglable = true},
                new ButtonInfo { buttonText = "Tag Gun", method =() => FlickTagGun(), isTogglable = true},
                new ButtonInfo { buttonText = "Speed Boost", method =() => SpeedBoost(true), disableMethod =() => SpeedBoost(false), isTogglable = true},
                new ButtonInfo { buttonText = "Tag All", method =() => TagAll(), isTogglable = true},
                new ButtonInfo { buttonText = "Turn Off Tag Freeze", method =() => GorillaLocomotion.Player.Instance.disableMovement = false, isTogglable = true},
                new ButtonInfo { buttonText = "Beacon", method =() => Beacons(), isTogglable = true},
            },
        };
    }
}
