using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float forceStrength = 10.0f;
    public float camSens = 0.50f;
    Vector3 lastMouse = new Vector3(255, 255, 255);
    ObjectPool myObjectPool = null;

    [SerializeField]
    GameObject bullet;

    private void Start()
    {
        myObjectPool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        CameraPosition();
        if (Input.GetButtonDown("Fire1"))
            ShootABullet();
    }

    void CameraPosition()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }

    void ShootABullet()
    {
        //GameObject bulletInstance = myObjectPool.GetPooledObject();
        //if (bulletInstance != null)
        //{
        //    bulletInstance.transform.position = transform.position;
        //    Bullet bt = bulletInstance.GetComponent<Bullet>();
        //    bt.Start();
        //    bt.Shoot(transform.forward * forceStrength);
        //}

        GameObject bulletInstance = myObjectPool.GetPooledObject();
        if (bulletInstance != null)
        {
            bulletInstance.transform.position = transform.position;
            Bullet bt = bulletInstance.GetComponent<Bullet>();
            bt.Start();
            bt.Shoot(transform.forward * forceStrength);
        }
    }
}