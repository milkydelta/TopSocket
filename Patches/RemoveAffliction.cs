using HarmonyLib;
using Peak.Afflictions;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterAfflictions), "RemoveAffliction",[typeof(Affliction), typeof(bool), typeof(bool)])]
internal class RemoveAffliction
{
    static void Postfix(CharacterAfflictions __instance, Affliction affliction)
    {
        string ae = __instance.character.characterName + " -AFF " + affliction.GetAfflictionType();
        Plugin.Logger.LogInfo(ae);
        Plugin.instance.Broadcast(ae);
    }
}