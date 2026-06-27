using HarmonyLib;
using Newtonsoft.Json;
using TopSocket.JSON;


namespace TopSocket.Patches;

[HarmonyPatch(typeof(CharacterData), "RPC_SyncSkeleton")]
internal class SyncSkeleton
{
    static void Postfix(Character ___character)
    {
        Plugin.instance.Broadcast(JsonConvert.SerializeObject(new JEvent<JCharacter>("setSkeleton", new JCharacter(___character))));
    }
}