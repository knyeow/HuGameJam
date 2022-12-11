using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class Item2 : MonoBehaviour
{

    [SerializeField] private GameObject referenceObject;

    [SerializeField] private GameObject returnButton;

    private SpriteRenderer sr;
    private Camera mainCamera;
    private Player player;

    private bool isEnding = false;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!isEnding)
        {
            StartCoroutine(Endgame());
        }
    }
    IEnumerator Endgame()
    {
        sr.enabled = false;
        isEnding = true;
        player.isDying = true;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<Animator>().SetBool("die", true);
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        GameObject[] PSs = GameObject.FindGameObjectsWithTag("PS");

        foreach (GameObject ps in PSs)
        {
            ps.GetComponent<ParticleSystem>().Play();
        }
        foreach(GameObject car in cars)
        {
            car.GetComponent<TeslaCar>().speed *= 3f;
            car.GetComponent<Light2D>().enabled = true;
        }
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject ps in PSs)
        {
            ps.GetComponent<ParticleSystem>().Play();
        }
        yield return new WaitForSeconds(4f);
        LoadNextLevel();

    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        yield return new WaitForSeconds(2f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
