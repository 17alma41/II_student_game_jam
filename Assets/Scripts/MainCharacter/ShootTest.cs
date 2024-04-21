using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] string ShootName;
    [SerializeField] float strenght;
    [SerializeField] float speed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]Transform bulletSpawnPoint;
    Vector3 globalMousePos;
    Vector3 directionToMouse;
 
    void Update()
    {

        globalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        globalMousePos.z = transform.position.z;
        directionToMouse = (globalMousePos - transform.position).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            bulletSpawnShoot();
        }
    }


    public void bulletSpawnShoot()
    {

        GameObject bulletInstanciada = Instantiate(
            bulletPrefab, 
            bulletSpawnPoint.position, 
            Quaternion.identity);

        LinearShoot linearShoot = bulletInstanciada.GetComponent<LinearShoot>();
        linearShoot.bulletShoot(directionToMouse, speed);

        Destroy(bulletInstanciada, 2f);
    }
}
