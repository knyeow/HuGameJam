using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject symbol;

    private bool oneTime = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !oneTime)
        {
            dialogueBox.SetActive(true);
            symbol.SetActive(false);
            oneTime = true;
        }


    }
}
