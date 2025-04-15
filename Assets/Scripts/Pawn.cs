using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sRenderer;
    Tower towerScript;
    Vector3 startPosition;
    Vector3 currentDestination;
    bool inMove;

    [SerializeField] float speed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (inMove)
        {
            if (transform.position.x > currentDestination.x)
            {
                sRenderer.flipX = true;
            }
            else
            {
                sRenderer.flipX = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
            if (transform.position == currentDestination)
            {
                inMove = false;
                if (currentDestination != startPosition)
                {
                    animator.SetTrigger("Build");
                    currentDestination = startPosition;
                }
                else
                {
                    animator.SetTrigger("Idle");
                }
            }
        }
    }

    public void GoBuild(Vector3 coordinates, Tower script)
    {
        currentDestination = coordinates;
        animator.SetTrigger("Go");
        inMove = true;
        towerScript = script;
    }

    void TowerRebuilded()
    {
        inMove = true;
        towerScript.Rebuid();
    }
}
