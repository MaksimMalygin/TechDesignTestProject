using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    Collider2D myCollider;
    Camera mainCamera;
    AudioSource fireAudio;
    [SerializeField] LayerMask layers;

    [SerializeField] ParticleSystem fireParticleSystem;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
        fireAudio = GetComponent<AudioSource>();
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
                fireAudio.Play();
                fireParticleSystem.Play();
            }
        }
    }
}
