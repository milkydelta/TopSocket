using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;

#pragma warning disable Harmony003 //stops complaints on statusType.ToString()

namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "SubtractStatus")]
internal class SubtractStatus
{
    static float holding;

    static void Prefix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType)
    {
        holding = __instance.GetCurrentStatus(statusType);
    }
    static void Postfix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType)
    {
        float current = __instance.GetCurrentStatus(statusType);

        if (holding == current) {return;}

        //string ae = __instance.character.characterName + " SUB " + statusType + (holding-current);
        //Plugin.Logger.LogInfo(ae);
        //Plugin.instance.Broadcast(ae);

        JEventStatus stat = new JEventStatus();
        stat.method = JEventStatus.UpdateType.Sub;
        stat.type = statusType.ToString();
        stat.change = holding-current;
        stat.newVal = current;
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventStatus>("changeStatus", stat)));
    }
}