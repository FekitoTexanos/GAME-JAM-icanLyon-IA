using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CameraFollow : MonoBehaviour
{
     
    public Transform target; // R�f�rence au transform du joueur
    public Vector2 offset = new Vector2(0f, 2f); // Offset pour ajuster la position de la cam�ra par rapport au joueur
    public float smoothSpeed = 0.125f; // Vitesse de d�placement de la cam�ra

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z); // Calcul de la position d�sir�e de la cam�ra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Lissage du d�placement de la cam�ra
        transform.position = smoothedPosition; // Mise � jour de la position de la cam�ra
    }
}
