using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppQuit : MonoBehaviour
{


    public void Quit()
    {
        Debug.Log("Quitied");
        Application.Quit();
    }
}
