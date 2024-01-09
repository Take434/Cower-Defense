using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void Open() {
        gameObject.SetActive(true);
    }

    public void Exit() {
        gameObject.SetActive(false);
    }


}
