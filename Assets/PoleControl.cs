using UnityEngine;
using System.Collections.Generic;

public class PoleControl : MonoBehaviour 
{
	public int NumberOfSlots;
	public float SlotDistance;

	private List<StoneControl> stones;

	void Start()
	{
		stones = new List<StoneControl>();
	}

	/// <summary>
	/// Gets coordinates for the stone on top of the pole.
	/// </summary>
	/// <returns>The pole top position.</returns>
	public float GetPoleTopPosition()
	{
		return (stones.Count - 1) * SlotDistance;
	}	

	/// <summary>
	/// Adds the stone.
	/// </summary>
	/// <returns><c>true</c>, if stone was added, <c>false</c> otherwise.</returns>
	/// <param name="stone">Stone.</param>
	public bool AddStone(StoneControl stone)
	{
		if (stones.Count >= NumberOfSlots) return false;

		stones.Add(stone);
		return true;
	}

	/// <summary>
	/// Removes the top stone.
	/// </summary>
	/// <returns><c>true</c>, if top stone was removed, <c>false</c> otherwise.</returns>
	public bool RemoveTopStone()
	{
		if (stones.Count > 0)
		{
			return stones.Remove(stones.FindLast(x => x));
		}

		return false;
	}

	/// <summary>
	/// Gets the top stone.
	/// </summary>
	/// <returns>The top stone.</returns>
	private StoneControl GetTopStone()
	{
		return stones.FindLast(x => x);
	}

	public bool IsPoleEmpty()
	{
		if (stones.Count > 0) return false;

		return true;
	}

	/// <summary>
	/// Gets the size of the top stone.
	/// </summary>
	/// <returns>The top stone size.</returns>
	public int GetTopStoneSize()
	{
		return GetTopStone().Size;
	}

	public float GetPositionX()
	{
		return this.transform.position.x;
	}
}
