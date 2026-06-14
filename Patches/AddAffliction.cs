using HarmonyLib;
using Peak.Afflictions;


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

        string ae = __instance.character.characterName + " +AFF " + type;
        Plugin.Logger.LogInfo(ae);
        Plugin.instance.Broadcast(ae);
    }
}