using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveForce = 5f;
    public float spinForce = 10f;
    public float dashForce = 15f;
    public float dashCooldown = 3f;

    private Rigidbody2D rb;
    public float lastDashTime = -999f;



    public float initialLaunchForce = 10f;
    //private bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Ensure no gravity
        LaunchBallFromLeft();
    }

    void LaunchBallFromLeft()
    {
        Vector2 launchDirection = Vector2.right + new Vector2(0, Random.Range(-0.2f, 0.2f)); // Slight angle
        rb.AddForce(launchDirection.normalized * initialLaunchForce, ForceMode2D.Impulse);
        //launched = true;
    }

    void Update()
    {
        MoveTowardsMouse();

        if (Input.GetMouseButtonDown(0))
        {
            SpinBall();
        }

        if (Input.GetMouseButtonDown(1) && Time.time > lastDashTime + dashCooldown)
        {
            Dash();
        }
    }

    void MoveTowardsMouse()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;
        rb.AddForce(direction * moveForce * Time.deltaTime, ForceMode2D.Force);
    }

    void SpinBall()
    {
        rb.AddTorque(spinForce, ForceMode2D.Impulse);
    }

    void Dash()
    {
        Vector2 dashDir = rb.linearVelocity.normalized;
        if (dashDir == Vector2.zero) dashDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.AddForce(dashDir * dashForce, ForceMode2D.Impulse);
        lastDashTime = Time.time;
    }
}
