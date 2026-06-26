using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_PassOut")]
internal class PassOut
{
    
    [HarmonyPostfix]
    static void SignalCharacterPassOut(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just went to sleep!");
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("passOut", new JCharacter(__instance))));
    }
}