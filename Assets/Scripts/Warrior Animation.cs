using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAnimation : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sRenderer;
    Collider2D myCollider;
    Camera mainCamera;

    [SerializeField] LayerMask layers;

    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector2 clickPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Collider2D pressedCollider = Physics2D.OverlapPoint(clickPosition, layers);
            if (pressedCollider == myCollider)
            {
                animator.SetTrigger("Patrol");
            }
        }
    }
}
