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
        Awake,ServerConnecting,LobbyEntering,NameEntry,RoomSelect,RoomCreating,RoomEntering,RoomEnterd
    }
    private ConnectStep connectStep=ConnectStep.Awake;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConnetSequence());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ConnetSequence()
    {
        yield return new WaitForEndOfFrame();
        
        // デフォルトロビーへの自動入室を許可する
        MonobitNetwork.autoJoinLobby = true;

        // MUNサーバに接続する
        MonobitNetwork.ConnectServer(serverName);
        connectStep = ConnectStep.ServerConnecting;

        dialogManager.DialogButton(serverName + "へ接続します");
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (MonobitNetwork.isConnect)
            {
                connectStep = ConnectStep.LobbyEntering;
                break;
            }
        }
        
        dialogManager.SetMessage(serverName + "へ接続完了。\nデフォルトロビーに入ります");       
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (MonobitNetwork.inLobby)
            {
                connectStep = ConnectStep.NameEntry;
                break;
            }
        }
        bool onEntered = false;
        string playerName = "";
        dialogManager.InputDialog(
            "デフォルトロビーに入りました。\nプレイヤー名を入力してください",
            "Enter",
            ()=> {
                onEntered = true;
                playerName = dialogManager.GetInputValue();
                }
            );
        while (!onEntered)
        {
            yield return new WaitForSeconds(0.125f);
        }
        dialogManager.DialogButton(playerName + "さん、いらっしゃいませ");
        MonobitNetwork.playerName = playerName;
        
        yield return null;

    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
