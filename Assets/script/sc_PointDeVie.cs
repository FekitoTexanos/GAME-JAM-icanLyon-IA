using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sc_PointDeVie : MonoBehaviour
{
    public int maxHealth = 3; // Nombre maximal de points de vie
    [SerializeField] private int currentHealth; // Points de vie actuels
    public bool invinsible = false;
    public TextMeshProUGUI textHP;
    
    public GameObject GameManager;
    void Start()
    {
        currentHealth = maxHealth; // Initialiser les points de vie actuels au maximum au d�but du jeu
        textHP.text = maxHealth + " PV";
    }

    // M�thode pour enlever des points de vie au joueur
    public void TakeDamage(int damageAmount)
    {
        if(invinsible == false)
        {
            currentHealth -= damageAmount; // R�duire les points de vie actuels du montant de dommages re�us
            Debug.Log("Perte de : " + damageAmount + " hp");
            StartCoroutine(AnimDmg());
            textHP.text = currentHealth + " PV";

            // V�rifier si le joueur est mort
            if (currentHealth <= 0)
            {
                Die(); // Appeler la fonction de mort du joueur
            }
        }
        
    }

    // M�thode pour r�cup�rer des points de vie du joueur (si n�cessaire)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Ajouter des points de vie au joueur
        textHP.text = currentHealth + " PV";
        StartCoroutine(AnimHeal());

        // Limiter les points de vie actuels au maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // M�thode pour g�rer la mort du joueur
    void Die()
    {
        // Impl�mentez ici le code pour la mort du joueur, tel que la r�initialisation de la sc�ne ou l'affichage d'un �cran de fin de jeu

        GameManager.GetComponent<sc_LoadGO>().StartGameOver();
        Destroy(gameObject);
        // Exemple : SceneManager.LoadScene("GameOverScene");
        
    }

    IEnumerator AnimDmg()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator AnimHeal()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
    }


}
