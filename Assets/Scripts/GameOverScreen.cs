using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
