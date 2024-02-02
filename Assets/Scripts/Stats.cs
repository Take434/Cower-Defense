using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    const float fpsMeasurePeriod = 0.5f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;
    public TextMeshProUGUI text;
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time: " + gameState.roundTime.ToString("F2") + "s";
        return;
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod)
        {
            m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
            text.SetText(m_CurrentFps.ToString() + " FPS");
            text.ForceMeshUpdate();
        }
    }
}
