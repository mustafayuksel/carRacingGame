using UnityEngine;

public class Engine{

	private float topSpeedMultiplier;
	private float accelerationMultiplier;
	private int basePrice;
	public float acc;
	public float topSpeed;
	public int _level;
	public int price;
	private int maxLevel;

	public Engine(int level)
	{
		maxLevel = 5;
		if (level > maxLevel) {
			level = maxLevel;
				}
		this._level = level;
		topSpeedMultiplier = 1.1f;
		accelerationMultiplier = 1.1f;
		basePrice = 10000;
		calculate ();
		}

	public void calculate()
	{
		topSpeed = Mathf.Pow (topSpeedMultiplier, _level);
		acc = Mathf.Pow (accelerationMultiplier, _level);
		price = (int)(basePrice * Mathf.Pow (topSpeedMultiplier, _level));
		}
}
