using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PiecesBase : MonoBehaviour
{
    public Vector2 DefaultPosition;
    public namePieces Name;
    public int Step;
    public int CurrentPosition;
    public bool IsOut=true;
    public bool IsMoving = false;
    public int stepdice;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = this.transform.position;
        IsMoving = false;
        IsOut = true;
    }
    void OnMouseDown()
    {
        Debug.Log(this.gameObject.name);
        if(GamePlayManager.Instance.turnCurrent == Name)
        {
            stepdice = GamePlayManager.Instance.dice.GetDiceValue();
            if (stepdice != 0 && (Step+stepdice)<=GamePlayManager.Instance.levelConfig.TotalCross)
            {
                Move(stepdice);
            }
            //else if(Step== GamePlayManager.Instance.levelConfig.TotalCross)
            //{
            //    this.transform.position = GamePlayManager.Instance.houses[0].transform.GetChild(stepdice-1).transform.position;  
            //}
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            if (stepdice >0 && (Step+stepdice)<=GamePlayManager.Instance.TotalCross)
            {
                if (this.transform.position == GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position)
                {
                    Step++;
                    stepdice--;
                    CurrentPosition++;
                    if (CurrentPosition > GamePlayManager.Instance.TotalCross)
                    {
                        CurrentPosition = 0;
                    }
                }
            }
            //if(stepdice>0&&(Step+stepdice)==GamePlayManager.Instance.TotalCross)
            //{
            //    if (this.transform.position == GamePlayManager.Instance.houses[(int)Name][Step-GamePlayManager.Instance.TotalCross].transform.position)
            //    {
            //        Step++;
            //        stepdice--;
            //        CurrentPosition++;
            //        if (CurrentPosition > GamePlayManager.Instance.TotalCross)
            //        {
            //            CurrentPosition = 0;
            //        }
            //    }
            //}
            else if(this.transform.position == GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position)
            {
                //this.transform.position = GamePlayManager.Instance.Crosses[CurrentPosition].transform.position;
                GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].GetComponent<CrossBase>().SetPieces(this);
                IsMoving = false;
                EndMoving();
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position, 0.1f);
        }
    }
    public void Move(int step_)
    {
        if (IsOut && (step_ == 1 || step_ == 6))
        {
            if (GamePlayManager.Instance.mapLevel.Crosses[GamePlayManager.Instance.levelConfig.Position[(int)Name].P_Start].GetComponent<CrossBase>().GetName()==Name)
            {
                Debug.Log("Khoong the ra quan");
                return;
            }
            else{
                CurrentPosition = GamePlayManager.Instance.levelConfig.Position[(int)Name].P_Start;
                this.transform.transform.position = GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position;
                GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].GetComponent<CrossBase>().SetPieces(this);
                IsOut = false;
                IsMoving = false;
                Step = 0;
                EndMoving();
                return; 
            }
        }
        else if(!IsOut)
        {
                bool CanMove = CheckCanMove();
                if (CanMove == true)
                {
                    Debug.Log("Co the di");
                    GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].GetComponent<CrossBase>().ClearPieces();
                    IsMoving = true;
                }
                else
                {
                    Debug.Log("Khong the di qua");
                    IsMoving = false;
                    return;
                }
        }
    }
    //Bo me no di
    //public bool CheckStepAfter()
    //{
    //    if (Step + stepdice <= GamePlayManager.Instance.TotalCross)
    //    {
    //        for (int i = CurrentPosition + 1; i <= CurrentPosition + stepdice; i++)
    //        {
    //            int temp = i;
    //            if (i > GamePlayManager.Instance.TotalCross)
    //            {
    //                temp = i - (GamePlayManager.Instance.TotalCross + 1);
    //            }
    //            if (i < (CurrentPosition + stepdice) && GamePlayManager.Instance.mapLevel.Crosses[temp].GetComponent<CrossBase>().GetName() != namePieces.None)
    //            {
    //                return true;
    //            }
    //            else if (i == (CurrentPosition + stepdice) && GamePlayManager.Instance.mapLevel.Crosses[temp].GetComponent<CrossBase>().GetName() == Name)
    //            {
    //                return true;
    //            }

    //        }
    //    }
    //    return false;
    //}
    public bool CheckCanMove()
    {
        stepdice = GamePlayManager.Instance.dice.GetDiceValue();
        if (IsOut)
        {
            if (stepdice == 1 || stepdice == 6)
            {
                if (GamePlayManager.Instance.mapLevel.Crosses[GamePlayManager.Instance.levelConfig.Position[(int)Name].P_Start].GetComponent<CrossBase>().GetName() == Name)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        if (!IsOut && Step + stepdice < GamePlayManager.Instance.TotalCross)
        {
            for (int i = CurrentPosition + 1; i <= CurrentPosition + stepdice; i++)
            {
                int temp = i;
                if (i > GamePlayManager.Instance.TotalCross)
                {
                    temp = i - (GamePlayManager.Instance.TotalCross + 1);
                }
                if (i < (CurrentPosition + stepdice) && GamePlayManager.Instance.mapLevel.Crosses[temp].GetComponent<CrossBase>().GetName() != namePieces.None)
                {
                    return false;
                }
                if (i == (CurrentPosition + stepdice) && GamePlayManager.Instance.mapLevel.Crosses[temp].GetComponent<CrossBase>().GetName() == Name)
                {
                    return false;
                }

            }
            return true;

        }
        return true;
    }

    public void Back()
    {
        this.transform.position = DefaultPosition;
        Step = 0;
        CurrentPosition = 0;
        IsOut = true;
        IsMoving = false;

    }
    public void EndMoving()
    {
        GamePlayManager.Instance.NextTurn();
    }
}
