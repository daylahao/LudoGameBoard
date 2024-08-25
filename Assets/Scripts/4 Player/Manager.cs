using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoSingleton<Manager>
{
    public List<GameObject> CrossObjects;
    public List<LevelConfig> levelConfigs;
    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelConfigs = LevelConfigs.Instance.GetConfig();
        if(levelConfigs == null)
        {
            Debug.LogError("LevelConfigs is null");
        }
        else
        {
            SceneMangaer4.Instance.Runlevel();
        }
    }
    public LevelConfig GetConfig(int level)
    {
        foreach (LevelConfig item in levelConfigs)
        {
            if (item.PlayerQuantity == level)
            {
                return item;
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}