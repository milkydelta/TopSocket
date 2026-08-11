using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TopSocket.JSON;

//[JsonConverter(typeof(StringEnumConverter))]
internal class JRun
{
    public float elapsed;
    public System.Guid id;
    public JDay day = new JDay();

    public Segment currentSegment;

    [JsonConverter(typeof(StringEnumConverter))]
    public Biome.BiomeType currentBiome;



    public JRun()
    {
        var rm = RunManager.Instance;
        if (rm != null)
        {
            elapsed = rm.TimeSinceRunStarted;
            id = rm.RunId;
        }

        var mh = MapHandler.Instance;
        if (mh != null)
        {
            currentSegment = mh.GetCurrentSegment();
            currentBiome = mh.GetCurrentBiome();
        }

        //var mph = MountainProgressHandler.Instance;
        //if (mph != null)
        //{
        //    
        //}
    }
}