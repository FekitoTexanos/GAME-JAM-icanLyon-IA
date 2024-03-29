using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PlatformMovement : MonoBehaviour
{

    private bool is_okmove;
    public float speed;
    public Vector3 destination1;
    public Vector3 destination2;
    // Start is called before the first frame update
    public void Update()
    {
        
        
            if (is_okmove)
            {
                //On vient affecter à l'object une nouvelle poistion, celle de Destination1 et on lui demande de s'y rendre depuis sa position actuel
                //à une certaine vitesse grace à la fonction MoveTowards.

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                destination1, speed * Time.deltaTime);

            }
            if (!is_okmove)
            {
                //On vient affecter à l'object une nouvelle poistion, celle de Destination2 et on lui demande de s'y rendre depuis sa position actuel
                //à une certaine vitesse grace à la fonction MoveTowards.
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                destination2, speed * Time.deltaTime);

            }

            if(gameObject.transform.position == destination1)
                {
                is_okmove = true;
                }
            if (gameObject.transform.position == destination2)
                {
                is_okmove = false;
                }


    }
}
