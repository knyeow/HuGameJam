using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int lerp;

    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smoothPoint = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), lerp * Time.deltaTime);
        transform.position = smoothPoint;
    }
}
