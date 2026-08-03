using HarmonyLib;
using Newtonsoft.Json;
using Peak.Afflictions;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "RemoveAffliction",[typeof(Affliction), typeof(bool), typeof(bool)])]
internal class RemoveAffliction
{
    static void Postfix(CharacterAfflictions __instance, Affliction affliction)
    {

        Affliction.AfflictionType type = affliction.GetAfflictionType();

        JEventCharacterString stat = new JEventCharacterString();
        stat.str = type.ToString();
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventCharacterString>("removeAffliction", stat)));
    }
}