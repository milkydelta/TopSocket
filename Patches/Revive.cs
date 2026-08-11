using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "ReviveCharacter")]
internal class Revive
{
    
    [HarmonyPostfix]
    static void SignalCharacterRevive(Character __instance)
    {
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("revive", new JCharacter(__instance))));
    }
}