using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public namePieces Turn;
    public List<CrossBase> crossBases;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< this.gameObject.transform.childCount; i++)
        {

           crossBases.Add(this.gameObject.transform.GetChild(i).GetComponent<CrossBase>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
