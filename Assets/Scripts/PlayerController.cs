using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    float speed = 1.0f;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
    void Update () {
        rb.AddForce(new Vector3(
            Input.GetAxis("Horizontal") * speed,
            0.0f,
            Input.GetAxis("Vertical") * speed
        ));
    }
}
