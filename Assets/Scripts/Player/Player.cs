using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;
    public static Player Instance { get; private set; }
    private float padding = 1f; // Adjust this for edge padding

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
        ClampToScreen();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    private void ClampToScreen()
    {
        // Access the main camera using GameObject.FindWithTag
        Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        if (mainCamera != null)
        {
            Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
            viewPos.x = Mathf.Clamp(viewPos.x, padding / 100f, 1 - padding / 100f);
            viewPos.y = Mathf.Clamp(viewPos.y, (padding - 0.5f) / 100f, 0.95f - padding / 100f);
            transform.position = mainCamera.ViewportToWorldPoint(viewPos);
        }
        else
        {
            Debug.LogWarning("No main camera found in the scene.");
        }
    }
}