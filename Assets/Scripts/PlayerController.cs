using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 10.0f;
    [SerializeField]
    float speedIncrease;
    [SerializeField]
    float speedDecrease;
    [SerializeField]
    float speedMax = 1.0f;
    [SerializeField]
    float speedMin = 1.0f;
    [SerializeField]
    int pointsPerSecond = 1;
    [SerializeField]
    int pointsPerHealthyFood = 10;
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
    [SerializeField]
    ScoreCounter scoreCounter;
    [SerializeField]
    GameObject tryAgainButton;
    Rigidbody rb;
    float timePassed = 0;


    void Start () {
        rb = GetComponent<Rigidbody>();
        transform.localScale = scale;
    }
	
    void Update () {
        if (lifeCounter.GetLifeCount() > 0)
        {
            rb.AddForce(new Vector3(
                Input.GetAxis("Horizontal") * speed,
                0.0f,
                Input.GetAxis("Vertical") * speed
            ));
        }
        timePassed += Time.deltaTime;
        if (timePassed >= 1)
        {
            scoreCounter.GainPoints(pointsPerSecond);
            timePassed = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (lifeCounter.GetLifeCount() == 0)
        {
            return;
        }
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
        speed = Mathf.Max(speed - speedDecrease, speedMin);
        // Lose life
        int livesRemaining = lifeCounter.LoseLife();
        if (livesRemaining == 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
            tryAgainButton.SetActive(true);
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
        speed = Mathf.Min(speed + speedIncrease, speedMax);
        // Gain points
        scoreCounter.GainPoints(pointsPerHealthyFood);
    }
}
