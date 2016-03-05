using System.Collections.Generic;

public class LevelManager
{
	public List<Level> allLevels;
	public LevelManager()
	{
		allLevels = new List<Level> ();
		//allLevels.Add(new Level(1,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f));
		allLevels.Add(new Level(1,0.005f,0f,0f,0f,0.01f,0.004f,0.004f,0.008f,0.001f,0.01f));
		allLevels.Add(new Level(2,0.01f,0f,0f,0f,0.01f,0.001f,0.001f,0.008f,0.001f,0.001f));
		//allLevels.Add(new Level(2,0.01f,0f,0f,0f,0.02f,0.004f,0.004f,0.008f,0.002f,0.01f));
		allLevels.Add(new Level(3,0.1f,0f,0f,0f,0.03f,0.004f,0.004f,0.008f,0.0025f,0.01f));
		allLevels.Add(new Level(4,0.020f,0f,0f,0f,0.04f,0.004f,0.004f,0.008f,0.003f,0.01f));
		allLevels.Add (new Level (5, 0.025f,0f,0f,0f, 0.05f, 0.004f, 0.004f, 0.008f,0.0035f,0.01f));
		allLevels.Add(new Level(6,0.031f,0.008f,0f,0f,0.01f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(7,0.032f,0.017f,0f,0f,0.01f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(8,0.034f,0.020f,0f,0f,0.01f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(9,0.010f,0.039f,0f,0f,0.01f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(10,0f,0.040f,0f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(11,0f,0.024f,0.006f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(12,0f,0.015f,0.010f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(13,0f,0.008f,0.012f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(14,0f,0.005f,0.020f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(15,0f,0.005f,0.025f,0f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(16,0f,0f,0.025f,0.005f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(17,0f,0f,0.020f,0.010f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(18,0f,0f,0.015f,0.015f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(19,0f,0f,0.020f,0.010f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
		allLevels.Add(new Level(20,0f,0f,0.005f,0.025f,0.010f,0.004f,0.004f,0.008f,0.01f,0.01f));
	}
}


