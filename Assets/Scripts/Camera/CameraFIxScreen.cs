using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFIxScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 16f / 9f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
