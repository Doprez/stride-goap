using Stride.Engine;
using Stride.Engine.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrideMountainGoap.Code;
public class Tree : StartupScript
{
	public int GatherableAmount { get; set; } = 5;

	public override void Start()
	{
		base.Start();
	}

	public bool GatherWood()
	{
		GatherableAmount--;

		if (GatherableAmount > -1)
			return true;
		return false;
	}
}
