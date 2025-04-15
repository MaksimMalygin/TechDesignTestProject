using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sRenderer;
    int hp = 3;
    Sprite originalSprite;
    [SerializeField] Sprite destroedSprite;
    [SerializeField] Pawn myPawn;
    [SerializeField] ParticleSystem pSystemHit;
    [SerializeField] ParticleSystem pSystemRebuild;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        originalSprite = sRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print($"triggered with {other.gameObject}");
        if (other.gameObject.CompareTag("Dynamite"))
        {
            pSystemHit.Play();
            Destroy(other.gameObject);
            hp--;
            if (hp <= 0)
            {
                sRenderer.sprite = destroedSprite;
                myPawn.GoBuild(transform.position, this);
            }
        }
    }

    public void Rebuid()
    {
        sRenderer.sprite = originalSprite;
        hp = 3;
        pSystemRebuild.Play();
    }
}
