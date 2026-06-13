using WebSocketSharp;
using WebSocketSharp.Server;

namespace TopSocket;

internal class WSBehaviour : WebSocketBehavior
{
    private Plugin plugin;

    public void AddToEventHandler(Plugin plug)
    {
        plugin = plug;
        plugin.BroadcastEvent += SendText;
    }

    void SendText(object src, BroadcastEventArgs e)
    {
        Send(e.text);
    }

    protected override void OnOpen()
    {
        if (Plugin.instance != null) { AddToEventHandler(Plugin.instance); }

        Plugin.Logger.LogInfo("WebSocket Open from " + this.Context.UserEndPoint);
        Send("hello!");
    }
    protected override void OnClose(CloseEventArgs e)
    {
        plugin.BroadcastEvent -= SendText;
    }
}
