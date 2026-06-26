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
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<string>("loadScene", sceneName)));
    }
}