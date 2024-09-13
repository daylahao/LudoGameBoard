using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMap : MonoBehaviour
{
    public int mapindex;
    public int PlayerQuantityMap;
    public TextMeshProUGUI textPlayerQuantity, textThumb, textPlayerlabel, Maplabel;
    public Button BtnDown;
    public Button BtnUp;
    public Animator _animator;
    public void UpdateTitle()
    {
        _animator.Play("ScaleUp");
        textThumb.text = PlayerQuantityMap+" " + LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).PlayerText +" \n " + (mapindex - PlayerQuantityMap) + " " +LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).BotText ;
    }
    // Start is called before the first frame update
    void Start()
    {
        textPlayerlabel.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).Playerlabel;
        Maplabel.text = LanguageConfigs.Instance.GetConfig(GameManager.Instance.Language).Maplabel+" "+mapindex;
        PlayerQuantityMap = 1;
        BtnDown.onClick.AddListener(DownPlayer);
        BtnUp.onClick.AddListener(UpPlayer);
        _animator = this.transform.GetChild(0).gameObject.transform.GetComponent<Animator>();
        UpdateTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpPlayer()
    {
        if (PlayerQuantityMap < mapindex)
        {
            PlayerQuantityMap++;
            textPlayerQuantity.text = PlayerQuantityMap.ToString();
            UpdateTitle();
        }
    }
    public void DownPlayer()
    {
        if (PlayerQuantityMap > 1)
        {
            PlayerQuantityMap--;
            textPlayerQuantity.text = PlayerQuantityMap.ToString();
            UpdateTitle();
        }
    }
}
