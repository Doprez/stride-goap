﻿using MountainGoap;
using Stride.Engine;
using Stride.Core;
using System.Collections.Generic;

namespace StrideMountainGoap.Code.Goap;

public abstract class GoapAction : StartupScript
{
	[DataMember(0)]
	public virtual string NameOfAction { get; set; } = "";
	[DataMember(1)]
	public int Cost { get; set; } = 1;

	[DataMember(10)]
	public virtual Dictionary<string, bool> Preconditions { get; set; } = new Dictionary<string, bool>();
	[DataMember(11)]
	public virtual Dictionary<string, bool> Postconditions { get; set; } = new Dictionary<string, bool>();

	protected MountainGoap.Action _action;

	public override void Start()
	{
		InitializeGoapAction();

		//This should be the last thing in the start method
		InitializeAction();
	}

	public virtual void InitializeGoapAction()
	{

	}

	public Action GetAction() { return _action; }

	/// <summary>
	/// the executor entry for the GOAP action
	/// </summary>
	/// <param name="agent"></param>
	/// <param name="action"></param>
	/// <returns></returns>
	public abstract ExecutionStatus ActionToRun(Agent agent, Action action);

	private Dictionary<string, object> GetPreConditions()
	{
		var preConditions = new Dictionary<string, object>();
		foreach(var condition in Preconditions)
		{
			preConditions.Add(condition.Key, condition.Value);
		}
		return preConditions;
	}

	private Dictionary<string, object> GetPostConditions()
	{
		var postConditions = new Dictionary<string, object>();
		foreach (var condition in Postconditions)
		{
			postConditions.Add(condition.Key, condition.Value);
		}
		return postConditions;
	}

	protected virtual void InitializeAction()
	{
		_action = new
		(
			name: NameOfAction,
			preconditions: GetPreConditions(),
			postconditions: GetPostConditions(),
			executor: ActionToRun,
			cost: Cost
		);
	}

}
