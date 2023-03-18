using MountainGoap;
using Navigation;
using Stride.Engine;
using StrideMountainGoap.Code.Goap;

namespace StrideMountainGoap.Code.NPC;
public class MoveToAction : GoapAction
{

	public AsyncPathfinder PathFinder;
	public Entity Target;
	public float DistanceToREachTarget = 0.5f;

	public override ExecutionStatus ActionToRun(Agent agent, Action action)
	{

		if (!PathFinder.HasPath)
		{
			
			PathFinder.SetWaypoint(Target.Transform.Position);
			//make another check if the NPC has a path and retry later if it doesnt
			if (!PathFinder.HasPath)
			{
				return ExecutionStatus.Executing;
			}
		}

		if(PathFinder.CurrentPathDistance > DistanceToREachTarget)
		{
			return ExecutionStatus.Executing;
		}

		// Reset stops the NPC from moving and sets HasPath to false
		PathFinder.Reset();
		return ExecutionStatus.Succeeded;
	}
}
