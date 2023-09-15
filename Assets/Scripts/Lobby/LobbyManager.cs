using System;
using System.Collections;
using System.Collections.Generic;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using TinAungKhant.UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject _lobbyPanelPrefab;
    [SerializeField] private Transform _root;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Countdown _countdown;

    public void ListenSFSEvent()
    {
        _startBtn.onClick.AddListener(StartGame);

        GlobalSFSManager.Instance.GetSfsClient().AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnGameStart);
        GlobalSFSManager.Instance.GetSfsClient().AddEventListener(SFSEvent.USER_ENTER_ROOM, OnUserEnterRoom);
    }

    public void RemoveSFSEvent()
    {
        GlobalSFSManager.Instance.GetSfsClient().RemoveEventListener(SFSEvent.EXTENSION_RESPONSE, OnGameStart);
        GlobalSFSManager.Instance.GetSfsClient().RemoveEventListener(SFSEvent.USER_ENTER_ROOM, OnUserEnterRoom);
    }

    public void InitLobby()
    {
        Room room = GlobalSFSManager.Instance.GetSfsClient().LastJoinedRoom;

        foreach (User user in room.UserList)
        {
            GameObject lobbyPanel = Instantiate(_lobbyPanelPrefab, _root);
            LobbyPlayerPanel lobbyPlayerPanel = lobbyPanel.GetComponent<LobbyPlayerPanel>();
            lobbyPlayerPanel.SetName(user.Name);
        }
    }

    public void StartGame()
    {
        _countdown.StartCount();

        StartCoroutine(StartGameDelay());
    }

    IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(10);

        ExtensionRequest extensionRequest = new ExtensionRequest(ExtensionEventNames.START_GAME, new SFSObject());
        GlobalSFSManager.Instance.GetSfsClient().Send(extensionRequest);
    }

    public void OnGameStart(BaseEvent evt)
    {
        string cmdName = (string)evt.Params["cmd"];

        if (cmdName == ExtensionEventNames.GAME_STARTED)
        {
            Debug.Log("Game is Started");

            UIManager.Instance.ShowUI(GLOBALCONST.UI_GAME_ROOM);
            UIManager.Instance.CloseUI(GLOBALCONST.UI_LOBBY);
        }
    }

    void OnUserEnterRoom(BaseEvent evt)
    {
        Room room = (Room)evt.Params["room"];
        User user = (User)evt.Params["user"];

        Debug.Log("User: " + user.Name + " has just joined Room: " + room.Name);

        GameObject lobbyPanel = Instantiate(_lobbyPanelPrefab, _root);
        LobbyPlayerPanel lobbyPlayerPanel = lobbyPanel.GetComponent<LobbyPlayerPanel>();
        lobbyPlayerPanel.SetName(user.Name);
    }
}
