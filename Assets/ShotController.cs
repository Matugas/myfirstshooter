using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public float speed = 1f;
    public float lifeTime = 10f;

    public GameObject impactPrefab;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(impactPrefab, transform.position, Quaternion.identity);
    }
}
