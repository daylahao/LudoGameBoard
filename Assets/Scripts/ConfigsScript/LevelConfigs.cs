using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="configs/LevelConfigs",fileName ="LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    #region SingleTon
    [SerializeField]

    private static LevelConfigs _isntance;
    [SerializeField]

    public static LevelConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<LevelConfigs>("Configs/LevelConfigs");
                
            }
            return _isntance;
        }
    }
    #endregion
    [SerializeField]
    public List<LevelConfig> _Level;
    [SerializeField]

    public List<LevelConfig> GetConfig()
    {
        return _Level;
    }
} 
[System.Serializable]
public class LevelConfig
{
    public int PlayerQuantity;
    public int ChessPieceCount;
    public GameObject Map;
    public int TotalCross;
    public List<PiecesConfig> Position;
}
[System.Serializable]
public enum namePieces{
    None =-1,
    Blue=0,
    Yellow=1,
    Green=2,
    Red=3,
    Purple=4
}
[System.Serializable]
public class PiecesConfig
{
    public Sprite sprite;
    [Header("Prefab của Quân cờ")]
    public GameObject Prefab;
    public namePieces name;
    public int P_Start;
}
