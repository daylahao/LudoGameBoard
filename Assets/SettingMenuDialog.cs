using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingMenuDialog : BaseDialog
{
    public TextMeshProUGUI _volumneSFXText;
    public TextMeshProUGUI _volumneBGMText;
    public TextMeshProUGUI Title,SFXLABEL,BGMLABEL,CLOSE;
    private void Update()
    {
        LoadVolumne();
    }
    public void LoadVolumne()
    {
        _volumneBGMText.text = (Mathf.Round(SoundManager.Instance._fxMusicBGBase._sourcePlaySound.volume*100)).ToString();
        _volumneSFXText.text =  (Mathf.Round(SoundManager.Instance._fxSoundBase._sourcePlaySound.volume*100)).ToString();
        Title.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).SettingText;
        SFXLABEL.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).SFXLabel;
        BGMLABEL.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).BGMLabel;
        CLOSE.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).CloseText;

    }
    public void UpVolumneFX()
    {
        SoundManager.Instance._fxSoundBase._sourcePlaySound.volume += 0.1f;
       SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
    }
    public void DownVolumneFX()
    {
        SoundManager.Instance._fxSoundBase._sourcePlaySound.volume -= 0.1f;
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
    }    
    public void UpVolumneBGM()
    {
        SoundManager.Instance._fxMusicBGBase._sourcePlaySound.volume += 0.1f;
       SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
    }
    public void DownVolumneBGM()
    {
        SoundManager.Instance._fxMusicBGBase._sourcePlaySound.volume -= 0.1f;
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
    }
    public void OnClickClose()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameManager.Instance.OnShowDialog<PauseMenuDialog>("Dialogs/PauseMenuDialog");
        }
        else
        {
            GameManager.Instance.OnShowDialog<MainMenuDialog>("Dialogs/MainMenuDialog");
        }
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        this.ClickCloseDialog();
    }
}
