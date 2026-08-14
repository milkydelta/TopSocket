using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;
using UnityEngine;

#pragma warning disable Harmony003 //stops complaints on statusType.ToString()

namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "SubtractStatus")]
internal class SubtractStatus
{

    static void Prefix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType, out float __state)
    {
        __state = AddStatus.GetNumber(__instance, statusType);
    }
    static void Postfix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType, float __state)
    {
        float current = AddStatus.GetNumber(__instance, statusType);

        if (__state == current) {return;}

        JEventStatus stat = new JEventStatus();
        stat.method = JEventStatus.UpdateType.Sub;
        stat.type = statusType.ToString();
        stat.change = __state-current;
        stat.change = Mathf.Round(stat.change / CharacterAfflictions.STATUS_INCREMENT) * CharacterAfflictions.STATUS_INCREMENT;
        stat.newVal = current;
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventStatus>("changeStatus", stat)));
    }
}