using UnityEngine;

public class Drop : MonoBehaviour
{
    public float scaleAmount = .2f;
    public float speed = 2f;
    private Vector3 originalScale;
    protected PlayerController playerController;

    private void Start()
    {
        originalScale = transform.localScale;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update()
    {
        float scaleFactor = Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = originalScale + Vector3.one * scaleFactor;
    }
}
