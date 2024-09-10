using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHome : MonoSingleton<SceneHome>
{
    public Transform PositionDialog;
    // Start is called before the first frame update
    void Start()
    {

    }
  
    public void RunScene()
    {
        GameManager.Instance._popUpContainer = PositionDialog;
        GameManager.Instance.OnShowDialog<MainMenuDialog>("Dialogs/MainMenuDialog");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
