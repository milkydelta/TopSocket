using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(MapHandler), "GoToSegment")]
internal class GoToSegment
{
    static void Postfix(Segment __0)
    {
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<byte>("gotoSegment", (byte)__0)));
    }
}