using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;

#pragma warning disable Harmony003 //stops complaints on statusType.ToString()

namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "AddStatus")]
internal class AddStatus
{
    static float holding;

    static void Prefix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType, float amount)
    {
        holding = __instance.GetCurrentStatus(statusType);
    }
    static void Postfix(CharacterAfflictions __instance, bool __result, CharacterAfflictions.STATUSTYPE statusType, float amount)
    {
        float current = __instance.GetCurrentStatus(statusType);

        if (!__result || holding == current) {return;}

        //string ae = __instance.character.characterName + " ADD " + statusType + (current-holding);
        //Plugin.Logger.LogInfo(ae);
        

        JEventStatus stat = new JEventStatus();
        stat.method = JEventStatus.UpdateType.Add;
        stat.type = statusType.ToString();
        stat.change = current-holding;
        stat.newVal = current;
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventStatus>("changeStatus", stat)));
    }
}