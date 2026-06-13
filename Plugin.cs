using System;
using BepInEx;
using BepInEx.Logging;
using Newtonsoft.Json;
using WebSocketSharp.Server;
using WebSocketSharp;
using System.IO;
using System.Text;
using HarmonyLib;

namespace TopSocket;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    static HttpServer srv;

    internal event BroadcastEventHandler BroadcastEvent;

    internal static Plugin instance;

    internal Harmony harmony;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        
        instance = this;
        
        srv = new HttpServer(9347);
        srv.OnGet += HttpOnGet;
        srv.AddWebSocketService<WSBehaviour>("/sock");
        srv.Start();

        harmony = Harmony.CreateAndPatchAll(typeof(Patches));

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");        
    }

    private void HttpOnGet(object sender, HttpRequestEventArgs e)
    {
        Logger.LogInfo("HTTP GET!");
        if (e.Request.RawUrl != "/status.json")
        {
            e.Response.StatusCode = 404;
            return;
        }

        e.Response.StatusCode = 200;
        e.Response.ContentType = "application/json";

        /* - For some reason, stream isn't working. I guess I am allocating a string, then.
        
        //Use streams so I'm not allocating a string
        using (StreamWriter sw = new StreamWriter(e.Response.OutputStream))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            JsonSerializer serializer = new JsonSerializer();

            serializer.Serialize(writer, new JSStatus());
        }
        */

        string jsoncontent = JsonConvert.SerializeObject(new JSON.JStatus());
        e.Response.WriteContent(Encoding.UTF8.GetBytes(jsoncontent));

        e.Response.Close();
    }

    internal void Broadcast(string text)
    {
        Logger.LogInfo("Try Broadcast:"+text);
        //Apparently, WebSocketSharp's Broadcast function is broken in some way.
        //My editor insists it's there. I can get the overloads and their descriptions.
        //If I try to call it, though, I get this:
        // MissingMethodException: Method not found: void WebSocketSharp.Server.WebSocketServiceManager.Broadcast(string)
        //That happens if I call it from this class, or from a Harmony patch.

        //So I'm going to need to write a replacement.

        //srv.WebSocketServices.Broadcast(text);
        try{
            BroadcastEvent?.Invoke(this, new BroadcastEventArgs(text));
        }
        catch (Exception e){
            Logger.LogError("Exception in Plugin.Broadcast");
            Logger.LogError(e.ToString());
        }
        
    }

    private void OnDestroy()
    {
        srv.Stop();
        Logger.LogInfo("Stopped Server");
    }
}
