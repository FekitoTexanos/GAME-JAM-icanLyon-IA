using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_LoadGO : MonoBehaviour
{
    private bool is_ok;
    public GameObject player;

   


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
