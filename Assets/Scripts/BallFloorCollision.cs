using UnityEngine;

public class BallFloorCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("Ball hit the floor!");
            lifeManager.LoseLife();
        }
    }
}
