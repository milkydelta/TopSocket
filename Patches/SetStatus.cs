using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;

#pragma warning disable Harmony003 //stops complaints on statusType.ToString()

namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "SetStatus")]
internal class SetStatus
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
        stat.method = JEventStatus.UpdateType.Set;
        stat.type = statusType.ToString();
        stat.change = 0;
        stat.newVal = current;
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventStatus>("changeStatus", stat)));
    }
}