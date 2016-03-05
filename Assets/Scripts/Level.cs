

public class Level{

	public int _levelNumber;
	public float _truckDensity;
	public float _shieldTruckDensity;
	public float _bomberDensity;
	public float _tankDensity;
	public float _truckTntDensity;
	public float _speederDensity;
	public float _rampDensity;
	public float _boxDensity;
	public float _trapDensity;
	public float _oilDensity;
	public Level(int level,float truckd,float shieldtd,float bomber,float tank,
	             float trucktntd,float speedd,float rampden,float boxden,float trap,float oil)
	{
		_levelNumber = level;
		_truckDensity =  truckd;
		_shieldTruckDensity = shieldtd;
		_bomberDensity = bomber;
		_tankDensity = tank;
		_truckTntDensity = trucktntd;
		_speederDensity = speedd;
		_rampDensity = rampden;
		_boxDensity = boxden;
		_trapDensity = trap;
		_oilDensity = oil;
	}
}
