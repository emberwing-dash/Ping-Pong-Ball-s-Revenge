using UnityEngine;
using UnityEngine.UI;

public class DashCooldownUI : MonoBehaviour
{
    public BallController ball;
    public Text cooldownText;  // Assign a UI Text in the inspector

    void Update()
    {
        float timeRemaining = ball.dashCooldown - (Time.time - ball.lastDashTime);
        timeRemaining = Mathf.Max(0f, timeRemaining);

        cooldownText.text = "Time: " + timeRemaining.ToString("F1"); // One decimal place
    }
}
