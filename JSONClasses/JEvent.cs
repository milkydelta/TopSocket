using System;

namespace TopSocket.JSON;

internal class JEvent<T>
{
    public string eventType;

    public DateTime time = DateTime.UtcNow;

    public T data;

    public JEvent(string type, T obj){
        eventType = type;
        data = obj;
    }
}