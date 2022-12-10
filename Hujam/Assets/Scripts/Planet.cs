using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float planetMass;
    [SerializeField] private Vector2 planetDistance;
    private float planetDistanceFloat;
    private float angle;

    private Vector2 force;
    private float forcef;

    private GameObject player;
    private Rigidbody2D playerRb;
    private Transform playerTransform;

    public Vector2 playerVelocity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        //planetDistance = (transform.position-playerTransform.position);
        //planetDistanceFloat = Mathf.Sqrt(Mathf.Pow(planetDistance.x,2) + Mathf.Pow(planetDistance.y,2));
        //angle = Mathf.Atan2(planetDistance.y,planetDistance.x)*Mathf.Rad2Deg;


        //force = new Vector2(planetDistance.x != 0? planetMass / Mathf.Pow(planetDistance.x, 2):0, planetDistance.y != 0 ? planetMass / Mathf.Pow(planetDistance.y, 2) : 0);
        //forcef = planetMass / Mathf.Pow(planetDistanceFloat, 2);

        //playerVelocity = new Vector2(forcef*planetDistance.x,forcef*planetDistance.y);
        //playerTransform.rotation = Quaternion.Euler(0, 0,90 + angle);

        //Debug.Log(angle);
          
    }

    public Vector2 GetVelocity(Transform _transform)
    {
        planetDistance = (transform.position - _transform.position);
        planetDistanceFloat = Mathf.Sqrt(Mathf.Pow(planetDistance.x, 2) + Mathf.Pow(planetDistance.y, 2));
        forcef = planetMass / Mathf.Pow(planetDistanceFloat, 2);

        return new Vector2(forcef * planetDistance.x, forcef * planetDistance.y);
    }

    public Vector3 GetAngle(Transform _transform)
    {
        planetDistance = (transform.position - _transform.position);
        angle = Mathf.Atan2(planetDistance.y, planetDistance.x) * Mathf.Rad2Deg;
        return new Vector3(0, 0, 90 + angle);
    }

}
