﻿namespace UwaziTech.Core.Models.request
{
    public class UserDetails
    {
        public int Id { get; set; } // Primary key
        public string? Username { get; set; }
        public string? BranchName { get; set; }
        public string? Password { get; set; }
    }
}