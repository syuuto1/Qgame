using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncingbullet : MonoBehaviour
{
    private Rigidbody2D currentRigidbody;
    private int groundHitCount = 0;
    private Collider2D bulletCollider;

    [SerializeField] int Count;

    void Start()
    {
        currentRigidbody = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            groundHitCount++;

            if (groundHitCount >= Count)
            {
                bulletCollider.enabled = false; // Collider‚ğ–³Œø‚É‚·‚é
                // ‚·‚è”²‚¯‚½Œã‚É•K—v‚È‘¼‚Ìˆ—‚ğ‚±‚±‚É’Ç‰Á‚Å‚«‚Ü‚·
            }
        }

        if (collision.collider.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }

    }

}
