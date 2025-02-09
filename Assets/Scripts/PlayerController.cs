using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float zInput;

    private Animator anim;

    public float health = 100f;

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

    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    public void healHP(float _hp)
    {
        health += _hp;
    }

    private void DieCheck()
    {
        if (health <= 0)
            Debug.Log("Die");

    }
}
