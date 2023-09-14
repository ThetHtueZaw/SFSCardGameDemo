using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinAungKhant.UIManagement;

public class UIRoomMenu : UIBase
{
    [SerializeField] private RoomListHandler _roomListHandler;
    [SerializeField] private RoomCreator _roomCreator;

    protected override void OnInit()
    {
        base.OnInit();

        _roomListHandler.ListenSfsEvents();
        _roomListHandler.RequestRoomList();
        _roomCreator.ListenCreateRoomClick();
    }

    protected override void OnClose()
    {
        base.OnClose();

        _roomListHandler.RemoveSfsEvents();
    }
}
