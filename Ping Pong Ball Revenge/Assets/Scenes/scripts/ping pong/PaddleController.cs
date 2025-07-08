using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isLeftPaddle = true;

    void Update()
    {
        float move = 0f;

        if (isLeftPaddle)
        {
            if (Input.GetKey(KeyCode.W)) move = 1f;
            if (Input.GetKey(KeyCode.S)) move = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) move = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) move = -1f;
        }

        transform.Translate(Vector3.up * move * moveSpeed * Time.deltaTime);
    }
}
