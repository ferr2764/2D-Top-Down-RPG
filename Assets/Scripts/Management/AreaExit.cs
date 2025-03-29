using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private float waitToLoadTime = 1f;
    private bool killedAllEnemies = false;
    public static bool GotItem { get; set; } = false;
    [SerializeField] bool suppressRequirement = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            killedAllEnemies = false;
            GotItem = false;
            PlayerHealth.Instance.HealAmount(10);
            SceneManagement.Instance.SceneTransitionName = sceneTransitionName;
            UIFade.Instance.Fade(1);
            StartCoroutine(LoadSceneCoroutine());
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        while(waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Update()
    {
        killedAllEnemies = CheckAllKilled();
        if(suppressRequirement ||(killedAllEnemies && GotItem))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private bool CheckAllKilled()
    {
        return (GameObject.FindWithTag("Enemy") == null) && (GameObject.FindWithTag("Boss") == null);
    }
}
