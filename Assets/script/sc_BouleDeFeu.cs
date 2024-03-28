using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class sc_BouleDeFeu : MonoBehaviour
{

    

    public GameObject fireballPrefab; // Préfabriqué de la boule de feu   

    public int damage = 1; // Dommage infligé au joueur

    
    
    public GameObject endPoint;   // Point B
    

    

    public float BouleDeFeuRadius = 20f;
    public float BouleDeFeuCD;
    public float BouleDeFeuSpeed = 50f;
    private bool is_ok_to_start = true;
    

    public Vector3 DirectionPlayer;
    private Rigidbody rbFireBall;

    void Update()
    {
        if (is_ok_to_start)
        {
            StartCoroutine(AttenteAvantLancerBouleDeFeu());
            is_ok_to_start = false;

        }
        
        
    }
    public IEnumerator AttenteAvantLancerBouleDeFeu()
    {

        yield return new WaitForSeconds(BouleDeFeuCD);
        Collider[] colliders = Physics.OverlapSphere(transform.position, BouleDeFeuRadius);
        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("Player"))
            {
                SpawnFireball(); 
            }
        }
        is_ok_to_start = true;
    }
    void SpawnFireball()
    {
       
        GameObject fireball = Instantiate(fireballPrefab, gameObject.transform.position, Quaternion.identity);
        //fireball.AddComponent<BoxCollider>();
        //fireball.GetComponent<BoxCollider>().isTrigger = true;
        fireball.tag = "SortEnnemi";

        fireball.AddComponent<Rigidbody>();
        
        rbFireBall = fireball.GetComponent<Rigidbody>();
        rbFireBall.useGravity = false;
        rbFireBall.freezeRotation = true;

        //DirectionPlayer = (endPoint.transform.position - gameObject.transform.position);
        DirectionPlayer = endPoint.transform.position + 10 * (endPoint.transform.position - gameObject.transform.position);

        fireball.AddComponent<sc_BouleDeFeuDéplacement>().Initialize( gameObject, DirectionPlayer, BouleDeFeuSpeed);
    }

    
    void OnTriggerEnter(Collider other)
    {
        // Vérifier si la collision est avec le joueur
        if (other.CompareTag("Player"))
        {
            other.GetComponent<sc_PointDeVie>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, BouleDeFeuRadius );
    }
}
