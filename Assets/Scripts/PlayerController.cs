using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private float xInput;
    private float zInput;

    private Animator anim;

    public float health = 100f;
    public int score = 0;
    public Image hpBar;

    private CharacterController characterController;

    public bool shouldHeal;

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

    private void LateUpdate()
    {
        canvas.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void DieCheck()
    {
        if (health <= 0)
            Debug.Log("Die");
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        hpBar.fillAmount = health / 100;
    }

    public void healHP(float _hp)
    {
        if (shouldHeal)
            health += _hp;
    }


    public void IncreaseScore(int _scoreToAdd)
    {
        score += _scoreToAdd;
    }

    private void ShouldHeal()
    {
        if (health >= 100)
            shouldHeal = true;
    }
}
