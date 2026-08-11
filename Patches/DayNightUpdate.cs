using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;
using UnityEngine;

namespace TopSocket.Patches;

[HarmonyPatch(typeof(DayNightManager), "Update")]
internal class DayNightUpdate
{

    static void Prefix(DayNightManager __instance, out float __state)
    {
        //__state = __instance.isDay;
        __state = Mathf.Floor(__instance.timeOfDay);
    }
    static void Postfix(DayNightManager __instance, float __state)
    {
        //float isD = __instance.isDay;
        float isD = Mathf.Floor(__instance.timeOfDay);
        if(__state != isD){
            Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JDay>("dayNight", new JDay())));   
        }     
    }
}