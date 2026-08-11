using System;
using System.Collections.Generic;
using Zorro.Core;

namespace TopSocket.JSON;

internal class JMap
{
    // private List<Biome.BiomeType> biomes = new List<Biome.BiomeType>();

    public int levelIndex = -1;
    public float secondsRemaining = Single.NaN;

    public string msg = "";
    public string levelName = "";
    public string levelBiomes = "";


    public JMap()
    {
        // var mh = MapHandler.Instance;
        // if (mh != null)
        // {
        //     foreach (var seg in mh.segments)
        //     {
        //         biomes.Add(seg.biome);
        //     }
        // }

        var nls = GameHandler.GetService<NextLevelService>();
        if (nls != null)
        {
            levelIndex=nls.NextLevelIndexOrFallback;
            if (nls.Data.IsSome)
            {
                var dat = nls.Data.Value;

                float startupTimeOfNextMap = dat.StartupTimeWhenQueried + dat.SecondsLeftFromQueryTime;
                secondsRemaining = startupTimeOfNextMap - UnityEngine.Time.realtimeSinceStartup;

                msg = dat.DevMessage;
            }
        }

        var mb = MapBaker.Instance;
        if (mb != null && levelIndex != -1)
        {
            levelName = mb.GetLevel(levelIndex);
            levelBiomes = mb.GetBiomeID(levelIndex);
        }
    }

}