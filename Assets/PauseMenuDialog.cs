using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDialog : BaseDialog
{
   public void OnclickResume()
    {
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.ResumeGame();
        OnHide();
    }
    public void OnClickMainMenu()
    {
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.LoadMainMenu();
        OnHide();
    }
    public void OnClickRestartGame()
    {

       SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.RestartGame();
        OnHide();
    }
    public void OnClickSetting()
    {

       SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.OnShowDialog<SettingMenuDialog>("Dialogs/SettingMenuDialog");
        OnHide();
    }
}
