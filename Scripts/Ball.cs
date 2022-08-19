using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	 public Rigidbody2D rb;
	 public CircleCollider2D col;
	 public int Cost;
	 public int Bounce;
	 public int Type;
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D body;
	public Sprite Type0, Type1, Type2, Type3;
	public Vector3 pos { get { return transform.position; } }


	private void Start()
    {
		body = gameObject.GetComponent<Rigidbody2D>();
		body.mass = Bounce;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

	void Update()
    {
		if(Type == 0)
        {
			ChangeSprite(Type0);
        }
		else if (Type == 1)
		{
			ChangeSprite(Type1);
		}
		else if (Type == 2)
		{
			ChangeSprite(Type2);
		}
		else if (Type == 3)
		{
			ChangeSprite(Type3);
		}
	}
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();
	}

	public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}

	public SpriteRenderer GetSprite()
    {
		return spriteRenderer;
    }
	void ChangeSprite(Sprite newSpo)
    {
		spriteRenderer.sprite = newSpo;
    }
}
