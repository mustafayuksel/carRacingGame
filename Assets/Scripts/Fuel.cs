using UnityEngine;

public class Fuel {

	public float maxCapacity;
	public float capacity;
	public int level;
	public float levelMultiplier;
	private int basePrice;
	public int price;


	public Fuel(int _maxCapacity,int _level)
	{
		maxCapacity = _maxCapacity;
		level = _level;
		levelMultiplier = 1.1f;
		basePrice = 10000;
		calculateActualCapacity ();
	}

	private void calculateActualCapacity()
	{
		levelMultiplier = Mathf.Pow (levelMultiplier, level);
		maxCapacity *= levelMultiplier;
		capacity = maxCapacity;
		price = (int)(Mathf.Pow (levelMultiplier, level) * basePrice);

	}
	public float Capacity {
				get {
						if (capacity > maxCapacity)
								return maxCapacity;
						return capacity;
				}
			set {
					if(value > maxCapacity)
						{
				capacity = maxCapacity;
						}
					else if(value <= 0f)
						{
				capacity = 0f;
						}
					else
						{
				capacity = value;
						}
				}
		}
}
