using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Interactions : MonoBehaviour
{
    public string interractionInfo;
    public abstract bool Interraction(Transform player, Transform cam);
}
