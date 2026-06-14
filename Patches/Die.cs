using HarmonyLib;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Die")]
internal class Die
{
    
    [HarmonyPostfix]
    static void SignalCharacterDie(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just died!");
        Plugin.instance.Broadcast(__instance.characterName + " just died!");
    }
}