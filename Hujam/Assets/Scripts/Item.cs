using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject referenceObject;

    [SerializeField] private GameObject returnButton;

    private SpriteRenderer sr;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sr = GetComponent<SpriteRenderer>();
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

    IEnumerator EndGame()
    {
        referenceObject.SetActive(true);
        sr.enabled = false;
        yield return new WaitForSeconds(0.5f);
        while (mainCamera.orthographicSize < 20)
        {
            mainCamera.orthographicSize += 0.25f;
            yield return new WaitForSeconds(0.01f);
        }

        

    }  
}
