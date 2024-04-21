using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPos;

    //[SerializeField] float haciaDelante;
    [SerializeField] float smoothing;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);

        /*
         * Esto sería si mi jugador funcionase con localScale
        if (target.transform.localScale.x == 1) //Derecha
        {
            targetPos = new Vector3(targetPos.x + haciaDelante, targetPos.y, transform.position.z);
        }

        if (target.transform.localScale.x == -1) //Derecha
        {
            targetPos = new Vector3(targetPos.x + -haciaDelante, targetPos.y, transform.position.z);
        }
        */
    }
}
