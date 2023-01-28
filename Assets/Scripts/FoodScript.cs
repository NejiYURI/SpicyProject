using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FoodScript : MonoBehaviour
{
    public Collider2D ColliderObj;

    private Rigidbody2D rg;

    public SpriteRenderer FoodSprite;
    public SpriteRenderer FoodSprite_2;


    public float PushForce = 20f;


    [SerializeField]
    private bool CanMove;

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

        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameStart.AddListener(GameStart);
        }
    }

    public void FoodSetup(FoodData foodData)
    {
        foreach (var collider in GetComponents<PolygonCollider2D>())
        {
            collider.SetPath(0, foodData.PolygonPointList);
            FoodSprite.sprite = foodData.ImageData;
            FoodSprite_2.sprite = foodData.ImageData;
        }
    }

    void GameStart()
    {
        this.CanMove = true;
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
            if (this.rg != null && this.CanMove)
                this.rg.AddForce(Dir * (PushForce / (Distance * Distance)));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Chopsticks"))
        {
            Vector2 Dir = this.transform.position - collision.transform.position;
            float Distance = Vector2.Distance(this.transform.position, collision.transform.position);
            if (this.rg != null && this.CanMove)
                this.rg.AddForce(Dir * (PushForce / (Distance * Distance)) / 2);
        }
    }

    public void FoodPickUp()
    {
        foreach (var collider in GetComponents<PolygonCollider2D>())
        {
            collider.enabled= false;
        }
        if (this.rg != null)
        {
            this.rg.AddForce(new Vector2(Random.Range(0,2)*2-1, Random.Range(0, 2) * 2 - 1)*500f);
            this.rg.AddTorque(1000);
        }
        Destroy(gameObject,3f);
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
