using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sc_PointDeVie : MonoBehaviour
{
    public int maxHealth = 3; // Nombre maximal de points de vie
    [SerializeField] private int currentHealth; // Points de vie actuels
    public bool invinsible = false;
    public TextMeshProUGUI textHP;
    
    void Start()
    {
        currentHealth = maxHealth; // Initialiser les points de vie actuels au maximum au début du jeu
        textHP.text = maxHealth + " PV";
    }

    // Méthode pour enlever des points de vie au joueur
    public void TakeDamage(int damageAmount)
    {
        if(invinsible == false)
        {
            currentHealth -= damageAmount; // Réduire les points de vie actuels du montant de dommages reçus
            Debug.Log("Perte de : " + damageAmount + " hp");
            textHP.text = currentHealth + " PV";

            // Vérifier si le joueur est mort
            if (currentHealth <= 0)
            {
                Die(); // Appeler la fonction de mort du joueur
            }
        }
        
    }

    // Méthode pour récupérer des points de vie du joueur (si nécessaire)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Ajouter des points de vie au joueur
        textHP.text = currentHealth + " PV";

        // Limiter les points de vie actuels au maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Méthode pour gérer la mort du joueur
    void Die()
    {
        // Implémentez ici le code pour la mort du joueur, tel que la réinitialisation de la scène ou l'affichage d'un écran de fin de jeu
        Destroy(gameObject);
        // Exemple : SceneManager.LoadScene("GameOverScene");
    }

   
}
