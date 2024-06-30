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
    [SerializeField] float shootInterval;

    private float shootTimer;

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

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            shootTimer = 0.0f; // タイマーをリセット
        }
    }

}
