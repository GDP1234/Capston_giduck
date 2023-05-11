using UnityEngine;

public class playermove : MonoBehaviour
{
    public float Speed;

    float h;
    float v;
    bool isHorizonMove;

    Rigidbody2D rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h){
            anim.SetInteger("hAxisRaw", (int)h);
            anim.SetTrigger("isChage");
        }
        else if (anim.GetInteger("vAxisRaw") != v){
            anim.SetInteger("vAxisRaw", (int)v);
            anim.SetTrigger("isChage");
        }
        else
            anim.SetTrigger("isChage");


    }

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec*Speed;


    }
        
}
