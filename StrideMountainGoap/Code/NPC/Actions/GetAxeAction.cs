using MountainGoap;
using Stride.Core.Mathematics;
using Stride.Engine;
using StrideMountainGoap.Code.Goap;
using Action = MountainGoap.Action;

namespace StrideMountainGoap.Code.NPC.Actions;
public class GetAxeAction : GoapAction
{

	public Entity AxeLocation { get; set; }
	public MoveToAction Move { get; set; }

	public override ExecutionStatus ActionToRun(Agent agent, Action action)
	{
		if(Vector3.Distance(Entity.WorldPosition(), AxeLocation.WorldPosition()) > 0.5)
		{
			agent.State["IsCloseToTarget"] = false;
			Move.Target = AxeLocation;
			return ExecutionStatus.Failed;
		}

		return ExecutionStatus.Succeeded;
	}
}
