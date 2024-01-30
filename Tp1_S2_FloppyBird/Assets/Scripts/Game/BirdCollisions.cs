using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdCollisions : MonoBehaviour
{
    public event Action ScoreUp;

    public bool Alive { get; private set; }

    [SerializeField]
    private EndDisplayUi _endDisplayUi;

    public void StartSetUp()
    {
        Alive = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") && Alive)
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FreeZone"))
        {
            ScoreUp?.Invoke();
        }
    }

    /// <summary>
    /// Cancel the gravity of the bird when he takes damage so he's freezed where he is
    /// </summary>
    private void TakeDamage()
    {
        Alive = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;

        GetComponent<PlayerInput>().enabled = false;
        _endDisplayUi.DisplayEndScreen();
    }
}
