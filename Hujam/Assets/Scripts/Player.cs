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
    private Animator anim;
    private BoxCollider2D bc;

    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;


    private Vector2 startPosition;

    public bool isDying=false;

    private float jumpTimer = 0;


    private bool doubleJump = false;
    public bool canDoubleJump = false;


    

    private void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();

        startPosition = transform.position;
    }

    private void Update()
    {
        if (isDying)
            return;

        horizontal = Input.GetAxis("Horizontal");

        anim.SetBool("walk", horizontal != 0);

        if (Input.GetKeyDown(KeyCode.Space) && doubleJump &&canDoubleJump)
        {
            rb.AddForce((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * new Vector2(0, jumpPower)));
            anim.SetBool("jump", true);
            jumpTimer = 0;
            doubleJump = false;
            Debug.Log("doublejumped");
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * new Vector2(0, jumpPower)));
            anim.SetBool("jump", true);
            jumpTimer = 0;
            StartCoroutine(DoubleJump());
        }
        

        jumpTimer += Time.deltaTime;

        if (jumpTimer > 1.5f && IsGrounded())
        {
            anim.SetBool("jump", false);
            doubleJump = false;
        }

        if (horizontal != 0)
        transform.localScale = new Vector2(Mathf.Sign(horizontal), transform.localScale.y);
    }

    private void FixedUpdate()
    {
        if (isDying)
            return;

        if (!IsGrounded())
            rb.AddForce(planet.GetVelocity(this.transform));


     

        transform.rotation = Quaternion.Euler(planet.GetAngle(this.transform));

        transform.Translate(Vector2.right * (horizontal * moveSpeed));
    }
    private bool IsGrounded()
    {
        RaycastHit2D check = Physics2D.Raycast(feet.position, ((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * Vector2.down)), 0.2f, groundLayer);
        return check;
    }

    public void Kill()
    {
        if(!isDying)
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        //dieAnimaton
        isDying = true;
        bc.enabled = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("die", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("die", false);
        anim.SetBool("rebirth", true);
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        anim.SetBool("rebirth", false);
        isDying = false;
        bc.enabled = true;
    }

    public void Fly()
    {
        StartCoroutine(FlyRoutine());
    }

    IEnumerator FlyRoutine()
    {
        isDying = true;
        rb.AddForce((Vector2)(Quaternion.Euler(planet.GetAngle(this.transform)) * new Vector2(0, jumpPower*3)));
        yield return new WaitForSeconds(3f);
        StartCoroutine(Die());
    }

    IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(0.5f);
        doubleJump = true;
    }


}
