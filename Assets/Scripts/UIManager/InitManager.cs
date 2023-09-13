using System.Collections;
using System.Collections.Generic;
using TinAungKhant.UIManagement;
using UnityEngine;

public class InitManager : Singleton<InitManager>
{
    //private static string _url = "http://google.com";
    void Start()
    {

        UIManager.Instance.ShowUI(GLOBALCONST.UI_LOGIN);
    }
}
