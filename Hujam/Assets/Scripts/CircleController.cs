using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private BoxCollider2D bc;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }



    private void Update()
    {

        if (isPlayer())
            sr.sortingLayerName = "player";
        else
            sr.sortingLayerName = "FrontLevel";

        
    }


    private bool isPlayer()
    {
        RaycastHit2D check = Physics2D.CircleCast(bc.bounds.center, 3f, Vector2.down, 0.1f, playerLayer);
        RaycastHit2D check2 = Physics2D.CircleCast(bc.bounds.center, 3f, Vector2.up, 0.1f, playerLayer);

        return check || check2;
    }

}
