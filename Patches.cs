using System;
using HarmonyLib;

namespace TopSocket;
class Patches
{
    [HarmonyPatch(typeof(Character), "RPCA_Die")]
    [HarmonyPostfix]
    static void SignalCharacterDie(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just died!");
        Plugin.Broadcast(__instance.characterName + " just died!");
    }
    [HarmonyPatch(typeof(Character), "RPCA_Fall")]
    [HarmonyPostfix]
    static void SignalCharacterFall(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just fell!");
        Plugin.Broadcast(__instance.characterName + " just fell!");
    }
}