using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDragon : MonoBehaviour
{
    private Rigidbody rb;
    private bool is_ok = true;
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        DragonJump();
        
    }

   

    public void DragonJump()
    {
        if (is_ok)
        {
            StartCoroutine(TempsEntreSaut());

        }
        is_ok = false;
    }
    
    public IEnumerator TempsEntreSaut()
    {
        yield return new WaitForSeconds(4f);
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        is_ok = true;
    }

}
