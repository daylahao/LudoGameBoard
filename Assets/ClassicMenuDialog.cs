using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicMenuDialog : BaseDialog
{
    public int playerQuantityMap;
    public List<ItemMap> itemMaps;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.isEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnclickMap3()
    {
        GameManager.Instance.LoadLevel(3, itemMaps[0].PlayerQuantityMap);
    }
    public void OnclickMap4()
    {
        GameManager.Instance.LoadLevel(4, itemMaps[1].PlayerQuantityMap);
    }
    public void OnclickMap5()
    {
        GameManager.Instance.LoadLevel(5, itemMaps[2].PlayerQuantityMap);
    }
    public void BackMainHome()
    {
        GameManager.Instance.OnShowDialog<MainMenuDialog>("Dialogs/MainMenuDialog");
        ClickCloseDialog();
    }    
}
