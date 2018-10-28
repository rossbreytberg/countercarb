using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSkybox : MonoBehaviour {
    [SerializeField]
    float speed = 1.0f;

    void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
