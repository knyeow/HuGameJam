using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    [SerializeField] private float speed;
    private int a = 1;

    private void Update()
    {
        StartCoroutine(Spin());
    }



    IEnumerator Spin()
    {
        transform.rotation = Quaternion.Euler(0, 0, speed * a * transform.position.x);
        a++;
        yield return new WaitForSeconds(0.01f);
    }
}
