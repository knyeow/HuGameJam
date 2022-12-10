using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject engineButton;
    private bool forOnce;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!forOnce &&dialogue.isFinished)
        {
            engineButton.SetActive(true);
            forOnce = true;
        }
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

    public void StartEngine()
    {
        anim.SetBool("boost", true);
    }
}
