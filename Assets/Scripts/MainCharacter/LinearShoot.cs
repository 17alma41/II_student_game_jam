using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearShoot : MonoBehaviour
{
    public void bulletShoot(Vector3 directionToMouse, float speed)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = directionToMouse * speed;
    }

}
