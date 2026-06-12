using WebSocketSharp;
using WebSocketSharp.Server;

namespace TopSocket;

internal class WSBehaviour : WebSocketBehavior
{
    protected override void OnOpen()
    {
        Plugin.Logger.LogInfo("WebSocket Open");
        Send("hello!");
    }
}