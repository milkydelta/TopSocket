using UnityEngine;
using TopSocket;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TopSocket.JSON;

internal class JEventStatus
{
    [JsonConverter(typeof(StringEnumConverter))]
    public UpdateType method;
    public string type;
    public float change;
    public float newVal;
    public JCharacter character;

    internal enum UpdateType
    {
        Add,
        Sub,
        Set
    }
}