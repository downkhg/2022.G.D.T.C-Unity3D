using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody;
    public float JumpPower = 100;
    public bool isJump = false;

    public void ProcessControl()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * JumpPower);
            isJump = true;
        }
    }
    public void ProcessAnimation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("SetStatus", 1);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
            animator.SetInteger("SetStatus", 0);

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("SetStatus", 1);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
            animator.SetInteger("SetStatus", 0) ;

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetBool("JumpUp", true);

        if (Input.GetKeyDown(KeyCode.S))
            animator.SetInteger("SetStatus", 2);
        if (Input.GetKeyUp(KeyCode.S))
            animator.SetInteger("SetStatus", 0);


        if (isJump)
        {
            if (rigidbody.velocity.y < 0)
                animator.SetBool("JumpDown", true);

            Vector2 vStart = this.transform.position;
            Vector2 vEnd = vStart + rigidbody.velocity;
            Debug.DrawLine(vStart, vEnd);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D:" + collision.gameObject.name);
        animator.SetInteger("SetStatus", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessControl();
        ProcessAnimation();
    }
    private void OnGUI()
    {
        AnimatorClipInfo[] aniClipinfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorStateInfo aniStatusInfo = animator.GetCurrentAnimatorStateInfo(0);

        string log = string.Format("{0}:{1}", aniClipinfo[0].clip.name, aniStatusInfo.normalizedTime);
        GUI.Box(new Rect(0, 0, 500, 20), log);
    }
}
