using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public Collider2D ColliderObj;

    private Rigidbody2D rg;

    public SpriteRenderer FoodSprite;

    public float PushForce = 20f;

    private void Start()
    {
        this.rg = GetComponent<Rigidbody2D>();
        if (MainGameController.mainController != null)
        {
            foreach (var item in MainGameController.mainController.PlayerColliderList)
            {
                Physics2D.IgnoreCollision(ColliderObj, item);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Chili"))
        {
            FoodSprite.color = new Color(FoodSprite.color.r, FoodSprite.color.g, FoodSprite.color.b, 0.5f);
        }
        if (collision.transform.tag.Equals("Chopsticks"))
        {
            Vector2 Dir = this.transform.position - collision.transform.position;
            float Distance = Vector2.Distance(this.transform.position, collision.transform.position);
            if (this.rg != null)
                this.rg.AddForce(Dir * (PushForce / (Distance * Distance)));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Chopsticks"))
        {
            Vector2 Dir = this.transform.position - collision.transform.position;
            float Distance = Vector2.Distance(this.transform.position, collision.transform.position);
            if (this.rg != null)
                this.rg.AddForce(Dir * (PushForce / (Distance * Distance)) / 2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Chili"))
        {
            FoodSprite.color = new Color(FoodSprite.color.r, FoodSprite.color.g, FoodSprite.color.b, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
