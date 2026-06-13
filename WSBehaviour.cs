using WebSocketSharp;
using WebSocketSharp.Server;

namespace TopSocket;

internal class WSBehaviour : WebSocketBehavior
{
    private Plugin plugin;

    public void AddToEventHandler (Plugin plug)
    {
        plugin = plug;
        plugin.BroadcastEvent += SendText;
    }

    void SendText(object src, BroadcastEventArgs e){
        Send(e.text);
    }

    protected override void OnOpen()
    {
        Plugin.Logger.LogInfo("WebSocket Open");
        Send("hello!");
    }
}
