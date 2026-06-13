using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangerUIScene4 : MonoSingleton<MangerUIScene4>
{
    public SpriteRenderer Thumb;
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeThumb()
    {
        Thumb.sprite = GamePlayManager.Instance.levelConfig.Position[GamePlayManager.Instance.turnTemp].sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
