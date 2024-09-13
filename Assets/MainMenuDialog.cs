using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDialog : BaseDialog
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickClassic()
    {
       GameManager.Instance.OnShowDialog<ClassicMenuDialog>("Dialogs/ClassicLevelDialog");
        this.ClickCloseDialog();
    }
    public void OnClickSetting()
    {
        GameManager.Instance.OnShowDialog<SettingMenuDialog>("Dialogs/SettingMenuDialog");
        this.ClickCloseDialog();
    }
    public void OnClickEvent()
    {

       GameManager.Instance.OnShowDialog<BaseDialog>("Dialogs/ComingDialog");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
