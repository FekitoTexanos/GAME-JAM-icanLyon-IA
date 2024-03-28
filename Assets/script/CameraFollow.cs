using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CameraFollow : MonoBehaviour
{
     
    public Transform target; // Référence au transform du joueur
    public Vector2 offset = new Vector2(0f, 2f); // Offset pour ajuster la position de la caméra par rapport au joueur
    public float smoothSpeed = 0.125f; // Vitesse de déplacement de la caméra

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z); // Calcul de la position désirée de la caméra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Lissage du déplacement de la caméra
        transform.position = smoothedPosition; // Mise à jour de la position de la caméra
    }
}
