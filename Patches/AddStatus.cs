using HarmonyLib;


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

        string ae = __instance.character.characterName + " ADD " + statusType + (current-holding);
        Plugin.Logger.LogInfo(ae);
        Plugin.instance.Broadcast(ae);
    }
}