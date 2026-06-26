using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Zombify")]
internal class Zombify
{
    
    static void Postfix(Character __instance)
    {
        Plugin.Logger.LogInfo(__instance.characterName + " just became an undead!");
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("zombify", new JCharacter(__instance))));
    }
}