## HTTP

```
curl http://127.0.0.1:9347/status.json

{"game":{"pluginVersion":"0.0.2","gameVersion":"1.65.a","scene":"Title","offlineMode":false},"localPlayer":null}
```

```
curl http://127.0.0.1:9347/status.json | jq

{
  "game": {
    "pluginVersion": "0.0.2",
    "gameVersion": "1.65.a",
    "scene": "Airport",
    "offlineMode": false
  },
  "localPlayer": {
    "character": {
      "name": "milkydelta",
      "isLocal": true,
      "isDead": false,
      "isZombie": false,
      "isSkeleton": false
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
    "backpack": null
  }
}
```

```
curl http://127.0.0.1:9347/status.json | jq

{
  "game": {
    "pluginVersion": "0.0.2",
    "gameVersion": "1.65.a",
    "scene": "Level_36",
    "offlineMode": false
  },
  "localPlayer": {
    "character": {
      "name": "milkydelta",
      "isLocal": true,
      "isDead": false,
      "isZombie": false,
      "isSkeleton": false
    },
    "i0": {
      "name": "rope spool",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": 1.0
    },
    "i1": {
      "name": "Checkpoint Flag",
      "cookState": 0,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "i2": {
      "name": "Coconut",
      "cookState": 1,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    },
    "iT": null,
    "backpack": {
      "i0": {
        "name": "Guidebook",
        "cookState": 0,
        "totalUses": -1,
        "uses": -1,
        "percentage": -1.0
      },
      "i1": null,
      "i2": null,
      "i3": null,
      "name": "Backpack",
      "cookState": 3,
      "totalUses": -1,
      "uses": -1,
      "percentage": -1.0
    }
  }
}
```

## WebSocket

### On Connect
```
{"eventType":"greetings","time":"2026-08-03T16:02:01.8920184Z","data":{"game":{"pluginVersion":"0.0.2","gameVersion":"1.65.a","scene":"Title","offlineMode":false},"localPlayer":null}}
```

### Scene Load
```
{"eventType":"loadSceneStart","time":"2026-08-03T16:02:53.7462793Z","data":"Airport"}
{"eventType":"loadSceneEnd","time":"2026-08-03T16:03:01.4743182Z","data":"Airport"}
```

### Fall Over 
For this, I used the "Play Dead" emote.
```
{"eventType":"fall","time":"2026-08-03T16:03:44.928537Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}
```

### Leave Game
```
{"eventType":"leaveGame","time":"2026-08-03T16:05:13.2009815Z","data":null}
```

### Status Effect Changes
```
{"eventType":"changeStatus","time":"2026-08-03T16:10:01.3794341Z","data":{"method":"Add","type":"Hot","change":0.05,"newVal":1.05,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}}
{"eventType":"changeStatus","time":"2026-08-03T16:10:11.3104842Z","data":{"method":"Sub","type":"Hot","change":0.025,"newVal":1.025,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}}
{"eventType":"changeStatus","time":"2026-08-03T16:12:01.9810424Z","data":{"method":"Set","type":"Weight","change":0.0,"newVal":0.125,"character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}}
```

### Pass Out

```
{"eventType":"passOut","time":"2026-08-03T16:10:05.3824543Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}
{"eventType":"unPassOut","time":"2026-08-03T16:10:19.0605233Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}
```

### Afflictions
For this, I drank an energy drink.
Some Afflictions (usually ones that are instantaneous) will only send the remove event.
```
{"eventType":"addAffliction","time":"2026-08-03T16:13:06.7023689Z","data":{"str":"FasterBoi","character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}}
{"eventType":"removeAffliction","time":"2026-08-03T16:13:17.6834244Z","data":{"str":"FasterBoi","character":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":false}}}
```

### Die
Dead players can still experience `changeStatus` and `removeAffliction`.
```
{"eventType":"die","time":"2026-08-03T16:19:10.2832039Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":false,"isSkeleton":false}}
```

### Skeleton
This event does not trigger on death, unless you die as a skeleton. Here, I used the Book of Bones, and then died.
```
{"eventType":"setSkeleton","time":"2026-08-03T16:22:28.05435Z","data":{"name":"milkydelta","isLocal":true,"isDead":false,"isZombie":false,"isSkeleton":true}}
{"eventType":"setSkeleton","time":"2026-08-03T16:24:34.9776155Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":false,"isSkeleton":false}}
```

### Zombify
If you meet the conditions for zombification, this will trigger **instead of** the `die` event.
```
{"eventType":"zombify","time":"2026-08-03T16:28:45.4387431Z","data":{"name":"milkydelta","isLocal":true,"isDead":true,"isZombie":true,"isSkeleton":false}}
```



