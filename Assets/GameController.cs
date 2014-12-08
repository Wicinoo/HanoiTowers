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

		selectedStone.DebugPrint();
	}

	public void SelectStone(StoneControl newSelection)
	{
		if (selectedStone == null)
		{
			selectedStone = newSelection;
			return;
		}

		if (!selectedStone.IsUp)
		{
			selectedStone = newSelection;
		}
	}

	public float GetPolePositionX(int pole)
	{
		return PolePositions[pole].x;
	}

	public float GetPolePositionY(int pole)
	{
		return 0f;
	}
}
