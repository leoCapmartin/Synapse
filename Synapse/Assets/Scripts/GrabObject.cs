using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : Interactions
{
    public Rigidbody rb;
    public override bool Interraction(Transform player, Transform cam)
    {
        if(!player.GetComponent<MyPlayer>().isHoldingObject)
        {
            Debug.Log("test");
            rb.isKinematic = true;
            transform.parent = cam;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = new Vector3(0.4f, -0.3f, 0.4f);
        }
        return !player.GetComponent<MyPlayer>().isHoldingObject;
    }
}
