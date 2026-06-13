
namespace TopSocket.JSON;

internal class JCharacter
{
    public string name;
    public bool isLocal;

    public JCharacter(Character chr)
    {
        name = chr.characterName;
        isLocal = chr.IsLocal;
    }
}