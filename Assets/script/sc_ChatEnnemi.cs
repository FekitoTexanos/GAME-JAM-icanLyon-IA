using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ChatEnnemi : MonoBehaviour
{

    public float screamRadius; // Radius of the scream zone (modifiable in the Inspector)
    public float détectionplayer;
    public float ChatSpeed;
    public int damageScream = 1; // Damage inflicted to the player when touched by the scream zone
    public float CrisChatCD = 5f;

    private bool is_ok_to_start = true;

    public GameObject Scream;


    private void Update()
    {
        if (is_ok_to_start)
        {
            StartCoroutine(AttenteAvantCris());
            is_ok_to_start = false;
        }

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, détectionplayer);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {

                if (collider != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, ChatSpeed * Time.deltaTime);
                }

            }
        }
    }

    public IEnumerator AttenteAvantCris()
    {
        
        yield return new WaitForSeconds(CrisChatCD);
        Collider[] colliders = Physics.OverlapSphere(transform.position, screamRadius);
        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("Player"))
            {

                collider.GetComponent<sc_PointDeVie>().TakeDamage(damageScream);
                StartCoroutine(SpriteScream());
                
            }
        }
        is_ok_to_start = true;
    }

    public IEnumerator SpriteScream()
    {
        Scream.SetActive(true);
        yield return new WaitForSeconds(1f);
        Scream.SetActive(false);

    }

    // Visualize the scream zone in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }

    

}

