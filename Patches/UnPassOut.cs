using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_UnPassOut")]
internal class UnPassOut
{
    
    [HarmonyPostfix]
    static void SignalCharacterUnPassOut(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just woke up!");
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("unPassOut", new JCharacter(__instance))));
    }
}