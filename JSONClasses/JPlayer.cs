
namespace TopSocket.JSON;

internal class JPlayer
{
    public JCharacter character;
    public JItem i0;
    public JItem i1;
    public JItem i2;
    public JItem iT;
    public JBackpack backpack;

    public int selectedSlot = -1;

    public JPlayer(Player player)
    {
        character = new JCharacter(player.character);

        var s0 = player.GetItemSlot(0);
        var s1 = player.GetItemSlot(1);
        var s2 = player.GetItemSlot(2);
        var sT = player.GetItemSlot(250);

        if (!s0.IsEmpty()) {i0 = new JItem(s0.prefab, s0.data);}
        if (!s1.IsEmpty()) {i1 = new JItem(s1.prefab, s1.data);}
        if (!s2.IsEmpty()) {i2 = new JItem(s2.prefab, s2.data);}
        if (!sT.IsEmpty()) {iT = new JItem(sT.prefab, sT.data);}

        var sB = player.GetItemSlot(3);

        if (!sB.IsEmpty()) {backpack = new JBackpack(sB.prefab, sB.data);}

        if (player.character.refs.items.currentSelectedSlot.IsSome)
        {
            selectedSlot = player.character.refs.items.currentSelectedSlot.Value;
        }
    }
}