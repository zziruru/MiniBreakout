using UnityEngine;

public class PaddleBounce : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            float paddleX = transform.position.x;
            float ballX = collision.transform.position.x;

            // Asset Sprite 적용시 scale 을 1로 바꾸게되면서 localScale.x 가 화면폭을 정확히 의미하지 않을 수 있게됨
            // float paddleWidth = transform.localScale.x;
            CapsuleCollider2D paddleCollider = GetComponent<CapsuleCollider2D>();
            float paddleWidth = paddleCollider.bounds.size.x;

            // hitValue 를 -1 ~ 1 사이의 값으로 만들기 위해 paddleWidth / 2 값으로 나눠줌
            float hitValue = (ballX - paddleX) / (paddleWidth / 2f);
            BallController ball = collision.gameObject.GetComponent<BallController>();
            ball.BounceFromPaddle(hitValue);
        }
    }
}
