using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(Player), "LeaveCurrentGame")]
internal class LeaveCurrentGame
{
    static void Postfix()
    {
        Plugin.Logger.LogInfo("Leaving Game");
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<string>("leaveGame", null)));
    }
}