using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        MouseMovementProcess();
    }

   

    void MouseMovementProcess()
    {
        Vector3 mousePos = new Vector3(0, 0, 0);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        Vector3 targetDir = (new Vector3(mousePos.x, transform.position.y, 0) - transform.position).normalized;

        float angle = Vector3.SignedAngle(Vector3.right, targetDir, Vector3.forward);

        if (targetDir.x < 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

    }
}
