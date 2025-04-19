using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Collider2D myCollider;
    Camera mainCamera;
    AudioSource audio;
    [SerializeField] LayerMask layers;

    [SerializeField] ParticleSystem particleSystem;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
        audio = GetComponent<AudioSource>();
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
                audio.Play();
                particleSystem.Play();
            }
        }
    }
}
