using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    // [SerializeField] private float minSpeed = 1.5f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(3f, 4f).normalized * speed;
    }

    // BounceFromPaddle 에서 사용자가 패들을 조정함에 따라 공의 방향을 조정할 수 있으므로
    // 굳이 보정이 필요 없어서 주석처리
    // private void FixedUpdate()
    // {
    //     // 공이 너무 수직/수평 이동하지 않게 보정
    //     // 무한 반복하게 될 수 있음
    //     Vector2 velocity = rb.linearVelocity;
    //     if(Mathf.Abs(velocity.x) < minSpeed)
    //         if(velocity.x < 0)
    //             velocity.x = -minSpeed;
    //         else
    //             velocity.x = minSpeed;

    //     if(Mathf.Abs(velocity.y) < minSpeed)
    //         if(velocity.y < 0)
    //             velocity.y = -minSpeed;
    //         else
    //             velocity.y = minSpeed;

    //     // 공의 속도를 유지하는 코드
    //     rb.linearVelocity = rb.linearVelocity.normalized * speed;
    //     // 벽돌깨기 공은 충돌하면서 속도가 조금 이상해질 수 있음
    //     // - 마찰때문에 느려지거나
    //     // - 충돌 각도 때문에 거의 수평으로 감
    //     // - 물리 계산 때문에 속도 크기가 살짝 변함
    // }

    // hitValue : 어디에 맞았는지 나타내는 값
    // paddle 왼쪽 = -1, paddle 중앙 = 0, paddle 오른쪽 = 1
    public void BounceFromPaddle(float hitValue)
    {
        Vector2 direction = new Vector2(hitValue, 1f).normalized; // y 값은 항상 1f 니까 공은 위로 감
        rb.linearVelocity = direction * speed;
    }
}
