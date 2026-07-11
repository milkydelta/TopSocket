using System.Collections;
using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(LoadingScreenHandler), "LoadSceneProcess")]
internal class LoadSceneProcess
{
    static void Prefix(string sceneName)
    {
        Plugin.Logger.LogInfo("Loading Scene " + sceneName);
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<string>("loadSceneStart", sceneName)));
        
    }

    static IEnumerator Postfix(IEnumerator __result, string sceneName)
    {
        //IENumerator nonsense
        while (__result.MoveNext())
            yield return __result.Current;

        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<string>("loadSceneEnd", sceneName)));
    }
}