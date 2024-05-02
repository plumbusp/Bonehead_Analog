using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public void Initialize()
    {
        Debug.Log("Coin Start");
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}
