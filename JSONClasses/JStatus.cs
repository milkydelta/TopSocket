
namespace TopSocket.JSON;

internal class JStatus
{
    public JGame game = new JGame();
    //definitely an object for the local player (check Character.localPlayer)
    public JCharacter localCharacter = null;
    //maybe an object for the current run (MapHandler and RunManager)

    public JStatus()
    {
        if (Character.localCharacter != null)
        {
            localCharacter = new JCharacter(Character.localCharacter);
        }
    }
}