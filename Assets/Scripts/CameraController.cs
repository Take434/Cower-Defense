using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
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
        cam.orthographicSize = 20f * zoom;
    }
}
