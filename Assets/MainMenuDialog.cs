using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuDialog : BaseDialog
{
    public TextMeshProUGUI classicText;
    public TextMeshProUGUI eventText;
    public TextMeshProUGUI Textlanguage;
    // Start is called before the first frame update
    void Start()
    {
        classicText.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).ClassicText;
        eventText.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).EventText;
        Textlanguage.text = GameManager.Instance.Language.ToString().Substring(0,2);
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
        GameManager.Instance.OnShowDialog<EventMenuDialog>("Dialogs/EventLevelDialog");
        this.ClickCloseDialog();
    }
    public void OnClickRole()
    {

       GameManager.Instance.OnShowDialog<RoleMenuDialog>("Dialogs/RoleMenuDialog");
        //this.ClickCloseDialog();
    }
    public void ToggleLanguage()
    {
        LanguageType language = (LanguageType)(((int)GameManager.Instance.Language+1)% Enum.GetValues(typeof(LanguageType)).Length);
        GameManager.Instance.Language = language;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
