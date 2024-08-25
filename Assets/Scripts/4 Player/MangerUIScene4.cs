using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerUIScene4 : MonoSingleton<MangerUIScene4>
{
    public SpriteRenderer Thumb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeThumb()
    {
        Thumb.sprite = SceneMangaer4.Instance.levelConfig.Position[(int)SceneMangaer4.Instance.turnCurrent].sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
