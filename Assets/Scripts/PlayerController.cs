using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float zInput;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        anim.SetFloat("xVelocity", xInput);
        anim.SetFloat("zVelocity", zInput);
    }
}
