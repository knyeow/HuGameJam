using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float horizontal;

    private Rigidbody2D rb;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        anim.SetBool("walk", horizontal != 0);

        if (horizontal != 0)
            transform.localScale = new Vector2(Mathf.Sign(horizontal), transform.localScale.y);
    }
}
