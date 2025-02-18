using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    protected Rigidbody2D rb;
    [SerializeField] private SpriteRenderer chRenderer;
    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get { return moveDirection; } }

    protected AnimationHandler animHandler;
    protected StatHandler statHandler;

    private InteractionHandler nearbyInteractable;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    
    protected virtual void FixedUpdate()
    {
        Move(moveDirection);
    }
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Move(Vector2 direction)
    {
        direction = direction * statHandler.Speed;
        rb.velocity = direction;
        animHandler.MoveAnim(direction);
    }

    void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>();
        moveDirection = moveDirection.normalized;

        if (moveDirection.x < 0)
        {
            chRenderer.flipX = true;
        }
        if (moveDirection.x > 0)
        {
            chRenderer.flipX = false;
        }
    }

    void OnInteract()
    {
        if (nearbyInteractable != null)
        {
            nearbyInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            nearbyInteractable = other.GetComponent<InteractionHandler>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (nearbyInteractable != null && nearbyInteractable.gameObject == other.gameObject)
            {
                nearbyInteractable = null;
            }
        }
    }
}
