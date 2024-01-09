using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Slider zoomSlider;
    private CameraController cam;
    private Color planeColor;
    private Image planeImage;

    public void Awake() {
        cam = Camera.main.GetComponent<CameraController>();
        planeImage = gameObject.GetComponent<Image>();
        planeColor = planeImage.color;
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

    public void BeginDragZoomSlider() {
        planeImage.color = new Color(planeColor.r, planeColor.g, planeColor.b, 0.5f);
    }

    public void EndDragZoomSlider() {
        planeImage.color = planeColor;
    }
}
