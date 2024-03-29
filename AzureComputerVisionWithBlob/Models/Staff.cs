﻿using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class Staff
    {
        public Staff()
        {
            NotificationAdminStaff = new HashSet<Notification>();
            NotificationStaff = new HashSet<Notification>();
            Opening = new HashSet<Opening>();
            StaffAttribute = new HashSet<StaffAttribute>();
            StaffPhoto = new HashSet<StaffPhoto>();
        }

        public int StaffId { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string TimeZone { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip { get; set; }

        public ICollection<Notification> NotificationAdminStaff { get; set; }
        public ICollection<Notification> NotificationStaff { get; set; }
        public ICollection<Opening> Opening { get; set; }
        public ICollection<StaffAttribute> StaffAttribute { get; set; }
        public ICollection<StaffPhoto> StaffPhoto { get; set; }
    }
}
