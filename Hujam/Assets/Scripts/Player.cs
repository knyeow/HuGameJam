using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Planet planet;

    private float horizontal;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    private Rigidbody2D rb;

    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;

    private bool isJumping = false;

    private void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(!IsGrounded())
        rb.AddForce(planet.GetVelocity(this.transform));


        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            // StartCoroutine(Jump());
            rb.AddForce((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * new Vector2(0, jumpPower)));
            Debug.Log("Jumped");
        }

        transform.rotation = Quaternion.Euler(planet.GetAngle(this.transform));
        if(horizontal !=0)
        transform.Translate(Vector2.right*(horizontal * moveSpeed));
    }


    private bool IsGrounded()
    {
        RaycastHit2D check = Physics2D.Raycast(feet.position, ((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * Vector2.down)), 0.2f, groundLayer);
        return check;
    }


}
