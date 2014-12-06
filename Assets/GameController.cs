using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private StoneControl selectedStone;

	public Vector3[] PolePositions;


	void Start()
	{

	}

	void Update () 
	{
		if (selectedStone == null) return;

		if (Input.GetKeyUp(KeyCode.W)) selectedStone.PickUp();
		if (Input.GetKeyUp(KeyCode.S)) selectedStone.Drop();
		if (Input.GetKeyUp(KeyCode.D)) selectedStone.MoveRight();
		if (Input.GetKeyUp(KeyCode.A)) selectedStone.MoveLeft();	
	}

	public void SelectStone(StoneControl newSelection)
	{
		selectedStone = newSelection;
	}

	public float GetPolePositionX(int pole)
	{
		return PolePositions[pole].x;
	}
}
