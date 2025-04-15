using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimation : MonoBehaviour
{
    Animator animator;
    Collider2D myCollider;
    Camera mainCamera;
    [SerializeField] LayerMask layers;

    [SerializeField] GameObject dynamite;

    void Start()
    {
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector2 clickPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Collider2D pressedCollider = Physics2D.OverlapPoint(clickPosition, layers);
            if (pressedCollider == myCollider)
            {
                animator.SetTrigger("Throw");
                Instantiate(dynamite,transform.position, transform.rotation);
            }
        }
    }
}
