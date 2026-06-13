using UnityEngine;
using TopSocket;
using UnityEngine.SceneManagement;

namespace TopSocket.JSON;

internal class JGame
{
    public string pluginVersion = MyPluginInfo.PLUGIN_VERSION;
    public string gameVersion = Application.version;
    public string scene = SceneManager.GetActiveScene().name;
    public bool offlineMode = Photon.Pun.PhotonNetwork.OfflineMode;
}