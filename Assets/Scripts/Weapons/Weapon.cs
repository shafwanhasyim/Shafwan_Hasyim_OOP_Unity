// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Weapon : MonoBehaviour
// {
//     [Header("Weapon Stats")]
//     [SerializeField] private float shootIntervalInSeconds = 3f;

//     [Header("Bullets")]
//     public Bullet bullet;
//     [SerializeField] private Transform bulletSpawnPoint;

//     [Header("Bullet Pool")]
//     private IObjectPool<Bullet> objectPool;

//     private readonly bool collectionCheck = false;
//     private readonly int defaultCapacity = 30;
//     private readonly int maxSize = 100;
//     private float timer;
//     public Transform parentTransform;

//     void Start()
//     {
//         objectPool = new ObjectPool<Bullet>(defaultCapacity, maxSize, bullet, parentTransform, collectionCheck, CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
//         timer = Time.time;
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space) && Time.time > timer && objectPool != null)
//         {
//             Bullet bulletObject = objectPool.Get();

//             if (bulletObject == null)
//             {
//                 return;
//             }

//             bulletObject.transform.position = bulletSpawnPoint.position;
//             bulletObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletObject.bulletSpeed;

//             timer = Time.time + shootIntervalInSeconds;
//         }
//     }

//     private Bullet CreateBullet()
//     {
//         Bullet bulletInstance = Instantiate(bullet);
//         bulletInstance.objectPool = objectPool;
//         return bulletInstance;
//     }

//     private void OnGetFromPool(Bullet bulletInstance)
//     {
//         bulletInstance.gameObject.SetActive(true);
//     }

//     private void OnReleaseToPool(Bullet bulletInstance)
//     {
//         bulletInstance.gameObject.SetActive(false);
//     }

//     private void OnDestroyPooledObject(Bullet bulletInstance)
//     {
//         Destroy(bulletInstance.gameObject);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // [Header("Weapon Stats")]
    // [SerializeField] private float shootIntervalInSeconds = 3f;

    // [Header("Bullets")]
    // public Bullet bullet;
    // [SerializeField] private Transform bulletSpawnPoint;

    // [Header("Bullet Pool")]
    // private IObjectPool<Bullet> objectPool;

    // private readonly bool collectionCheck = false;
    // private readonly int defaultCapacity = 30;
    // private readonly int maxSize = 100;
    // private float timer;
    public Transform parentTransform;

    void Start()
    {
        // objectPool = new ObjectPool<Bullet>(defaultCapacity, maxSize, bullet, parentTransform, collectionCheck, CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
        // timer = Time.time;
    }

    void Update()
    {
        // if (Time.time > timer && objectPool != null)
        // {
        //     Bullet bulletObject = objectPool.Get();

        //     if (bulletObject != null)
        //     {
        //         bulletObject.transform.position = bulletSpawnPoint.position;
        //         bulletObject.transform.rotation = bulletSpawnPoint.rotation;
        //         bulletObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletObject.bulletSpeed;
        //         timer = Time.time + shootIntervalInSeconds;
        //     }
        // }
    }

    // private Bullet CreateBullet()
    // {
    //     Bullet bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    //     bulletInstance.objectPool = objectPool;
    //     return bulletInstance;
    // }

    // private void OnGetFromPool(Bullet bulletInstance)
    // {
    //     bulletInstance.gameObject.SetActive(true);
    // }

    // private void OnReleaseToPool(Bullet bulletInstance)
    // {
    //     bulletInstance.gameObject.SetActive(false);
    // }

    // private void OnDestroyPooledObject(Bullet bulletInstance)
    // {
    //     Destroy(bulletInstance.gameObject);
    // }
}