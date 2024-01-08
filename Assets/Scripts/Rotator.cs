using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float rate;

    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rate * Time.deltaTime, transform.up);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
