using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : MonoBehaviour
{
    public List<HouseCross> houses;
    public GameObject GroupCross;
    public List<CrossBase> Crosses;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var house in houses)
        {
            house.Initialize();
        }
        foreach (Transform child in GroupCross.transform)
        {
            Crosses.Add(child.gameObject.GetComponent<CrossBase>());
        }
        GamePlayManager.Instance.mapLevel = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class HouseCross
{
    public namePieces Name;
    public GameObject GroupCross;
    public List<CrossBase> Crosses;
    public  void Initialize()
    {
        for (int i = 0; i < GroupCross.transform.childCount; i++)
        {
            //GameObject cross = Instantiate(GroupPositionCross, new Vector3(0, 0, 0), Quaternion.identity);
            Crosses.Add(GroupCross.transform.GetChild(i).gameObject.GetComponent<CrossBase>());
        }
    }
    public bool CheckWin()
    {
        int count  = 0;
        for (int i = 0; i < Crosses.Count; i++)
        {
            if(Crosses[i].GetName()!=namePieces.None)
            {
                count++;
            }
        }
        if(count == GamePlayManager.Instance.levelConfig.PlayerQuantity)
        {
            return true;
        }else
        return false;
    }
}
