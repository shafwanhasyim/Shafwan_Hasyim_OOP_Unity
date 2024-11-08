using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Vector2 newPosition;
    private Animator animator;

    void Start()
    {
        ChangePosition();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }

        GameObject player = GameObject.Find("Player");
        bool hasWeapon = player != null && player.GetComponentInChildren<Weapon>() != null;
        GetComponent<Collider2D>().enabled = hasWeapon;
        GetComponent<SpriteRenderer>().enabled = hasWeapon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in GameManager.Instance.transform)
            {
                if (child.GetComponent<Canvas>() != null || child.GetComponent<UnityEngine.UI.Image>() != null)
                {
                    child.gameObject.SetActive(true);
                }
            }
            GameManager.Instance.LevelManager.LoadScene("Main");
        }
    }

    void ChangePosition()
    {
        newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }
}