using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovingobject : MonoBehaviour
{
    Vector2 startPos;
    [SerializeField] float speedx;
    [SerializeField] float amplitudex;
    [SerializeField] float speedy;
    [SerializeField] float amplitudey;
    [SerializeField] GameObject bulletPrefab;
    //[SerializeField] float bulletSpeed = 3.0f;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        float posX = startPos.x + Mathf.Cos(Time.time * speedx) * amplitudex;

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        float posY = startPos.y + Mathf.Sin(Time.time * speedy) * amplitudey;

        transform.position = new Vector3(transform.position.x, posY, transform.position.z);

        shooting();

    }

    void shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //bulletRb.AddForce(transform.up * bulletSpeed);
        }
    }

}
