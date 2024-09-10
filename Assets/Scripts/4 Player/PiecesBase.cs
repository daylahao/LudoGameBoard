using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    public Animator animator;
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
            if (stepdice != 0)
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

            if (Step+stepdice<=GamePlayManager.Instance.TotalCross)
            {
                if (stepdice > 0 && (Step + stepdice) <= GamePlayManager.Instance.TotalCross)
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
                else if (this.transform.position == GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position)
                {
                    //this.transform.position = GamePlayManager.Instance.Crosses[CurrentPosition].transform.position;
                    GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].GetComponent<CrossBase>().SetPieces(this);
                    IsMoving = false;
                    EndMoving();
                    return;
                }
                if (CurrentPosition <= GamePlayManager.Instance.TotalCross)
                    this.transform.position = Vector3.MoveTowards(this.transform.position, GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].transform.position, 0.1f);
            }
            else
            {
                if (Step== GamePlayManager.Instance.TotalCross)
                {
                    Step++;
                    CurrentPosition = 0;
                    stepdice--;

                }
                if (stepdice>0 && this.transform.position == GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[CurrentPosition].transform.position)
                {

                    Step++;
                    stepdice--;
                    CurrentPosition++;
                    //Debug.Log(CurrentPosition);
                }
                else if (this.transform.position == GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[CurrentPosition].transform.position)
                {
                    //this.transform.position = GamePlayManager.Instance.Crosses[CurrentPosition].transform.position;
                    GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[CurrentPosition].SetPieces(this);
                    IsMoving = false;
                    EndMoving();
                    return;
                }
                this.transform.position = Vector3.MoveTowards(this.transform.position, GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[CurrentPosition].transform.position, 0.1f);
            
            }
            animator.Play("Run");
        }
    }
    public void Move(int step_)
    {
        if (IsOut && (step_ == 1 || step_ == 6))
        {
            if (GamePlayManager.Instance.mapLevel.Crosses[GamePlayManager.Instance.levelConfig.Position[GamePlayManager.Instance.turnTemp].P_Start].GetComponent<CrossBase>().GetName()==Name)
            {
                MangerUIScene4.Instance.infoText.text = "Xúc xắc 1 hoặc 6\nmới được ra quân";
                //Debug.Log("Khoong the ra quan");
                return;
            }
            else{
                CurrentPosition = GamePlayManager.Instance.levelConfig.Position[GamePlayManager.Instance.turnTemp].P_Start;
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
                if (Step<=GamePlayManager.Instance.TotalCross)
                {
                    GamePlayManager.Instance.mapLevel.Crosses[CurrentPosition].GetComponent<CrossBase>().ClearPieces();
                }
                if (Step > GamePlayManager.Instance.TotalCross)
                {
                    GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[CurrentPosition].ClearPieces();
                }
                    IsMoving = true;
                }
                else
                {
                    //Debug.Log("Khong the di qua");
                    IsMoving = false;
                    return;
                }
        }
    }
    public bool CheckCanMove()
    {
        stepdice = GamePlayManager.Instance.dice.GetDiceValue();
        if (IsOut)
        {
            if (stepdice == 1 || stepdice == 6)
            {
                if (GamePlayManager.Instance.mapLevel.Crosses[GamePlayManager.Instance.levelConfig.Position[GamePlayManager.Instance.turnTemp].P_Start].GetComponent<CrossBase>().GetName() == Name)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        if (!IsOut && Step + stepdice <=GamePlayManager.Instance.TotalCross)
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

        }else//Lên chuồng
        if (!IsOut && (Step + stepdice) > GamePlayManager.Instance.TotalCross && Step>=GamePlayManager.Instance.TotalCross)
        {
            if ((Step + stepdice) - GamePlayManager.Instance.TotalCross <=GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses.Count)
            {
                int temp = (Step + stepdice) - GamePlayManager.Instance.TotalCross;
                int temp1 = Step - GamePlayManager.Instance.TotalCross;
                if(Step>GamePlayManager.Instance.TotalCross)
                {
                    temp1 +=1;
                }
                for (int i = temp1; i <temp; i++)
                {
                   
                    if (GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[i].GetName() != namePieces.None)
                    {
                        Debug.Log(GamePlayManager.Instance.mapLevel.houses[GamePlayManager.Instance.turnTemp].Crosses[i].GetName());
                        Debug.Log("Khong the di qua trong chuong");
                        return false;
                    }
                }
                Debug.Log("Co the di qua trong chuong");
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(!IsOut && (Step + stepdice) > GamePlayManager.Instance.TotalCross && Step < GamePlayManager.Instance.TotalCross)
        {
            return false;
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
        MangerUIScene4.Instance.infoText.text = "Kết thúc lượt!\nLắc xúc xắc";
        GamePlayManager.Instance.NextTurn();
    }
}
