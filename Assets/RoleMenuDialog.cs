using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleMenuDialog : BaseDialog
{
    public TextMeshProUGUI Content;
    public TextMeshProUGUI TitleHeader;
    public TextMeshProUGUI CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        TitleHeader.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).RoleTitle;
        Content.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).RoleText;
        CloseButton.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).CloseText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
