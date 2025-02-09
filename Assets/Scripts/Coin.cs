using UnityEngine;

public class Coin : Drop
{
    [SerializeField] private int addToScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerController.IncreaseScore(addToScore);
        }
    }
}
