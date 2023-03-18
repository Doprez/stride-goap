using MountainGoap;
using StrideMountainGoap.Code.Goap;

namespace StrideMountainGoap.Code.NPC;
public class NPCAgent : GoapAgent
{
	public override void Update()
	{
		_agent.Step();
	}
}
