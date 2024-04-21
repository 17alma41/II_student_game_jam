using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField] float speed;
    [SerializeField] float maxGroundHorizontalSpeed;
    [SerializeField] float friction;
    [SerializeField] float initialJumpForce;
    [SerializeField] int onAirJump;
    [SerializeField] CanvasGroup damageCanva;
    int remainingJumps;
    float animationDurationFlash = 0.8f;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        damageCanva.alpha = 0;

        rb = GetComponent<Rigidbody2D>();

        remainingJumps = onAirJump;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementProcess();
        MouseMovementProcess();
        JumpProcess();
    }

    void MovementProcess()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
            movement.x += 1;

        if (Input.GetKey(KeyCode.A))
            movement.x -= 1;

        if (movement != Vector2.zero)
        {
            rb.velocity += movement * speed * Time.deltaTime;
            animator.SetBool("isWalking", true);

        }
        else
        {
            //Fricción en el suelo
            rb.velocity = new Vector2(rb.velocity.x / Mathf.Clamp(friction, 1, Mathf.Infinity), rb.velocity.y);
            animator.SetBool("isWalking", false);
        }


        if (Mathf.Abs(rb.velocity.x) > maxGroundHorizontalSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxGroundHorizontalSpeed, rb.velocity.y);

    }


    void MouseMovementProcess()
    {
        Vector3 mousePos = new Vector3(0, 0, 0);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //Estos cambios solo hace que el personaje mire a ambos lados del eje X (izquierda y derecha).

        //Vector3 targetDir = (mousePos - transform.position).normalized;
        Vector3 targetDir = (new Vector3(mousePos.x, transform.position.y, 0) - transform.position).normalized;

        //float angle = Vector3.SignedAngle(Vector3.up, targetDir, Vector3.forward);
        float angle = Vector3.SignedAngle(Vector3.right, targetDir, Vector3.forward);

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (targetDir.x < 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            remainingJumps = onAirJump;

    }

    void JumpProcess()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, initialJumpForce);

            remainingJumps--;
        }
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float t = animationDurationFlash;

        canvasGroup.alpha = 1;

        while (t > 0)
        {
            canvasGroup.alpha = t;
            t -= Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(FadeOut(damageCanva));
        }

    }
}
