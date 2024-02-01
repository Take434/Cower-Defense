using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenShake : MonoBehaviour
{
    public Shader screenShake;
    public float shakeTime = 0f;
    private Material mat;

    void OnEnable() {
        mat = new Material(screenShake);
        mat.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if(shakeTime <= 0) {
            Graphics.Blit(source, destination);
            return;
        }
        shakeTime -= Time.deltaTime;
        Graphics.Blit(source, destination, mat);
    }
}
