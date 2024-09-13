using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public bool isGamePause;
    public bool isEvent;
    public List<LevelConfig> levelConfigs;
    public int PlayQuantity;
    public int PlayerReal;
    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }
    public Transform _popUpContainer;

    public T OnShowDialog<T>(string path, object data = null, UnityEngine.Events.UnityAction callbackCompleteShow = null) where T : BaseDialog
    {
        GameObject prefab = this.GetResourceFile<GameObject>(path);
        if (prefab != null)
        {
            T objectSpawned = (Instantiate(prefab, _popUpContainer)).GetComponent<T>();
            if (objectSpawned != null)
            {
                objectSpawned.OnShow(data, callbackCompleteShow);
            }
            return objectSpawned as T;
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        levelConfigs = LevelConfigs.Instance.GetConfig();
        if(levelConfigs == null)
        {
            Debug.LogError("LevelConfigs is null");
            Application.Quit();
        }
        else{
            
            isGamePause  = false;
            SoundManager.Instance.OnInit(true, true);
            SceneManager.LoadScene(1);
        }
        //else
        //{
        //    GamePlayManager.Instance.Runlevel();
        //}
    }
    public LevelConfig GetConfig(int level)
    {
        if(level ==0)
        {
            return levelConfigs[3];
        }
        foreach (LevelConfig item in levelConfigs)
        {
            if (item.PlayerQuantity == level)
            {
                return item;
            }
        }
        return null;
    }
    public void LoadLevel(int level,int player)
    {
        PlayerReal = player;
        PlayQuantity = level; 
        SceneManager.LoadScene(2);
    }
    public void PauseGame()
    {
        BaseDialog dialog = OnShowDialog<PauseMenuDialog>("Dialogs/PauseMenuDialog");
        isGamePause = true;
        Time.timeScale = 0;     
    }
    public void ResumeGame()
    {
        isGamePause = false;
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
    }
}