using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBase : MonoBehaviour
{
    public PiecesBase piecesGameObject;
    // Start is called before the first frame update
    void Start()
    {
        piecesGameObject= null;
    }
    public void SetPieces(PiecesBase pieces)
    {
        if(piecesGameObject==null)
        piecesGameObject = pieces;
        else
        {
            piecesGameObject.Back();
            piecesGameObject = pieces;
        }
    }
    public void ClearPieces()
    {

       piecesGameObject = null;
    }
    public namePieces GetName()
    {
        if(piecesGameObject)
        {
            return piecesGameObject.Name;
        }
        else
        {
            return namePieces.None; 
        }        
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.transform.gameObject.GetComponent<PiecesBase>())
    //    {
    //        Name = collision.transform.gameObject.GetComponent<PiecesBase>().Name;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Name = namePieces.None;   
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
