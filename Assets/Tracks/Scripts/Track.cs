using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Track : MonoBehaviour
{
    /// <summary>
    /// Is the thing moving in the right direction?
    /// </summary>
    public abstract bool IsMovingForward(Rigidbody thing);
}
