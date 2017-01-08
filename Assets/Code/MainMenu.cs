using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        PersistentData perd = FindObjectOfType<PersistentData>() as PersistentData;
        if (perd == null)
        {
            GameObject pd = new GameObject("PersistentDataGO");
            pd.AddComponent<PersistentData>();
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartGameAfterTransition());
    }

    IEnumerator StartGameAfterTransition()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
