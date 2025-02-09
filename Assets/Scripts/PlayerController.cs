using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float zInput;

    private Animator anim;

    public float health = 100f;
    public int score = 0;

    private CharacterController characterController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        anim.SetFloat("xVelocity", xInput);
        anim.SetFloat("zVelocity", zInput);

        DieCheck();
        
    }
    private void DieCheck()
    {
        if (health <= 0)
            Debug.Log("Die");
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    public void healHP(float _hp)
    {
        health += _hp;
    }


    public void IncreaseScore(int _scoreToAdd)
    {
        score += _scoreToAdd;
    }
}
