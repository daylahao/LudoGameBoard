using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class Dice4 : MonoBehaviour
{
    public int diceValue;
    public int magic;
    // Start is called before the first frame update
    private SpriteRenderer diceRenderer;
    private Sprite[] diceFaces;
    public Button rollButton;
    private void Start()
    {
        diceRenderer = GetComponent<SpriteRenderer>();
        diceFaces = Resources.LoadAll<Sprite>("Dice/");
        rollButton.onClick.AddListener(OnRollDice);
        rollButton.GetComponent<Animator>().Play("ButtonActive");
    }
    public int GetDiceValue()
    {
        return diceValue;
    }
    public void OnRollDice()
    {
        SoundManager.Instance.PlayLoopFx(SoundName.DiceRoll.ToString());
        //Debug.Log("Roll Dice");
        StartCoroutine(RollDice());
        rollButton.GetComponent<Animator>().Play("IDLE");
        rollButton.interactable = false;
    }

    private IEnumerator RollDice()
    {
        int randomDiceFace = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceFace = Random.Range(0, diceFaces.Length);
            diceRenderer.sprite = diceFaces[randomDiceFace];
            yield return new WaitForSeconds(0.05f);
        }

        // Đảm bảo giá trị cuối cùng là từ 1 đến 6
        int diceValue_ = randomDiceFace + 1;

        diceRenderer.sprite = diceFaces[randomDiceFace]; // Cập nhật hình ảnh cuối cùng của xúc xắc
        SoundManager.Instance.StopFx();
        if (magic != 0)
        {
            diceValue_ = magic;
        }

            //Debug.Log("Xúc xắc hiện tại: " + diceValue_);
            //gameManager2.SetDiceResult(diceValue);
            diceValue = diceValue_;
            rollButton.interactable = false; // Lock button after rolling
         //if (diceValue != 6 || diceValue != 1)
         //   {
                GamePlayManager.Instance.CheckPieces();
            //}
    }
    public void ResetDice()
    {
        diceValue = 0;
            rollButton.interactable = true; // Enable button for next roll
            rollButton.GetComponent<Animator>().Play("ButtonActive");
        if (!GamePlayManager.Instance.Turnplayer.Contains(GamePlayManager.Instance.turnTemp))
        {
            rollButton.interactable = false; // Enable button for next roll
            StartCoroutine(DelayedExecution());
        }
    }
    private IEnumerator DelayedExecution()
    {
        Debug.Log("Start of coroutine");
        yield return new WaitForSeconds(0.5f);
        OnRollDice();
    }
}