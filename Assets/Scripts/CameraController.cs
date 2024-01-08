using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float shake = 0f;
    public float shakeAmount = 0.15f;
    public float decreaseFactor = 1.0f;

    private Vector3 lastShake = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if(shake > 0) {
            Vector3 newShake = Random.insideUnitSphere * shakeAmount;
            transform.localPosition = transform.localPosition + newShake - lastShake;
            lastShake = newShake;
            shake -= Time.deltaTime * decreaseFactor;
        } else {
            shake = 0f;
        }
    }
}
