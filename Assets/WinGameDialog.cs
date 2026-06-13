using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinGameDialog : BaseDialog
{
    public Transform P_Player;
    public TextMeshProUGUI txtScore;
    private void Start()
    {
        txtScore.text = GamePlayManager.Instance.turnCurrent.ToString()+" Chiến thắng";
        GameObject Playerwwin = Instantiate(GamePlayManager.Instance.levelConfig.Position[GamePlayManager.Instance.turnTemp].Prefab,new Vector3(16.59591f, -0.2076085f, 0),Quaternion.identity);
        //Playerwwin.transform.GetChild(0).transform.localScale = new Vector3(1f, 1f, 1f);
        Playerwwin.transform.GetChild(0).GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        Playerwwin.transform.GetChild(0).GetComponent<Animator>().Play("Dance");
    }
    public void OnClickMainMenu()
    {
        SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.LoadMainMenu();
        OnHide();
    }
    public void PlayAgain()
    {

       SoundManager.Instance.PlayFx(SoundName.ButtonFX.ToString());
        GameManager.Instance.RestartGame();
        OnHide();
    }
}
