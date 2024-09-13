using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "configs/LanguageConfigs", fileName = "LanguageConfigs")]

public class LanguageConfigs : ScriptableObject 
{
    #region SingleTon
    [SerializeField]

    private static LanguageConfigs _isntance;
    [SerializeField]

    public static LanguageConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<LanguageConfigs>("Configs/LanguageConfigs");

            }
            return _isntance;
        }
    }
    #endregion
    [SerializeField]
    List<LanguageConfig> languageConfigs = new List<LanguageConfig>();
    public LanguageConfig GetConfig(LanguageType languageType)
    {
        foreach (var item in languageConfigs)
        {
            if (item.LanguageType == languageType)
            {
                return item;
            }
        }
        return null;

    }
}
[System.Serializable]
public class LanguageConfig
{
    [SerializeField]
    public LanguageType LanguageType;
    [Header("Đua ngựa")]
    public string Title;
    [Header("Chơi cổ điển")]
    public string ClassicText;
    [Header("Cài đặt")]
    public string SettingText;
    [Header("Sự kiện")]
    public string EventText;
    [Header("Nội dung mô tả sự kiện")]
    [TextArea]
    public string EventDescription;
    [Header("Luật chơi")]
    public string RoleTitle;
    [Header("Content của bảng luật chơi")]
    [TextArea]
    public string RoleText;
    [Header("Lượt của bạn")]
    public string YourTurnText; 
    [Header("Đã chiến thắng")]
    public string WinText;
    [Header("Đã thua")]
    public string LoseText;
    [Header("Tiêu đề Kết thúc")]
    public string WinTitle;
    [Header("lắc xúc xắc")]
    public string RollText;
    [Header("Tạm Dừng")]
    public string PauseText;
    [Header("Chơi lại")]
    public string RestartText;
    [Header("Thoát")]
    public string ExitText;
    [Header("Tiếp tục chơi")]
    public string ResumeText;
    [Header("Đóng")]
    public string CloseText;
    [Header("Quay lại")]
    public string BackText;
    [Header("SFXLABEL")]
    public string SFXLabel;
    [Header("BGMLABEL")]
    public string BGMLabel;
    [Header("Người chơi")]
    public string Playerlabel;
    [Header("người")]
    public string PlayerText;
    [Header("Máy")]
    public string BotText;
    [Header("Chọn ngôn ngữ")]
    public string ChooseLanguageText;
    [Header("bản đồ")]
    public string Maplabel;
}
public enum LanguageType
{

    Vietnamese=0,
    English=1
}
