using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject engineButton;


    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }






    public void StartRealEngine()
    {
        anim.SetBool("endboost", true);
    }


    public void RealEndGame()
    {
        endText.SetActive(true);
        engineButton.SetActive(false);
;    }
}
