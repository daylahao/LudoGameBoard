using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHome : MonoSingleton<SceneHome>
{
    public Transform PositionDialog;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance._popUpContainer = PositionDialog;
        GameManager.Instance.OnShowDialog<MainMenuDialog>("Dialogs/MainMenuDialog");
        if (!SoundManager.Instance._fxMusicBGBase._sourcePlaySound.isPlaying|| SoundManager.Instance._fxMusicBGBase.name != SoundConfigs.Instance.GetAudioByName(SoundName.Music.ToString()).name)
        {
            SoundManager.Instance.PlayLoopBGMusic(SoundName.Music.ToString());
        }
        //SoundManager.Instance.PlayLoopBGMusic(SoundName.Music.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
