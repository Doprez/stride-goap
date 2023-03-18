using Doprez.Stride.StateMachines;
using MountainGoap;
using Stride.Core.Mathematics;
using Stride.Engine;
using StrideMountainGoap.Code.Goap;
using System.Xml.Linq;

namespace StrideMountainGoap.Code.NPC.Actions;
public class GetWoodAction : GoapAction
{

	public Tree TargetTree { get; set; }
	public MoveToAction Move { get; set; }

	private float _elapsedtime = 0;
	private Game _game;

	public override void InitializeGoapAction()
	{
		_game = (Game)Game;
	}

	public override ExecutionStatus ActionToRun(Agent agent, Action action)
	{
		if (Vector3.Distance(Entity.WorldPosition(), TargetTree.Entity.WorldPosition()) > 0.5)
		{
			agent.State["IsCloseToTarget"] = false;
			Move.Target = TargetTree.Entity;
			return ExecutionStatus.Failed;
		}

		return GetWood();
	}

	private ExecutionStatus GetWood()
	{
		_elapsedtime += (float)_game.UpdateTime.Elapsed.TotalSeconds;

		if (_elapsedtime >= 1)
		{
			//check if wood was able to be gathered
			if (TargetTree.GatherWood())
			{
				_elapsedtime = 0;
				return ExecutionStatus.Executing;
			}
			return ExecutionStatus.Succeeded;
		}
		return ExecutionStatus.Executing;
	}

}
