using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float minX;
    private float maxX;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        CapsuleCollider2D paddleCollider = GetComponent<CapsuleCollider2D>();

        // orthographicSize 는 화면 세로 절반
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float leftEdge = mainCamera.transform.position.x - cameraWidth / 2f;
        float rightEdge = mainCamera.transform.position.x + cameraWidth / 2f;

        float halfPaddleWidth = paddleCollider.bounds.size.x / 2f;

        minX = leftEdge + halfPaddleWidth;
        maxX = rightEdge - halfPaddleWidth;
    }

    private void Update()
    {
        float move = 0f;

        if (Keyboard.current.leftArrowKey.isPressed)
            move = -1f;

        if (Keyboard.current.rightArrowKey.isPressed)
            move = 1f;

        Vector3 nextPosition = transform.position + new Vector3(move, 0f, 0f) * speed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        transform.position = nextPosition;
    }
}
