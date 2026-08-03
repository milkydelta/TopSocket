
namespace TopSocket.JSON;

internal class JBackpack : JItem
{
    public JItem i0;
    public JItem i1;
    public JItem i2;
    public JItem i3;

    public JBackpack(ItemInstanceData inst) : base(null, inst)
    {
        name = "Backpack";

        //System.Console.WriteLine("Constructor");
        BackpackData backData;
        if (inst.TryGetDataEntry<BackpackData>(DataEntryKey.BackpackData, out backData))
        {
            //System.Console.WriteLine("Get Data");
            var s0 = backData.itemSlots[0];
            var s1 = backData.itemSlots[1];
            var s2 = backData.itemSlots[2];
            var s3 = backData.itemSlots[3];
            //System.Console.WriteLine("Pulled Slots");

            if (!s0.IsEmpty()) {i0 = new JItem(s0.prefab, s0.data);}
            //System.Console.WriteLine("1");
            if (!s1.IsEmpty()) {i1 = new JItem(s1.prefab, s1.data);}
            //System.Console.WriteLine("2");
            if (!s2.IsEmpty()) {i2 = new JItem(s2.prefab, s2.data);}
            //System.Console.WriteLine("3");
            if (!s3.IsEmpty()) {i3 = new JItem(s3.prefab, s3.data);}
            //System.Console.WriteLine("4");
        }
    }
}