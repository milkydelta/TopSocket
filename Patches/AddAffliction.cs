using HarmonyLib;
using Peak.Afflictions;
using TopSocket.JSON;
using Newtonsoft.Json;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "AddAffliction")]
internal class AddAffliction
{
    static bool then;

    static void Prefix(CharacterAfflictions __instance, Affliction affliction)
    {
        if (affliction == null){return;}

        Affliction a;
        then = __instance.HasAfflictionType(affliction.GetAfflictionType(), out a);
    }
    static void Postfix(CharacterAfflictions __instance, Affliction affliction)
    {
        if (affliction == null){return;}

        Affliction.AfflictionType type = affliction.GetAfflictionType();
        Affliction a;

        bool now = __instance.HasAfflictionType(type, out a);

        if (!(!then && now)){return;}

        JEventCharacterString stat = new JEventCharacterString();
        stat.str = type.ToString();
        stat.character = new JCharacter(__instance.character);

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JEventCharacterString>("addAffliction", stat)));
    }
}