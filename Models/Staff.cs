﻿namespace MirTechTest.Models;

public class Staff
{
	public long Id { get; set; }
	public string Department { get; set; }
	public string FullName { get; set; }
	public DateOnly BirthDay { get; set; }
	public DateOnly DateOfEmployment { get; set; }
	public int Wages { get; set; }
}