using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gameManager;

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameManager.BlockDestroyed();
            Destroy(gameObject);
        }
    }
}
