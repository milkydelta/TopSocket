using System;

namespace TopSocket;

internal class BroadcastEventArgs : EventArgs
{
    internal string text {get;}
    public BroadcastEventArgs(string txt) {
        text = txt;
    }
}

internal delegate void BroadcastEventHandler(object src, BroadcastEventArgs e);
