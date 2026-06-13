using System;
using HarmonyLib;

namespace TopSocket;
class Patches
{
    internal static Plugin plug;

    [HarmonyPatch(typeof(Character), "RPCA_Die")]
    [HarmonyPostfix]
    static void SignalCharacterDie(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just died!");
        plug.Broadcast(__instance.characterName + " just died!");
    }
    [HarmonyPatch(typeof(Character), "RPCA_Fall")]
    [HarmonyPostfix]
    static void SignalCharacterFall(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just fell!");
        plug.Broadcast(__instance.characterName + " just fell!");
    }
}