using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sRenderer;
    AudioSource audioFire;
    int hp = 3;
    Sprite originalSprite;
    [SerializeField] Sprite destroedSprite;
    [SerializeField] Pawn myPawn;
    [SerializeField] ParticleSystem particleSystemHit;
    [SerializeField] ParticleSystem particleSystemRebuild;
    bool pawnBusy = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        audioFire = GetComponent<AudioSource>();
        originalSprite = sRenderer.sprite;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dynamite"))
        {
            particleSystemHit.Play();
            Destroy(other.gameObject);
            audioFire.Play();
            hp--;
            if (hp <= 0 && !pawnBusy)
            {
                sRenderer.sprite = destroedSprite;
                myPawn.GoBuild(transform.position, this);
                pawnBusy = true;
            }
        }
    }

    public void Rebuid()
    {
        sRenderer.sprite = originalSprite;
        hp = 3;
        particleSystemRebuild.Play();
        pawnBusy = false;
    }
}
