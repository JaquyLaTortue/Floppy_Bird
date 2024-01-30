using UnityEngine;
using UnityEngine.InputSystem;

public class FlapMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    // The force applied to the bird when flapping
    [SerializeField]
    private int _flapForce = 10;

    // The gravity applied to the bird to give the game a more natural feel
    [SerializeField]
    private float _gravity = 2.8f;

    public void StartSetUp()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = _gravity;
            return;
        }
    }

    private void Update()
    {
        if (_rb == null)
        {
            return;
        }

        // Rotate the bird down when falling and up when his flying up
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * 4);
    }

    /// <summary>
    /// Called when the player pressed the flap input
    /// </summary>
    /// <param name="ctx"></param>
    public void Flapping(InputAction.CallbackContext ctx)
    {
        if (_rb == null || !ctx.started)
        {
            return;
        }

        // Reset the velocity of the bird to zero before applying the flap force so the bird doesn't stay at the same height
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _flapForce, ForceMode2D.Impulse);
    }
}
