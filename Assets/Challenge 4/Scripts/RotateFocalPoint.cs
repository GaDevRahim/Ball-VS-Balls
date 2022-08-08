using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFocalPoint : MonoBehaviour
{
    float horizontalInput;
    float speed = 5.0f;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * speed;
        transform.Rotate(0, horizontalInput, 0);
    }
}
