using UnityEngine;
using System.Collections;

public class testobject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 500;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    void Update()
    {
        // check distance entre objet et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si - ou = 1.9 unitÃ©s de distance = on peut ramasser
        if (dist <= 3.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        // si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent< Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        // Si on porte l'objet
        if (beingCarried)
        {
            // si l'objet touche un mur / objet avec collider
            if (touched)
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            // Clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent< Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // DÃ©tection de contact grace au collider is trigger
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
