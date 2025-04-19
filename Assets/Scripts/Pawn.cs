using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sRenderer;
    AudioSource buildSound;
    Tower towerScript;
    Vector3 startPosition;
    Vector3 currentDestination;
    bool inMove;

    [SerializeField] float speed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        buildSound = GetComponent<AudioSource>();
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
                animator.SetTrigger("Stop");
                inMove = false;
                //определяем пришли ли мы к башне или на старт
                if (currentDestination != startPosition)
                {
                    currentDestination = startPosition;
                    buildSound.Play();
                }
            }
        }
    }

    public void GoBuild(Vector3 towerCoordinates, Tower script)
    {
        currentDestination = towerCoordinates;
        animator.SetBool("GoingToBuild", true);//идём к башне
        inMove = true;
        towerScript = script;
    }

    void TowerRebuilded()
    {
        inMove = true;
        towerScript.Rebuid();
        animator.SetBool("GoingToBuild", false);//идём на старт
    }
}
