using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;

public class NetworkController : MonobitEngine.MonoBehaviour
{
    [SerializeField]
    string serverName = "ServerName";
    [SerializeField]
    DialogManager dialogManager;

    public enum ConnectStep
    {
        Awake,ServerConnecting,LobbyEntering,RoomSelect,RoomCreating,RoomEntering,RoomEnterd
    }
    private ConnectStep connectStep=ConnectStep.Awake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ConnetSequence()
    {
        // デフォルトロビーへの自動入室を許可する
        MonobitNetwork.autoJoinLobby = true;

        // MUNサーバに接続する
        MonobitNetwork.ConnectServer(serverName);
        connectStep = ConnectStep.ServerConnecting;

        dialogManager.MessagaButton(serverName + "へ接続します");
        while(true)
        {
            if (MonobitNetwork.isConnect)
            {
                connectStep = ConnectStep.LobbyEntering;
                break;
            }
            yield return new WaitForSeconds( 1.0f);
        }
        dialogManager.SendMessage(serverName + "へ接続完了。デフォルトロビーに入ります");
        while (true)
        {
            if (MonobitNetwork.)
            {
                connectStep = ConnectStep.LobbyEntering;
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }


        yield return null;

    }
}
