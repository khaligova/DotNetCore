using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Task:BaseEntity
    {
        public string Title { get; set; }
        public string Request { get; set; }
        public int CreatedUserId { get; set; }
        public int AssignedUserId { get; set; }
        public int StatusId { get; set; }
    }
}
