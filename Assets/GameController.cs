using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private StoneControl selectedStone;

	public Vector3[] PolePositions; //where poles are positioned
	public PoleControl[] Poles;
	public StoneControl[] Stones;

	void Start()
	{
		foreach (var stone in Stones)
		{
			Poles[1].AddStone(stone);
		}
	}

	void Update () 
	{
		if (selectedStone == null) return;

		if (Input.GetKeyUp(KeyCode.W)) pickUp();
		if (Input.GetKeyUp(KeyCode.S)) drop();
		if (Input.GetKeyUp(KeyCode.D)) selectedStone.MoveRight();
		if (Input.GetKeyUp(KeyCode.A)) selectedStone.MoveLeft();	

		selectedStone.DebugPrint();
	}

	#region MoveControls

	private void pickUp()
	{
		if (selectedStone.IsUp) return; //stone already up, can't pick it up again

		if (Poles[selectedStone.CurrentPole].RemoveTopStone())
		{
			selectedStone.PickUp();
		}
	}

	private void drop()
	{
		if (!selectedStone.IsUp) return; //stone not picked up, can't drop it

		if (!Poles[selectedStone.CurrentPole].IsPoleEmpty()) //pole not empty, need to check top stone size
		{
			if (selectedStone.Size > Poles[selectedStone.CurrentPole].GetTopStoneSize()) return; //can't drop bigger stone on smaller stone
		}

		if (Poles[selectedStone.CurrentPole].AddStone(selectedStone))
		{
			selectedStone.Drop(Poles[selectedStone.CurrentPole].GetPoleTopPosition());
		}
	}

	#endregion

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
