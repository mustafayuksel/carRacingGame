#pragma strict
@script AddComponentMenu("Vehicle/CarControl")

public var Wheel_FL : WheelCollider;
public var Wheel_FR : WheelCollider;
public var Wheel_RL : WheelCollider;
public var Wheel_RR : WheelCollider;
public var GearRatio : float[];
public var CurrentGear : int = 0;
public var EngineTorque : float = 600.0;
public var MaxEngineRPM : float = 3000.0;
public var MinEngineRPM : float = 1000.0;
public var SteerAngle : float = 10;
public var COM : Transform;
public var Speed : float;
public var maxSpeed : float = 150;
public var skidAudio : AudioSource;
private var EngineRPM : float = 0.0;
private var motorInput : float;

function Start () {
	GetComponent.<Rigidbody>().centerOfMass = Vector3(COM.localPosition.x * transform.localScale.x, COM.localPosition.y * transform.localScale.y, COM.localPosition.z * transform.localScale.z);
}

function Update () {
	Speed = GetComponent.<Rigidbody>().velocity.magnitude * 3.6f;
	GetComponent.<Rigidbody>().drag = GetComponent.<Rigidbody>().velocity.magnitude / 100;
	EngineRPM = (Wheel_FL.rpm + Wheel_FR.rpm)/2 * GearRatio[CurrentGear];
	
	ShiftGears();
	
	//Input For MotorInput.
	motorInput = Input.GetAxis("Vertical");
	
	//Audio
	GetComponent.<AudioSource>().pitch = Mathf.Abs(EngineRPM / MaxEngineRPM) + 1.0;
	if (GetComponent.<AudioSource>().pitch > 2.0) {
		GetComponent.<AudioSource>().pitch = 2.0;
	}
	
	//Steering
	Wheel_FL.steerAngle = SteerAngle * Input.GetAxis("Horizontal");
	Wheel_FR.steerAngle = SteerAngle * Input.GetAxis("Horizontal");
	
	//Speed Limiter.
	if(Speed > maxSpeed){
		Wheel_FL.motorTorque = 0;
		Wheel_FR.motorTorque = 0;
	}else{
		Wheel_FL.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");
		Wheel_FR.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");
	}
	
	//Input.
	if(motorInput <= 0){
		Wheel_RL.brakeTorque = 30;
		Wheel_RR.brakeTorque = 30;
	}else if (motorInput >= 0){
		Wheel_RL.brakeTorque = 0;
		Wheel_RR.brakeTorque = 0;
	}
	
	//SkidAudio.
	var CorrespondingGroundHit : WheelHit;
	Wheel_RR.GetGroundHit( CorrespondingGroundHit );
	if(Mathf.Abs(CorrespondingGroundHit.sidewaysSlip) > 10) {
		skidAudio.enabled = true;
	}else{
		skidAudio.enabled = false;
	}
	
	//HandBrake
	if(Input.GetButtonDown("Jump")){
		Wheel_FL.brakeTorque = 100;
		Wheel_FR.brakeTorque = 100;
	}
	if(Input.GetButtonUp("Jump")){
		Wheel_FL.brakeTorque = 0;
		Wheel_FR.brakeTorque = 0;
	}
}

function ShiftGears() {
	
	if (EngineRPM >= MaxEngineRPM) {
		var AppropriateGear : int = CurrentGear;
		
		for (var i = 0; i < GearRatio.length; i ++) {
			if(Wheel_FL.rpm * GearRatio[i] < MaxEngineRPM) {
				AppropriateGear = i;
				break;
			}
		}
		CurrentGear = AppropriateGear;
	}
	
	if(EngineRPM <= MinEngineRPM) {
		AppropriateGear = CurrentGear;
		for ( var j = GearRatio.length-1; j >= 0; j -- ) {
			if ( Wheel_FL.rpm * GearRatio[j] > MinEngineRPM ) {
				AppropriateGear = j;
				break;
			}
		}
		CurrentGear = AppropriateGear;
	}
}