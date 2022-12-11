using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCamera : MonoBehaviour
{
    private GameObject planet;

    private float waitTimer = 0;


    private void Update()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");

        if (waitTimer >= 0.2f)
        transform.position = new Vector2(planet.transform.position.x, planet.transform.position.y);

        waitTimer += Time.deltaTime;
    }
}
