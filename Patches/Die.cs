using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Die")]
internal class Die
{
    
    [HarmonyPostfix]
    static void SignalCharacterDie(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just died!");
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("die", new JCharacter(__instance))));
    }
}