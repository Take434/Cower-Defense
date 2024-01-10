using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float shake = 0f;
    public float shakeAmount = 0.15f;
    public float decreaseFactor = 1.0f;

    private Vector3 lastShake = new Vector3(0, 0, 0);
    private Camera cam;

    [Range(0.0f, 5.0f)]
    [Tooltip("Set the target aspect ratio")]
    public float zoom = 1.0f;


    private void Awake() 
    {
        cam = GetComponent<Camera>();

        if(Application.isPlaying) {
            ScaleViewport();
        }
    }

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

        #if UNITY_EDITOR
            if(cam) {
                ScaleViewport();
            }
        #endif
    }

    public void Zoom(float value) 
    {
        zoom = value;
        ScaleViewport();
    }

    private void ScaleViewport() 
    {
        cam.orthographicSize = 14.33f * zoom;
    }
}
