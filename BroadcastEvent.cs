using System;

namespace TopSocket;

internal class BroadcastEventArgs : EventArgs
{
    internal string text {get;}
    // Would an extra field make sense here?
    // If Send() is given a byte array, it transmits in data mode, instead of text mode.
    public BroadcastEventArgs(string txt) {
        text = txt;
    }
}

internal delegate void BroadcastEventHandler(object src, BroadcastEventArgs e);
