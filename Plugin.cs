using BepInEx;
using HarmonyLib;

namespace SkipTutorial
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! Applying patch...");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
    [HarmonyPatch(typeof(OnboardingManager), "Start")]
    public static class OnboardingManager_Start_Patch
    {
        public static void Prefix(OnboardingManager __instance)
        {
            __instance.Step = 19;
        }
    }
}
