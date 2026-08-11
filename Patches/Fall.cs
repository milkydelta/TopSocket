using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;

namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Fall")]
internal class Fall
{
    [HarmonyPostfix]
    static void SignalCharacterFall(Character __instance, float __0)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just fell!");
        //Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("fall", new JCharacter(__instance))));
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventCharacterFloat>("fall", new JEventCharacterFloat(new JCharacter(__instance), __0))));
    }
}