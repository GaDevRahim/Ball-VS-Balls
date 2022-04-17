using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFocalPoint : MonoBehaviour
{
    float horizontalInput;
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * speed;
        transform.Rotate(0, horizontalInput, 0);
    }
}
