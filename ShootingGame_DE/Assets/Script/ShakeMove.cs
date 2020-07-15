using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5.0f * Time.deltaTime * Mathf.Sin(Time.time * 2), -Time.deltaTime * Mathf.Sin(Time.time), 0);
    }
}
