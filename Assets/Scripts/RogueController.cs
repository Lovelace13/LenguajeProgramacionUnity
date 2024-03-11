using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RogueController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rogueJumpForce = 20f;
    public float rogueSpeed = 4f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D roguerigidbody2;
    private SpriteRenderer mySpriteRenderer;
    private Sprite[] currentSpriteArray;
    public Sprite[] walkRightSprites;
    public Sprite[] walkLeftSprites;

    // Start is called before the first frame update
    void Start()
    {
        roguerigidbody2 = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

        // Movimiento horizontal
        //if (move.x != 0)
        //{
        //    currentSpriteArray = move.x > 0 ? walkRightSprites : walkLeftSprites;
        //    lastHorizontalDirection = move.x > 0 ? "right" : "left";
        //    transform.position += move * moveSpeed * Time.deltaTime;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            roguerigidbody2.velocity = new Vector2(roguerigidbody2.velocity.x, rogueJumpForce);
        }
        roguerigidbody2.velocity = new Vector2(rogueSpeed, roguerigidbody2.velocity.y);
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 4)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }
}
