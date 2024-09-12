using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GamePlayManager : MonoSingleton<GamePlayManager>
{
    public int playerQuantity = 4;
    public namePieces turnCurrent;
    public int turnTemp;
    public int TotalCross;
    public LevelConfig levelConfig;
    public Dice4 dice;
    public GameObject Grouppieces;
    public List<PiecesBase> pieces;
    public MapLevel mapLevel;
    private GameObject Map;
    public GameObject P_SpawnMap;
    public Transform P_Spawndialog;
    public List<int> Turnplayer;
    public List<int> BOT;
    // Start is called before the first frame update
    public void OnclickPause()
    {
        GameManager.Instance.PauseGame();
    }
    void Start()
    {
        GameManager.Instance._popUpContainer = P_Spawndialog;
        playerQuantity = GameManager.Instance.PlayQuantity;
        //playerQuantity = 4;
        levelConfig = GameManager.Instance.GetConfig(playerQuantity);
        TotalCross = levelConfig.TotalCross;
        Map  = Instantiate(levelConfig.Map,P_SpawnMap.transform);
        mapLevel = Map.GetComponent<MapLevel>();
        SpawnPieces();
        //for (int i = 0; i < GroupPositionCross.transform.childCount; i++)
        //{
        //    //GameObject cross = Instantiate(GroupPositionCross, new Vector3(0, 0, 0), Quaternion.identity);
        //    CrossObjects.Add(GroupPositionCross.transform.GetChild(i).gameObject);
        //}
        //GameManager.Instance.CrossObjects = CrossObjects;
        //for (int i = 0; i < Grouppieces.transform.childCount; i++)
        //{
        //    //GameObject cross = Instantiate(GroupPositionCross, new Vector3(0, 0, 0), Quaternion.identity);
        //    pieces.Add(Grouppieces.transform.GetChild(i).gameObject.GetComponent<PiecesBase>());
        //}
        turnTemp = 0;
        turnCurrent = (namePieces)levelConfig.Position[turnTemp].name;
        MangerUIScene4.Instance.ChangeThumb();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!SoundManager.Instance._fxMusicBGBase._sourcePlaySound.isPlaying)
        {
            SoundManager.Instance.PlayLoopBGMusic(SoundName.Music.ToString());
        }
    }
    [Header("Khoảng cách giữa các quân cờ")]
    public float radiusSpawnPieces;
    void SpawnPieces()
    {
        for(int i = 0;i < levelConfig.PlayerQuantity; i++)
        {
            for (int j = 1; j <= levelConfig.ChessPieceCount; j++)
            {
                GameObject pointPrefab = levelConfig.Position[i].Prefab;
                Vector2 centerPoint = mapLevel.FindPointName(levelConfig.Position[i].name).position;
                float angle = j  * (360f / levelConfig.ChessPieceCount); // Chia đều góc 360 độ
                Vector2 offset = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radiusSpawnPieces;
                Vector2 spawnPosition = centerPoint + offset;
                GameObject piecesTemp = Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
                pieces.Add(piecesTemp.GetComponent<PiecesBase>());
            }
        }
    }
    public void CheckPieces()
    {
        bool isnext = true;
            foreach (PiecesBase piece in pieces)
            {
                if (piece.Name == turnCurrent)
                {
                    if (piece.CheckCanMove())
                    {
                        isnext = false;
                        break;
                    }
                }
            }
            if (isnext)
            {
            NextTurn();
            }
    }
    public bool CheckWin()
    {
        foreach (HouseCross House in mapLevel.houses)
        {
            if (House.CheckWin())
            {
                return true;
            }
        }
        return false;
    }
    public void HandleWinGame()
    {
        SoundManager.Instance.PlayBGMusic(SoundName.WinMusic.ToString());
        GameManager.Instance.OnShowDialog<WinGameDialog>("Dialogs/WinGameDialog");
        Debug.Log("Người chơi " + turnCurrent + " thắng");
    }
    public void NextTurn()
    {
        if (CheckWin())
        {
            HandleWinGame();
            return;
        }
        else
        {
            if (dice.diceValue == 6 || dice.diceValue == 1)
            {
                //Debug.Log("Lac tiep");
                //MangerUIScene4.Instance.infoText.text = "Được lắc thêm\nlượt xúc xắc";
            }
            else
            {
                turnTemp = (turnTemp + 1) % playerQuantity;
                //turnCurrent = (namePieces)(((int)turnCurrent + 1) % playerQuantity);
                turnCurrent = (namePieces)levelConfig.Position[turnTemp].name;
            }
            dice.ResetDice();
            MangerUIScene4.Instance.ChangeThumb();
        }
    }
}
