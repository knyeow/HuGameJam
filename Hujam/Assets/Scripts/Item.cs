using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject referenceObject;

    [SerializeField] private GameObject returnButton;

    [SerializeField] private AudioSource collectSound;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private Camera mainCamera;
    private Player player;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(mainCamera.orthographicSize > 19)
        {          
            returnButton.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndGame());
        }

    }

    public void EndGameStarter()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        referenceObject.SetActive(true);
        player.canDoubleJump = true;
        sr.enabled = false;
        collectSound.Play();
        bc.enabled = false;
        yield return new WaitForSeconds(0.5f);
        while (mainCamera.orthographicSize < 20)
        {
            mainCamera.orthographicSize += 0.25f;
            yield return new WaitForSeconds(0.01f);
        }

        

    }  
}
