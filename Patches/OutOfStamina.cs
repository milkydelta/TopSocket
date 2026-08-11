using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "OutOfStamina")]
internal class OutOfStamine
{
    static void Postfix(bool __result, Character __instance)
    {
        if (LoadingScreenHandler.loading || !IsSliding.inside){return;}

        if (__result) //We are out of stamina
        {
            if (__instance.data.outOfStaminaFor == 0f) // but we weren't before
            {
                Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("outOfStamina", new JCharacter(__instance))));
            }
        }
        else
        {

        }
    }
}

[HarmonyPatch(typeof(Character), "UpdateVariablesFixed")] //turns out that OutOfStamina is called from a *lot* of places
internal class IsSliding 
{
    internal static bool inside = false;

    static void Prefix()
    {
        inside = true;
    }


    static void Postfix()
    {
        inside = false;
    }
}