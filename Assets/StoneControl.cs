using UnityEngine;
using System.Collections;

public class StoneControl : MonoBehaviour 
{
	public int Size;

	private GameController gc;
	
	private bool isMoving = false;
	private bool isUp = false;
	private int currentPole=1;

	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		if (gc == null) throw new MissingComponentException("Game Controller not found!");
	}

	void OnMouseOver()
	{
		if (Input.GetKeyUp(KeyCode.Mouse0)) 
		{
			gc.SelectStone(this);
			Debug.Log(this.transform.name);
		}
	}


	public void PickUp()
	{
		isUp = true;
	}

	public void Drop()
	{
		isUp = false;
	}

	public void MoveLeft()
	{
		if (currentPole <= 0) return;
		currentPole--;
		UpdatePosition();
	}

	public void MoveRight()
	{
		if (currentPole >= 2) return;
		currentPole++;
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		this.transform.Translate(gc.GetPolePositionX(currentPole),0,0);
	}
}
