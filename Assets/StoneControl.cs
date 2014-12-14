using UnityEngine;
using System.Collections;

public class StoneControl : MonoBehaviour 
{
	public int Size;
	public bool IsUp {get{return isUp;}}
	public int CurrentPole {get{return currentPole;}}

	private GameController gc;
	private float speed = 0.2f;
	private bool isUp = false;
	private bool isMovingVertically = false;
	private int currentPole=1;
	private float targetX;
	private float targetY;
	private float upY = 2f;

	void Start()
	{
		targetY = this.transform.position.y;

		gc = GameObject.Find("GameController").GetComponent<GameController>();
		if (gc == null) throw new MissingComponentException("Game Controller not found!");
	}

	void OnMouseOver()
	{
		if (Input.GetKeyUp(KeyCode.Mouse0)) 
		{
			gc.SelectStone(this);
		}
	}

	void Update()
	{
		UpdatePosition();
	}


	public void PickUp()
	{
		isUp = true;
		isMovingVertically = true;
		targetY = upY;
	}

	public void Drop(float toHeight)
	{
		isUp = false;
		isMovingVertically = true;
		//targetY = gc.GetPolePositionY(currentPole);
		targetY = toHeight;
	}

	public void MoveLeft()
	{
		if (currentPole <= 0 || !isUp || isMovingVertically) return;
		currentPole--;
		targetX = gc.GetPolePositionX(currentPole);
	}

	public void MoveRight()
	{
		if (currentPole >= 2 || !isUp || isMovingVertically) return;
		currentPole++;
		targetX = gc.GetPolePositionX(currentPole);		
	}

	private void UpdatePosition()
	{
		if (targetY != this.transform.position.y) //we need to move the stone up or down
		{			
			if (Mathf.Abs(targetY - this.transform.position.y) < speed) 
			{
				this.transform.Translate(0,targetY - this.transform.position.y,0);
				isMovingVertically = false;
				return;
			}
			this.transform.Translate(GetVerticalDirection(targetY)*speed);
		}

		if (targetX != this.transform.position.x) //we need to move the stone sideways
		{
			if (Mathf.Abs(targetX - this.transform.position.x) < speed) 
			{
				this.transform.Translate(targetX - this.transform.position.x,0,0);
				return;
			}
			this.transform.Translate(GetHorizontalDirection(targetX)*speed);
		}
	}

	private Vector3 GetHorizontalDirection(float targetX)
	{
		if (targetX > this.transform.position.x) return Vector3.right;
		if (targetX < this.transform.position.x) return Vector3.left;
		return Vector3.zero;
	}

	private Vector3 GetVerticalDirection(float targetY)
	{
		if (targetY > this.transform.position.y) return Vector3.up;
		if (targetY < this.transform.position.y) return Vector3.down;
		return Vector3.zero;
	}
}
