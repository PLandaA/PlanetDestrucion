using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour {
    bool moveAllowed;
    Collider2D col;
    AudioSource audioSource;


   public GameObject dieEffect;
    public GameObject moveAnim;


    private GameManager manager;

    void Start () {
        manager = FindFirstObjectByType<GameManager>();
        audioSource = GetComponent<AudioSource>();

        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update () {
        // Unified pointer input: mouse on desktop/WebGL, first touch on Android
        // (Unity simulates mouse events from touches on mobile).
        if (Input.GetMouseButtonDown(0)) {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D touchedCollider = Physics2D.OverlapPoint(pointerPosition);
            if (col == touchedCollider) {
                moveAllowed = true;
                Instantiate(moveAnim, transform.position, Quaternion.identity);
                audioSource.Play();
            }
        }

        if (moveAllowed && Input.GetMouseButton(0)) {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pointerPosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            moveAllowed = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Planets")) {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            manager.GameOver();
			

        }
    }


}
