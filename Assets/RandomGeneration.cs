using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGeneration : MonoBehaviour {

	public GameObject blockPrefab;
	public int demensions;	
	public int percentSolid;

	public int numberOfSmoothingGenerations;
	public int neighborThreshold;

	private int[,] blocks;

	void Start () 
	{
		blocks = new int[demensions, demensions];
		RandomSpawnBlocks();
		RunSmoothing(numberOfSmoothingGenerations);
		GenerateBlock(blocks);
	}

	void Update()
	{

	}

	public void RandomSpawnBlocks()
	{
		for(int i = 0; i <= blocks.GetUpperBound(0); i++)
		{
			for(int j = 0; j <= blocks.GetUpperBound(1); j++)
			{
				// seed random blocks based on percentage
				blocks[i,j] = RandomInt(percentSolid);
			}
		}
	}
	
	public void GenerateBlock(int[,] blocks)
	{
		for(int i = 0; i <= blocks.GetUpperBound(0); i++)
		{
			for(int j = 0; j <= blocks.GetUpperBound(1); j++)
			{
				if(blocks[i,j] == 1)
					Instantiate(blockPrefab, new Vector3(i,0.5f,j), transform.rotation);
			}
		}

	}

	private int RandomInt(int percent)
	{
		if(Random.Range(0,100) >= percent) 
			return 0;
		else if(Random.Range(0,100) < percent)
			return 1;
		else
			return 0;
	}

//	private int CheckNeighbors()
//	{
//		int left;
//		int right;
//		int below;
//		int above;
//
//		for(int i = 0; i < blocks.GetUpperBound(0); i++)
//		{
//			for(int j = 0; j < blocks.GetUpperBound(1); j++)
//			{
//				left = blocks[i-1,j];
//				right = blocks[i+1,j]
//				below = blocks[i,j+1];
//				above = blocks[i,j-1];
//			}
//		}
//	}

	private int CheckNeighbors(int row, int col)
	{
		int total = 0;
		
		int topLimit, bottomLimit, rightLimit, leftLimit;
		
		if(row - 1 >= 0)
		{
			leftLimit = row - 1;
		}
		else
		{
			leftLimit = 0;
		}
		
		if(row + 1 <= blocks.GetUpperBound(0))
		{
			rightLimit = row + 1;
		}
		else
		{
			rightLimit = blocks.GetUpperBound(0);
		}
		
		if(col - 1 >= 0)
		{
			bottomLimit = col - 1;
		}
		else
		{
			bottomLimit = 0;
		}
		
		if(col + 1 <= blocks.GetUpperBound(1))
		{
			topLimit =col + 1;
		}
		else
		{
			topLimit = blocks.GetUpperBound(1);
		}
		
		//print("righjt limit = " + rightLimit);
		
		for(int i = leftLimit; i <= rightLimit; i++)
		{
			for(int j = bottomLimit; j <= topLimit; j++)
			{
				if(blocks[i,j] == 1)
				{
					total++;
				}
			}
		}
		
		return total;
	}

	public void RunSmoothing(int numSmooths)
	{
		int neighborAmountThreshold = neighborThreshold;

		for(int run = 0; run < numSmooths; run++)
		{
			for(int i = 0; i < blocks.GetUpperBound(0); i++)
			{
				for(int j = 0; j < blocks.GetUpperBound(1); j++)
				{
					if(CheckNeighbors(i,j) < neighborAmountThreshold)
					{

						blocks[i,j] = 0;
					}
					else
					{
						blocks[i,j] = 1;
					}
				}
			}
		}
	}


}
