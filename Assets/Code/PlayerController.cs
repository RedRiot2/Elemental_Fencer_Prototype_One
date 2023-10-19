using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask target1Layer;

    public LayerMask target2Layer;

    Target deleteScript;
    Target2 rushScript;
    GameControl endScript;

    private void Start()
    {
        deleteScript = GameObject.FindGameObjectWithTag("Target1").GetComponent<Target>();
        rushScript = GameObject.FindGameObjectWithTag("Target2").GetComponent<Target2>();
        endScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }

    void Update()
    {

        faceMouse();
        ProcessInputs();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            deleteScript = GameObject.FindGameObjectWithTag("Target1").GetComponent<Target>();
            Attack();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            rushScript = GameObject.FindGameObjectWithTag("Target2").GetComponent<Target2>();
            Rush();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Target3")
        {
            Debug.Log("I was hit");
            endScript.GameEnd();
            //no idea why this doesnt work
        }

    }
    private void FixedUpdate()
    {

        Move();

    }


    void Attack()
    {

        Collider2D[] hitTargets1 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target1Layer);

        foreach(Collider2D target1 in hitTargets1)
        {

            deleteScript.Delete();

        }
    }

    void Rush()
    {

        Collider2D[] hitTargets2 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target2Layer);

        foreach(Collider2D target2 in hitTargets2)
        {

            Target2.currentHitPoints -= 1;
            rushScript.RushDelete();

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void ProcessInputs()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }
    void faceMouse()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;

    }
}
