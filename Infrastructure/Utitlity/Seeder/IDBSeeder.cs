﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techverx.Paysoft.Seeder
{
	public interface IDBSeeder
	{
		Task Seed();
	}
}