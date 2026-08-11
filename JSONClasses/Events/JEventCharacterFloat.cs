using UnityEngine;
using TopSocket;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TopSocket.JSON;

internal class JEventCharacterFloat
{
    public float value;
    public JCharacter chr;

    public JEventCharacterFloat(JCharacter c, float f)
    {
        value = f;
        chr = c;
    }
}