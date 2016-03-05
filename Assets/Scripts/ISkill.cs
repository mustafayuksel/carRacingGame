using UnityEngine;
using System.Collections;

public abstract class ISkill {


	public string skillName;
    public Texture2D icon;
    public float lifeTime;
    public bool isConsumed;

	public abstract void use(GameObject gameObject,string mark);
	
   
}
