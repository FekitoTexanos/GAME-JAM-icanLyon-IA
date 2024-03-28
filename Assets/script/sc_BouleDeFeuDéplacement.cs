using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sc_BouleDeFeuDéplacement : MonoBehaviour
{
   
    
    [SerializeField] private Vector3 DirectionPlayer;
    private float BouleDeFeuSpeed;
    public void Update()
    {
        MoveFireBall();
    }


    public void Initialize( GameObject startPoint ,Vector3 DirectionPlayer, float BouleDeFeuSpeed)
    {
        
        gameObject.transform.position = startPoint.transform.position;
        this.DirectionPlayer = DirectionPlayer;
        this.BouleDeFeuSpeed = BouleDeFeuSpeed;
        
    }

    public void MoveFireBall()
    {
        
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, DirectionPlayer, BouleDeFeuSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<sc_PointDeVie>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        
    }
}
