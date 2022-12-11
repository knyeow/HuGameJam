using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScene1 : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogue.SetActive(true);
        }

    }
}
