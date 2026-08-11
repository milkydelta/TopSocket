
using System.Collections.Generic;

namespace TopSocket.JSON;

internal class JStatus
{
    public JGame game = new JGame();
    //definitely an object for the local player (check Character.localPlayer)
    public JPlayer localPlayer = null;
    //maybe an object for the current run (MapHandler and RunManager)
    private List<JPlayer> players = new List<JPlayer>();

    public JMap map = new JMap();

    public JRun run = null;

    public JStatus()
    {
        if (Player.localPlayer != null)
        {
            localPlayer = new JPlayer(Player.localPlayer);
        }

        foreach (Player item in PlayerHandler.GetAllPlayers())
        {
            players.Add(new JPlayer(item));
        }

        if (GameHandler.IsOnIslandAndInitialized)
        {
            run = new JRun();
        }
    }
}