using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="Configs/LevelConfigs",fileName ="LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    #region SingleTon
    private static LevelConfigs _isntance;
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
    public List<LevelConfig> _Level;
    public List<LevelConfig> GetConfig()
    {
        return _Level;
    }
} 
[System.Serializable]
public class LevelConfig
{
    public int PlayerQuantity;
    public int TotalCross;
    public List<PiecesConfig> Position;
}
[System.Serializable]
public enum namePieces{
    None =-1,
    Blue=0,
    Yellow=1,
    Green=2,
    Red=3
}
[System.Serializable]
public class PiecesConfig
{
    public Sprite sprite;
    public namePieces name;
    public int P_Start;
}
