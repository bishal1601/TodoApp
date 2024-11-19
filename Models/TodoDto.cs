﻿namespace TodoApplication.Models;

public class TodoDto
{
    public Guid Id { get; set; }
    public DateTime TaskDate { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public bool Status { get; set; }
}