using HarmonyLib;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_PassOut")]
internal class PassOut
{
    
    [HarmonyPostfix]
    static void SignalCharacterPassOut(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just went to sleep!");
        Plugin.instance.Broadcast(__instance.characterName + " just went to sleep!");
    }
}