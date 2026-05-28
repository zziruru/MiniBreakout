using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] public GameObject blockPrefab;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 8;
    [SerializeField] private float startY = 3.5f;
    [SerializeField] private float spacingX = 0.2f;
    [SerializeField] private float spacingY = 0.2f;

    void Start()
    {
        gameManager.SetBlockCount(rows * columns);

        // Prefab 상태에서 원하는 값처럼 안 나올 때가 있음
        // 방법 1 > 블록 간격을 실제 충돌 영역 기준으로 맞추고 싶다 -> Collider2D 기준
        // = 실제로 하나 만들어보고 크기를 읽는 방식
        // 언제?
        // Collider 가 Sprite 와 거의 같은 크기로 잘 맞춰져 있는 경우
        // 실제 충돌 영역 기준으로 레벨을 배치하고 싶을 때
        // 블록 사이 충돌/공 반응이 중요한 게임
        // Sprite 의 투명 여백이나 장식부분을 배치 기준에서 제외하고 싶을 때

        // Collider2D blockCollider = blockPrefab.GetComponent<Collider2D>();
        GameObject tempBlock = Instantiate(blockPrefab);
        Collider2D collider = tempBlock.GetComponent<Collider2D>();
        float blockWidth = collider.bounds.size.x;
        float blockHeight = collider.bounds.size.y;
        Destroy(tempBlock);

        // float blockWidth = blockCollider.bounds.size.x;
        // float blockHeight = blockCollider.bounds.size.y;

        // 방법 2 > 블록 간격을 화면에 보이는 이미지 기준으로 맞추고 싶다 -> SpriteRenderer 기준
        // 언제 ? 
        // 눈에 보이는 이미지가 겹치지 않는게 가장 중요함
        // Collider 가 정확히 안 맞춰져 있음
        // 충돌보다 비주얼 정렬인 경우
        // 에셋 배치/타일 배치/장식 오브젝트 배치
        // SpriteRenderer blockRenderer = blockPrefab.GetComponent<SpriteRenderer>();

        float gapX = blockWidth + spacingX;
        float gapY = blockHeight + spacingY;

        // 첫 블록 중심부터 마지막 블록 중심까지의 거리
        float totalWidth = (columns - 1) * gapX;
        float startX = -totalWidth / 2f;

        for(int y = 0; y < rows; y++)
            for(int x = 0; x < columns; x++)
            {
                Vector3 position = new Vector3(startX + x * gapX, startY - y * gapY, 0f);
                GameObject blockObject = Instantiate(blockPrefab, position, Quaternion.identity);

                Block block = blockObject.GetComponent<Block>();
                block.SetGameManager(gameManager);
            }
    }
}
