using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

public class MapLevel : MonoBehaviour
{
    public List<HouseCross> houses;
    public GameObject GroupCross;
    public List<CrossBase> Crosses;
    [Header("Điểm để sinh ra các quân cờ (Bắt buộc)")]
    public List<PointSpawnPieces> PointGroupPieces;
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
    public Transform FindPointName(namePieces name)
    {
        foreach (var item in PointGroupPieces)
        {
            if (item.Name == name)
            {
                return item.Point.transform;
            }
        }
        return null;
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
        for (int i = Crosses.Count; i > Crosses.Count-GamePlayManager.Instance.levelConfig.ChessPieceCount; i--)
        {

            if(Crosses[i-1].GetName()!=namePieces.None)
            {
                count++;
                if(count == GamePlayManager.Instance.levelConfig.ChessPieceCount)
                    break;
            }
        }
        if(count == GamePlayManager.Instance.levelConfig.ChessPieceCount)
        {
            return true;
        }else
        return false;
    }
    
}

[System.Serializable]
public class PointSpawnPieces
{
    public namePieces Name;
    public GameObject Point;

}