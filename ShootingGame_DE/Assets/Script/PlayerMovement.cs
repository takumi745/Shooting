using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float moveSpeed = 0.2f;

    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        // float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
        // float moveV = -Input.GetAxis("Vertical") * moveSpeed;

        float moveH = -Input.GetAxis("Mouse X") * moveSpeed;
        float moveV = -Input.GetAxis("Mouse Y") * moveSpeed;
        transform.Translate(moveH, 0.0f, moveV);

        Clamp();
    }

    void Clamp()
    {
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.y = Mathf.Clamp(pos.y, -10, 10);

        transform.position = pos;
    }
}
