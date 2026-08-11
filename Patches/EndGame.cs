using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Character), "RPCEndGame")]
internal class EndGame
{
    static void Postfix(Character __instance)
    {
        if (!__instance.IsLocal) {return;}

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<bool>("endGame", Character.CheckWinCondition(__instance))));
    }
}