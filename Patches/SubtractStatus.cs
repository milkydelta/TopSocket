using HarmonyLib;

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

        string ae = __instance.character.characterName + " SUB " + statusType + (holding-current);
        Plugin.Logger.LogInfo(ae);
        Plugin.instance.Broadcast(ae);
    }
}