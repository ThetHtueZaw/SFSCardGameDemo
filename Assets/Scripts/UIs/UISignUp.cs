using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISignUp : UIBase
{
    [SerializeField] private SignUpHandler _signUpHandler;

    protected override void OnInit()
    {
        base.OnInit();

        _signUpHandler.Init();
    }

    protected override void OnShow(UIBaseData data = null)
    {
        base.OnShow(data);

        _signUpHandler.ListenSFSEvent();
    }

    protected override void OnClose()
    {
        base.OnClose();

        _signUpHandler.RemoveSFSEvent();
    }
}
