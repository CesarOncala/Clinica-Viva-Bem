using System;

namespace Web.Models.DataBaseModels
{
    public class ConsultationTableFiltes
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public String Patient {  get; set; }
        public string Doctor { get; set; }
    }
}