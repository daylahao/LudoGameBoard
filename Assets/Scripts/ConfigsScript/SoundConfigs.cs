using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "configs/SoundConfigs", fileName = "SoundConfigs")]
public class SoundConfigs : ScriptableObject
{
    [SerializeField]
    public List<SoundConfig> _Sound;
    private static SoundConfigs _isntance;

    public static SoundConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<SoundConfigs>("Configs/SoundConfigs");

            }
            return _isntance;
        }
    }
    [SerializeField]
    public List<SoundConfig> Getconfig()
    {
        return _Sound;
    
    }
    [SerializeField]
    public AudioClip GetAudioByName(SoundName name)
    {
        foreach (var item in _Sound)
        {
            if (item._SoundName == name)
            {
                return item.Name;
            }
        }
        return null;
    }[SerializeField]
    public AudioClip GetAudioByName(string name)
    {
        foreach (var item in _Sound)
        {
            if (item._SoundName.ToString() == name)
            {
                return item.Name;
            }
        }
        return null;
    }

}
[System.Serializable]
public class SoundConfig
{
    public SoundName _SoundName;
    [Header("Tên của Sound nếu để trong Rsources/Sounds/")]
    public AudioClip Name;
}
[System.Serializable]
public enum SoundName
{
    None = -1,
    ButtonFX = 0,
    Music = 1,
    PicesMove = 2,
    PicesHappy = 3,
    PicesDie = 4,
    DiceRoll = 5,
    WinMusic = 6,
    LoseMusic = 7,
    YourTurn = 8,
}
