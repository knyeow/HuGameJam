using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCrater : Crater
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private float craterTime;

    private BoxCollider2D bc;
    private float craterTimer=0;

    private bool onAction = false;

    protected override void Start()
    {
        base.Start();
        bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(craterTimer > craterTime)
        {
            StartCoroutine(Boomer());
        }

        
        if(!onAction)
        craterTimer += Time.deltaTime;
    }

    IEnumerator Boomer()
    {
        craterTimer = 0;
        onAction = true;
        ps.Play();
        yield return new WaitForSeconds(0.5f);
        bc.enabled = true;
        yield return new WaitForSeconds(3f);
        ps.Stop();
        yield return new WaitForSeconds(0.2f);
        bc.enabled = false;
        onAction = false;
    }
}
