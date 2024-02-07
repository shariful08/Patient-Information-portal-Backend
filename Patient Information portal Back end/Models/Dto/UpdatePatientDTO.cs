﻿using System.ComponentModel.DataAnnotations;

namespace Patient_Information_portal_Back_end.Models.Dto
{
    public class UpdatePatientDTO
    {
        public int PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }
        [Required]
        public int DiseasesName { get; set; }
        [Required]
        public string Epilepsy { get; set; }
        public int? NCD { get; set; }
        [Required]
        public int Allergies { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
