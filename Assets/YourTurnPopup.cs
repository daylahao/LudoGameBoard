using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YourTurnPopup : BaseDialog
{
    public TextMeshProUGUI Turntext;

    private void Update()
    {
        Turntext.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).YourTurnText;
    }
}
