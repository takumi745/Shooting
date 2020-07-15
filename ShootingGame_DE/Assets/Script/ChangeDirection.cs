using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (pos.z < 0)
        {
            rb.velocity = Vector3.zero;

            rb.AddForce(new Vector3(300, 0, 300) * Time.deltaTime * -30);
        }
    }
}
