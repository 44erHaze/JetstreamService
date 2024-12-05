﻿namespace JetstreamService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public bool IsLocked { get; set; }
    }
}
