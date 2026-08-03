
namespace TopSocket.JSON;

internal class JItem
{
    public string name;
    public int cookState = 0;
    public int totalUses = -1;
    public int uses;

    public float percentage = -1;
    

    public JItem(Item it, ItemInstanceData inst)
    {
        if (it != null){
            name = it.UIData.itemName;
            totalUses = it.totalUses;
        }

        IntItemData cookData;
        if (inst.TryGetDataEntry<IntItemData>(DataEntryKey.CookedAmount, out cookData))
        {
            cookState = cookData.Value;
        }
        
        uses = totalUses;
        OptionableIntItemData usesData;
        if (inst.TryGetDataEntry<OptionableIntItemData>(DataEntryKey.ItemUses, out usesData))
        {
            if (usesData.HasData){uses = usesData.Value;}
        }

        FloatItemData perData;
        if (inst.TryGetDataEntry<FloatItemData>(DataEntryKey.UseRemainingPercentage, out perData))
        {
            percentage = perData.Value;
        }
    }
}