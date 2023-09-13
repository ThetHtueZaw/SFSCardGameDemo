using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobby : UIBase
{
    [SerializeField] private LobbyManager _lobbyManager;

    protected override void OnShow(UIBaseData data = null)
    {
        base.OnShow(data);

        _lobbyManager.InitLobby();
        _lobbyManager.ListenSFSEvent();
    }

    protected override void OnClose()
    {
        base.OnClose();

        _lobbyManager.RemoveSFSEvent();
    }
}
