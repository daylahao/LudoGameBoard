using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuDialog : BaseDialog
{
    public TextMeshProUGUI Pausetitle, ContinueText, ResetText, SettingText, Pauseclose;

    private void Update()
    {
        LoadPauseMenu();
    }
    public void LoadPauseMenu()
    {
        Pausetitle.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).PauseText;
        ContinueText.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).ResumeText;
        ResetText.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).RestartText;
        SettingText.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).IngameSettingText;
        Pauseclose.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).ExitText;
    }

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
