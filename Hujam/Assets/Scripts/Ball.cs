using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Traps
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Planet planet;

    protected override void Start()
    {
        base.Start();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(planet.GetAngle(this.transform));
        transform.Translate(Vector2.right * new Vector2(speed, 0));
    }
}
