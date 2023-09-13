using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinAungKhant.UIManagement;

public class UIRoomMenu : UIBase
{
    [SerializeField] private RoomListHandler _roonListHandler;
    [SerializeField] private RoomCreator _roomCreator;

    protected override void OnInit()
    {
        base.OnInit();

        _roonListHandler.ListenSfsEvents();
        _roomCreator.ListenCreateRoomClick();
    }

    protected override void OnClose()
    {
        base.OnClose();

        _roonListHandler.RemoveSfsEvents();
    }
}
