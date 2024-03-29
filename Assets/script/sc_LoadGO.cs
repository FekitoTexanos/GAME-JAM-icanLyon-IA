using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_LoadGO : MonoBehaviour
{

    public GameObject player;

    public void Update()
    {
        if (!player)
        {
            StartGameOver();
        }
    }


    public void StartGameOver()
    {
        StartCoroutine(GameOver());
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}
