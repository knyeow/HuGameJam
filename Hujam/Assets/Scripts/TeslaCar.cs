using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCar : Traps
{
    [SerializeField] public float speed;

    private Rigidbody2D rb;

    private Planet planet;

    protected override void Start()
    {
        base.Start();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(planet.GetVelocity(this.transform));
        transform.rotation = Quaternion.Euler(planet.GetAngle(this.transform));


        transform.Translate(Vector2.right * new Vector2(speed, 0));
    }
}
