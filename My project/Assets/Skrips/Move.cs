using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Animator MoveAnim;

    [SerializeField] private bool MoveBool;

    private Vector2? moveToPoint;

    private SpriteRenderer spriteRenderer;

    private float Speed = 5f;

    private void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

	private void Update()
    {
        MoveToPoint();

        Animator("ActionMove", MoveBool);
    }

    public void SetMoveToPoint(Vector2? Point)
    {
        moveToPoint = Point;

        RotateTowardsPoint();
    }

    private void MoveToPoint()
    {
        if (moveToPoint != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position,
                new Vector2(moveToPoint.Value.x, this.transform.position.y), Speed * Time.deltaTime);

            if(transform.position.x == moveToPoint.Value.x)
            {
                MoveBool = false;

                moveToPoint = null;
            }
        }
    }

    private void RotateTowardsPoint()
    {
        if (moveToPoint != null)
        {
            Vector2 movementDirection = moveToPoint.Value - (Vector2)transform.position;

            if (movementDirection.x > 0)
            {
                spriteRenderer.flipX = true;

                MoveBool = true;
            }
            else if (movementDirection.x < 0)
            {
                spriteRenderer.flipX = false;

                MoveBool = true;
            }
        }
    }

    private void Animator(string Name, bool Active)
    {
        if (Active == true)
        {
            MoveAnim.SetBool(Name, Active);
        }
        else
        {
            MoveAnim.SetBool(Name, Active);
        }
    }
}
