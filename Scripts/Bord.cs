using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bord : MonoBehaviour
{

    public float upForce = 200f;

    public int guhs = 5;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    private PolygonCollider2D polyCol;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        polyCol = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if(Input.GetButtonDown("Flop"))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2 (0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            guhs --;
            if (guhs <= 0)
            {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Death");
            GameControl.instance.BordDied ();
            }
            else
            {
                polyCol.enabled = false;
                sprite.color = new Color(1, 1, 0, .5f);
                StartCoroutine(EnableBox(1.0F));
            }
        }
        else 
        {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Death");
            GameControl.instance.BordDied ();
        }
       
    }
    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        polyCol.enabled = true;
        sprite.color = new Color(1, 1, 1, 1);
    }
}
