using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private float waitToLoadTime = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched");
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Trans to " + sceneToLoad + " " + sceneTransitionName);
            SceneManagement.Instance.SceneTransitionName = sceneTransitionName;
            UIFade.Instance.Fade(1);
            StartCoroutine(LoadSceneCoroutine());
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        Debug.Log("Trans to " + sceneToLoad);
        while(waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
