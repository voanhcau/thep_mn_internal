using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RosyModule
{
	public enum StateType
	{
		DISCONNECT,
		NULL_DATA,
		DATA_ERROR,
		STABLE_DATA,
		UN_STABLE_DATA,
		CONNECTED
	}

	public enum StatusInputType
	{
		BANPHIM,
		CANDTTUDONG
	}
}
