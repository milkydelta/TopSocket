## HTTP

```
curl http://127.0.0.1:9347/status.json | jq .

{
  "game": {
    "pluginVersion": "0.3.0",
    "gameVersion": "1.65.a",
    "scene": "Pretitle",
    "offlineMode": false,
    "host": false
  },
  "localPlayer": null,
  "map": {
    "levelIndex": 422,
    "secondsRemaining": "NaN",
    "msg": "",
    "levelName": "Level_2",
    "levelBiomes": "SRAV"
  },
  "run": null
}
```

```
curl http://127.0.0.1:9347/status.json | jq .

{
  "game": {
    "pluginVersion": "0.3.0",
    "gameVersion": "1.65.a",
    "scene": "Title",
    "offlineMode": false,
    "host": false
  },
  "localPlayer": null,
  "map": {
    "levelIndex": 422,
    "secondsRemaining": 36724.18,
    "msg": "no new update today we're playing big walk",
    "levelName": "Level_2",
    "levelBiomes": "SRAV"
  },
  "run": null
}
```

```
curl http://127.0.0.1:9347/status.json | jq .

{
  "game": {
    "pluginVersion": "0.3.0",
    "gameVersion": "1.65.a",
    "scene": "Airport",
    "offlineMode": true,
    "host": true
  },
  "localPlayer": {
    "character": {
      "name": "milkydelta",
      "isLocal": true,
      "isDead": false,
      "isZombie": false,
      "isSkeleton": false,
      "stamina": 1.0,
      "exStamina": 0.0
    },
    "i0": {
      "name": "Passport",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "i1": null,
    "i2": null,
    "iT": null,
    "backpack": null,
    "selectedSlot": 0
  },
  "map": {
    "levelIndex": 422,
    "secondsRemaining": 36504.78,
    "msg": "no new update today we're playing big walk",
    "levelName": "Level_2",
    "levelBiomes": "SRAV"
  },
  "run": null
}
```

```
curl http://127.0.0.1:9347/status.json | jq .

{
  "game": {
    "pluginVersion": "0.3.0",
    "gameVersion": "1.65.a",
    "scene": "Level_2",
    "offlineMode": true,
    "host": true
  },
  "localPlayer": {
    "character": {
      "name": "milkydelta",
      "isLocal": true,
      "isDead": false,
      "isZombie": false,
      "isSkeleton": false,
      "stamina": 0.7,
      "exStamina": 0.0
    },
    "i0": {
      "name": "Lantern",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": 0.8284919
    },
    "i1": {
      "name": "Bing Bong",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "i2": {
      "name": "Scout Cannon",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "iT": {
      "name": "Flare",
      "cookState": 0,
      "totalUses": 1,
      "uses": 0,
      "percentage": 0.0
    },
    "backpack": {
      "i0": {
        "name": "rope spool",
        "cookState": 0,
        "totalUses": -1,
        "uses": -1,
        "percentage": 1.0
      },
      "i1": {
        "name": "Bandages",
        "cookState": 0,
        "totalUses": -1,
        "uses": -1,
        "percentage": -1.0
      },
      "i2": {
        "name": "Piton",
        "cookState": 0,
        "totalUses": -1,
        "uses": -1,
        "percentage": -1.0
      },
      "i3": {
        "name": "Bugle",
        "cookState": 6,
        "totalUses": -1,
        "uses": -1,
        "percentage": -1.0
      },
      "name": "Backpack",
      "cookState": 2,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "selectedSlot": 250
  },
  "map": {
    "levelIndex": 422,
    "secondsRemaining": 36150.77,
    "msg": "no new update today we're playing big walk",
    "levelName": "Level_2",
    "levelBiomes": "SRAV"
  },
  "run": {
    "elapsed": 173.6935,
    "id": "1088dd51-2307-4ed4-8056-81ee54a8cc97",
    "day": {
      "count": 1,
      "isDay": true,
      "time": 16.086853
    },
    "currentSegment": 0,
    "currentBiome": "Shore"
  }
}
```

## WebSocket

### On Connect
```
{"eventType":"greetings","time":"2026-08-11T06:59:50.9327267Z","data":{"game":{"pluginVersion":"0.3.0","gameVersion":"1.65.a","scene":"Title","offlineMode":false,"host":false},"localPlayer":null,"map":{"levelIndex":422,"secondsRemaining":36009.0156,"msg":"no new update today we're playing big walk","levelName":"Level_2","levelBiomes":"SRAV"},"run":null}}
```

### Scene Load
```
{"eventType":"loadSceneStart","time":"2026-08-03T16:02:53.7462793Z","data":"Airport"}
{"eventType":"loadSceneEnd","time":"2026-08-03T16:03:01.4743182Z","data":"Airport"}
```

### Fall Over 
For this, I used the "Play Dead" emote. The "value" float is duration in seconds.
```
{"eventType":"fall","time":"2026-08-11T07:01:16.5412799Z","data":{"value":3.0,"chr":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":1.0,"exStamina":0.0}}}
```

### Leave Game
For when you return to the title screen.
```
{"eventType":"leaveGame","time":"2026-08-03T16:05:13.2009815Z","data":null}
```

### Status Effect Changes
```
{"eventType":"changeStatus","time":"2026-08-11T07:04:21.8854889Z","data":{"method":"Add","type":"Hot","change":0.05,"newVal":0.1,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.9,"exStamina":0.0}}}
{"eventType":"changeStatus","time":"2026-08-11T07:04:36.7345864Z","data":{"method":"Sub","type":"Hot","change":0.025,"newVal":0.125,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.85,"exStamina":0.0}}}
{"eventType":"changeStatus","time":"2026-08-11T07:07:13.6386197Z","data":{"method":"Set","type":"Weight","change":0.0,"newVal":0.175,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.825,"exStamina":0.0}}}
```

### Pass Out

```
{"eventType":"passOut","time":"2026-08-11T07:08:41.5042116Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.0,"exStamina":0.0}}
{"eventType":"unPassOut","time":"2026-08-11T07:10:13.8609287Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.003332,"exStamina":0.0}}
```

Zombies are still characters and will also send this event.

```
{"eventType":"unPassOut","time":"2026-08-11T08:15:22.6286876Z","data":{"name":"Bot","isLocal":false,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":1.0,"exStamina":0.0}}
```

### Afflictions
For this, I drank some fortified milk.
Some Afflictions (usually ones that are instantaneous) will only send the remove event.
```
{"eventType":"addAffliction","time":"2026-08-11T07:11:40.4535884Z","data":{"str":"Invincibility","chr":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.975,"exStamina":0.0}}}
{"eventType":"removeAffliction","time":"2026-08-11T07:12:05.4227767Z","data":{"str":"Invincibility","chr":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":1.0,"exStamina":0.0}}}
```

### Die
Dead players can still experience `changeStatus` and `removeAffliction`.
```
{"eventType":"die","time":"2026-08-11T07:14:11.0457121Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":false,"isSkeleton":false,"stamina":0.0,"exStamina":0.0}}
```

### Skeleton
This event does not trigger on death, unless you die as a skeleton. Here, I used the Book of Bones, and then died.
```
{"eventType":"setSkeleton","time":"2026-08-11T07:16:03.8775384Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":true,"stamina":0.95,"exStamina":0.0}}
{"eventType":"setSkeleton","time":"2026-08-11T07:16:26.6127036Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":false,"isSkeleton":false,"stamina":0.0,"exStamina":0.0}}
```

### Zombify
If you meet the conditions for zombification, this will trigger **instead of** the `die` event.
```
{"eventType":"zombify","time":"2026-08-11T07:30:21.5395914Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":true,"isSkeleton":false,"stamina":0.0,"exStamina":0.0}}
```

### Revive
```
{"eventType":"revive","time":"2026-08-11T08:42:01.5707107Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.0,"exStamina":0.0}}
```
### Out Of Stamina
For when a character is *completely* out of stamina (bonus included)

This will also trigger when a character spawns, but will not trigger during loading screens.

```
{"eventType":"outOfStamina","time":"2026-08-11T07:44:40.1454096Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false,"stamina":0.003972303,"exStamina":0.0}}
```

### Day/Night Cycle

Sent every in-game hour.
The count ticks over at 5.5.
"isDay" becomes false at 21, and becomes true at 5.
```
{"eventType":"dayNight","time":"2026-08-11T07:45:59.0474552Z","data":{"count":1,"isDay":true,"time":10.0006943}}
```

### Go To Segment

Here, I lit the campfire at the end of the Shore.
```
{"eventType":"gotoSegment","time":"2026-08-11T08:07:54.8890871Z","data":1}
```

### End Game

The bool is for if you won. Here, I lit the campfire at the end of a mini-run. In that case, and when all party members die, `endGame` triggers just before the scouting report appears.

If you reach the PEAK, this should trigger at the start of the cutscene. I haven't done that, so can't say with certainty.

The world is still active and ticking while the scout report is on screen.
You will continue to receive time, affliction, and status events until the airport scene loads.

```
{"eventType":"endGame","time":"2026-08-11T08:43:33.0654107Z","data":true}
```
