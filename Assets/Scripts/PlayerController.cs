using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float speedIncrease;
    [SerializeField]
    float speedDecrease;
    [SerializeField]
    float speedMax = 1.0f;
    [SerializeField]
    float speedMin = 1.0f;
    [SerializeField]
    Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField]
    Vector3 scaleIncrease;
    [SerializeField]
    Vector3 scaleDecrease;
    [SerializeField]
    Vector3 scaleMax = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField]
    Vector3 scaleMin = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField]
    LifeCounter lifeCounter;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        transform.localScale = scale;
    }
	
    void Update () {
        rb.AddForce(new Vector3(
            Input.GetAxis("Horizontal") * speed,
            0.0f,
            Input.GetAxis("Vertical") * speed
        ));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bread") ||
            collision.gameObject.name.Contains("Pizza"))
        {
            OnHitUnhealthyFood(collision);
        } else if (collision.gameObject.name.Contains("Cabbage") ||
                   collision.gameObject.name.Contains("Tomato"))
        {
            OnHitHealthyFood(collision);
        }
    }

    void OnHitUnhealthyFood(Collision collision)
    {
        // Remove object
        Destroy(collision.gameObject);
        // Make player larger
        Vector3 scaleNew = transform.localScale + scaleIncrease;
        transform.localScale = scaleNew.magnitude < scaleMax.magnitude ? scaleNew : scaleMax;
        // Make player slower
        //speed = Mathf.Max(speed - speedDecrease, speedMin);
        // Lose life
        int livesRemaining = lifeCounter.LoseLife();
        if (livesRemaining == 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }
    }

    void OnHitHealthyFood(Collision collision)
    {
        // Remove object
        Destroy(collision.gameObject);
        // Make player smaller
        Vector3 scaleNew = transform.localScale - scaleDecrease;
        transform.localScale = scaleNew.magnitude > scaleMin.magnitude ? scaleNew : scaleMin;
        // Make player faster
        //speed = Mathf.Min(speed + speedIncrease, speedMax);
    }
}
