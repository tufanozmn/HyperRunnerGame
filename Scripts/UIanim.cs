using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIanim : MonoBehaviour
{
    [SerializeField]
    private int genislik = 1;

    [SerializeField]
    private float tekrarlama = 0.1f;


    


    
    void Update()
    {

        float x = transform.position.x;
        float y = Mathf.Sin(Time.time*tekrarlama)*genislik;

        float z = transform.position.z;

        transform.position = new Vector3(x,y,z);
    }
    
}
