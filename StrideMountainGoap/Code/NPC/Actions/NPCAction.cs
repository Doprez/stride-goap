using MountainGoap;
using StrideMountainGoap.Code.Goap;

namespace StrideMountainGoap.Code.NPC;

public class NPCAction : GoapAction
{
	public override ExecutionStatus ActionToRun(Agent agent, Action action)
	{
		return ExecutionStatus.Succeeded;
	}
}
