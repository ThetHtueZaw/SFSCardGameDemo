using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinAungKhant.UIManagement;

public class UILogin : UIBase
{
    [SerializeField] private LoginHandler _loginHandler;

    protected override void OnInit()
    {
        base.OnInit();

        _loginHandler.Connect();
    }

    protected override void OnShow(UIBaseData data = null)
    {
        base.OnShow(data);

        _loginHandler.ListenSfsEvents();
    }

    protected override void OnClose()
    {
        base.OnClose();

        _loginHandler.RemoveSfsEvents();
    }
}
