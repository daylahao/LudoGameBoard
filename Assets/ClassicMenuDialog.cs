using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicMenuDialog : BaseDialog
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnclickMap3()
    {
        GameManager.Instance.LoadLevel(3);
    }
    public void OnclickMap4()
    {
        GameManager.Instance.LoadLevel(4);
    }
    public void OnclickMap5()
    {
        GameManager.Instance.LoadLevel(5);
    }
    public void BackMainHome()
    {
        GameManager.Instance.OnShowDialog<MainMenuDialog>("Dialogs/MainMenuDialog");
        ClickCloseDialog();
    }    
}
