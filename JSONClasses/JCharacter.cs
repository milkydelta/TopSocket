
namespace TopSocket.JSON;

internal class JCharacter
{
    public string name;
    public bool isLocal;
    public bool isDead;
    public bool isZombie;
    public bool isSkeleton;

    public JCharacter(Character chr)
    {
        name = chr.characterName;
        isLocal = chr.IsLocal;
        isDead = chr.data.dead;
        isZombie = chr.data.zombified;
        isSkeleton = chr.data.isSkeleton;
        
    }
}