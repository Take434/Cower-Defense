using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Slider zoomSlider;
    private CameraController cam;

    public void Awake() {
        cam = Camera.main.GetComponent<CameraController>();

        zoomSlider = gameObject.GetComponentInChildren<Slider>();
        zoomSlider.onValueChanged.AddListener(ZoomSliderChanged);
        zoomSlider.value = cam.zoom;
    }

    public void OpenSettings() {
        gameObject.SetActive(true);
    }

    public void CloseSettings() {
        gameObject.SetActive(false);
    }

    public void ZoomSliderChanged(float value) {
        cam.Zoom(value);
    }
}
