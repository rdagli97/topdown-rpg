using UnityEngine;

public class Heal : Drop
{
    [SerializeField] private float hpToHeal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerController.healHP(hpToHeal);
        }
    }
}
