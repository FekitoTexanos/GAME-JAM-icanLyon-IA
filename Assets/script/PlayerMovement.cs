using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
    private bool is_ok_to_jump = false;
    

    
    
    public float speedJump = 10f;
    public float speedJumpMultiplicar = 1.5f;
    public float effectDuration = 5f;
    private float gravityInpluse = 15f;
    private bool is_ok_mur = false;

    public Sprite KirbyMarcheDroite;
    public Sprite KirbyMarcheGauche;
    public Sprite KirbyDroite;
    public Sprite KirbyGauche;
    public Sprite KirbyChute;


    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (is_ok_to_jump == false)
        {
            rb.AddForce(Vector2.down * gravityInpluse * Time.deltaTime, ForceMode.Impulse);
            gameObject.GetComponent<SpriteRenderer>().sprite = KirbyChute;

        }
        if (Input.GetKey(KeyCode.D) && is_ok_mur == false)
        {

            rb.velocity = new Vector3(10, rb.velocity.y, 0);
            gameObject.GetComponent<SpriteRenderer>().sprite = KirbyMarcheDroite;

        }
        if (Input.GetKeyUp(KeyCode.D) && is_ok_mur == false)
        {

            
            gameObject.GetComponent<SpriteRenderer>().sprite = KirbyDroite;

        }

        if (Input.GetKey(KeyCode.A) && is_ok_mur == false)
            {
            rb.velocity = new Vector3(-10, rb.velocity.y, 0);
            gameObject.GetComponent<SpriteRenderer>().sprite = KirbyMarcheGauche;

        }
        if (Input.GetKeyUp(KeyCode.A) && is_ok_mur == false)
        {


            gameObject.GetComponent<SpriteRenderer>().sprite = KirbyGauche;

        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && is_ok_to_jump == true && is_ok_mur == false)
        {

            rb.AddForce(Vector3.up * speedJump, ForceMode.Impulse);
            is_ok_to_jump = false;
        }
        


        //rb.transform.position = Vector3.MoveTowards(rb.transform.position, new Vector3(0,10,0), gravityInpluse * Time.deltaTime);





    }

    

    public void ApplyJumpBoost()
    {
        speedJump *= speedJumpMultiplicar;
        StartCoroutine(AnimPowerJump());
        
    }

    public void RemoveJumpBoost()
    {
        speedJump /= speedJumpMultiplicar;
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            is_ok_to_jump = true;
            
        }
        if (collision.gameObject.CompareTag("Ennemi"))
        {

            if (collision.transform.position.y < transform.position.y)
            {
                rb.AddForce(Vector3.up * speedJump, ForceMode.Impulse);
                Destroy(collision.gameObject);
            }
            else
            {
                gameObject.GetComponent<sc_PointDeVie>().TakeDamage(1);
            }

        }
        


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mur"))
        {
            is_ok_mur = false;
            
        }
    }



    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PowerupJump"))
        {
            ApplyJumpBoost();
            StartCoroutine(DisableJumpBoost());
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("PowerupInvinsible"))
        {
            
            Destroy(other.gameObject);
            StartCoroutine(TempsInvinsible());

        }
        if (other.gameObject.CompareTag("PowerupHEAL"))
        {

            Destroy(other.gameObject);
            gameObject.GetComponent<sc_PointDeVie>().Heal(1);

        }
        if (other.gameObject.CompareTag("Mur") && !other.gameObject.CompareTag("Floor"))
        {
            is_ok_mur = true;
            

        }
        if (other.gameObject.CompareTag("Flag"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Win");

        }

    }
   

    

    IEnumerator TempsInvinsible()
    {
        gameObject.GetComponent<sc_PointDeVie>().invinsible = true;
        StartCoroutine(AnimPowerInvinsible());
        Debug.Log("5s d'invinsibilité");
        yield return new WaitForSeconds(effectDuration);
        gameObject.GetComponent<sc_PointDeVie>().invinsible = false;
        Debug.Log("fin de powerUp");
    }

    IEnumerator DisableJumpBoost()
    {
        // Attend la fin de la durée de l'effet
        yield return new WaitForSeconds(effectDuration);

        // Désactive le boost de saut
        RemoveJumpBoost();
    }
    IEnumerator AnimPowerJump()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
    }

    IEnumerator AnimPowerInvinsible()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
    }



}