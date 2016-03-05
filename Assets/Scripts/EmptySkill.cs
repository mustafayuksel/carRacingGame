using UnityEngine;

public class EmptySkill : ISkill {

	public EmptySkill()
	{
		this.skillName = "Empty";
	}
	public override void use(GameObject go,string tag)
	{

	}
}
