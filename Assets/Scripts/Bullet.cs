using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] System.Action destroyed;

    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Line"))
        {
            speed = 0.0f;
        }
    }
}
