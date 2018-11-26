using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

	public void LoadStartmenu()
    {
        GameManager.Instance.LoadScene(1);
    }

    public void LoadGame()
    {
        GameManager.Instance.LoadScene(2);

    }

    public void LoadGameOver()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
