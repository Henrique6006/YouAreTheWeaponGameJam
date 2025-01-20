using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    private Animator MyAnim;
    
    private bool facingRight = true;
    public float speed=2.0f;
    public float hMove;
    // Start is called before the first frame update
    void Start()
    {
        MyAnim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove= Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb2D.velocity= new Vector2(hMove*speed,rb2D.velocity.y);
        MyAnim.SetFloat("Speed",Mathf.Abs(hMove));
        Flip(hMove);
    }
    void Flip(float hoMove)
    {
        if(hoMove<0 && facingRight||hoMove>0 && !facingRight)
        {
            facingRight=!facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x*=-1;
            transform.localScale=theScale;
        }
    }

}
