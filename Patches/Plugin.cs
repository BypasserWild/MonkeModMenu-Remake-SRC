using BepInEx;
using MonkeModMenu.Patches;
using System.ComponentModel;

namespace MonkeModMenu.Patches
{
    [Description(MonkeModMenu.PluginInfo.Description)]
    [BepInPlugin(MonkeModMenu.PluginInfo.GUID, MonkeModMenu.PluginInfo.Name, MonkeModMenu.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }
    }
}
