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
    private float originalSize;

    [Range(0.0f, 5.0f)]
    [Tooltip("Set the target aspect ratio")]
    public float zoom = 1.0f;


    private void Awake() 
    {
        cam = GetComponent<Camera>();
        originalSize = cam.orthographicSize;

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
        // float currentAspect = (float)Screen.width / (float)Screen.height;
        // float scaleHeight = currentAspect / zoom;

        // if(scaleHeight < 1.0f) {
        //     Rect rect = cam.rect;

        //     rect.width = 1.0f;
        //     rect.height = scaleHeight;
        //     rect.x = 0;
        //     rect.y = (1.0f - scaleHeight) / 2.0f;

        //     cam.rect = rect;
        // } else {
        //     float scaleWidth = 1.0f / scaleHeight;

        //     Rect rect = cam.rect;

        //     rect.width = scaleWidth;
        //     rect.height = 1.0f;
        //     rect.x = (1.0f - scaleWidth) / 2.0f;
        //     rect.y = 0;

        //     cam.rect = rect;
        // }
        cam.orthographicSize = 14.33f * zoom;
    }
}
