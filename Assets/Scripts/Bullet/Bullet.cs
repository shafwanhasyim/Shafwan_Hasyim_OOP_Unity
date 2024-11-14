// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {

//     [Header("Bullet Stats")]
//     public float bulletSpeed = 20;
//     public int damage = 10;
//     private Rigidbody2D rb;



//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         rb.velocity = Vector2.up * bulletSpeed;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;
    // public IObjectPool<Bullet> objectPool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (objectPool != null)
    //     {
    //         objectPool.Release(this);
    //     }
    // }

    // void OnBecameInvisible()
    // {
    //     if (objectPool != null)
    //     {
    //         objectPool.Release(this);
    //     }
    // }
}