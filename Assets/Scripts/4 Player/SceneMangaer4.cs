using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMangaer4 : MonoSingleton<SceneMangaer4>
{
    public int playerQuantity = 4;
    public namePieces turnCurrent;
    public GameObject GroupPositionCross;
    public List<GameObject> CrossObjects;
    public int TotalCross;
    public LevelConfig levelConfig;
    public Dice4 dice;
    public GameObject Grouppieces;
    public List<PiecesBase> pieces;
    public List<House> houses;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void Runlevel()
    {
        playerQuantity = 4;
        levelConfig = Manager.Instance.GetConfig(playerQuantity);
        TotalCross = 55;
        for (int i = 0; i < GroupPositionCross.transform.childCount; i++)
        {
            //GameObject cross = Instantiate(GroupPositionCross, new Vector3(0, 0, 0), Quaternion.identity);
            CrossObjects.Add(GroupPositionCross.transform.GetChild(i).gameObject);
        }
        Manager.Instance.CrossObjects = CrossObjects;
        for (int i = 0; i < Grouppieces.transform.childCount; i++)
        {
            //GameObject cross = Instantiate(GroupPositionCross, new Vector3(0, 0, 0), Quaternion.identity);
            pieces.Add(Grouppieces.transform.GetChild(i).gameObject.GetComponent<PiecesBase>());
        }
    }
    // Update is called once per frame
    void Update()
    {

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
    public void NextTurn()
    {
        if (dice.diceValue == 6||dice.diceValue == 1)
            Debug.Log("Lac tiep");
        else
        turnCurrent = (namePieces)(((int)turnCurrent + 1) % playerQuantity);
        dice.ResetDice();
        MangerUIScene4.Instance.ChangeThumb();
    }
}
