using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour {
    
    public Vector3 start;
    public Vector3 end;
    public float velocity = 1.0f;
    float dx;
    float dy;
    float dz;

    void Start () {
        transform.position = start;
        Vector3 distance = end - start;
        float ratio = (velocity / distance.magnitude);
        dx = distance.x * ratio;
        dy = distance.y * ratio;
        dz = distance.z * ratio;
    }
	
    void Update () {
		if (transform.position == end)
        {
            Object.Destroy(gameObject);
        } else
        {
            transform.position = new Vector3(
                GetNextValue(transform.position.x, dx, end.x),
                GetNextValue(transform.position.y, dy, end.y),
                GetNextValue(transform.position.z, dz, end.z)
            );
        }
	}

    float GetNextValue(float current, float diff, float end)
    {
        float nextValue = current + diff * Time.deltaTime;
        if ((diff > 0 && nextValue > end) || (diff < 0 && nextValue < end))
        {
            return end;
        }
        return nextValue;
    }
}
