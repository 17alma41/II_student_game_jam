using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;

    float targetPosX;
    float targetPosY;

    float posX;
    float posY;

    public float rightMax;
    public float leftMax;

    public float maxHeight;
    public float minHeight;

    public float speed;
    public bool encendida = true;

    Vector3 targetPos;

    //[SerializeField] float haciaDelante;
    //[SerializeField] float smoothing;

    private void Awake()
    {
        posX = targetPosX + rightMax;
        posY = targetPosY + minHeight;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();

        //targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);

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

    void MoveCamera()
    {
        if (encendida)
        {
            if (target)
            {
                targetPosX = target.transform.position.x;
                targetPosY = target.transform.position.y;

                if (targetPosX > maxHeight && targetPosY < leftMax)
                    posX = targetPosX;
                if (targetPosY < maxHeight && targetPosY > minHeight)
                    posY = targetPosY;

            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);

        }
    }
}