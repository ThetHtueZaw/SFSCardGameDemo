using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinAungKhant.UIManagement;
using UnityEngine.UI;

public class UIExplodingLogin : MonoBehaviour
{
    [SerializeField] private LoginHandler _loginHandler;
    [SerializeField] private SignUpHandler _signUpHandler;
    [SerializeField] private Button _playWithFriendsBtn;

    private void Start()
    {
        _loginHandler.Connect();
        _loginHandler.ListenSfsEvents();

        _signUpHandler.Init();
        _signUpHandler.ListenSFSEvent();

        _playWithFriendsBtn.onClick.AddListener(OnClickPlayWithFreinds);
    }

    private void OnDestroy()
    {
        _loginHandler.RemoveSfsEvents();
    }

    private void OnClickPlayWithFreinds()
    {
        gameObject.SetActive(false);
        UIManager.Instance.ShowUI(GLOBALCONST.UI_ROOM_MENU);
    }
}
