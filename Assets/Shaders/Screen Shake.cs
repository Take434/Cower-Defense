using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenShake : MonoBehaviour
{
    public bool shakeEnabled = false;
    private Material mat;

    void OnEnable() {
        mat = new Material(Shader.Find("Hidden/Screen Shake"));
        mat.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if(!shakeEnabled) {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, mat);
    }
}
