using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExchangerAspTest.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Operation
    {

        [Key]
        public int id { get; set; }
        [Required]
        public double Amount { get; set; }
        //  public string ToAmount { get; set; }
        public OperationType ToAmount { get; set; }
        public double Convert { get; set; }
        // public string ToCurrency { get; set; }
        public OperationType ToCurrency { get; set; }
        public DateTime date { get; set; }


        //[Display(Name = "First Number")]
        //public double NumberA { get; set; }

        //[Display(Name = "Second Number")]
        //public double NumberB { get; set; }

        //[Display(Name = "Result")]
        //public double Result { get; set; }

        //[Display(Name = "Operation")]


        // public Dictionary<string, double> rates { get; set; }

       

    }


    public enum OperationType
    {
        USD,
        EUR,
        GBP,
        CHF
    }

    /*---------------------------------------------------------*/
    //public class ApplicationDBContext : DbContext
    //{
    //    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    //    {

    //    }

    //    public DbSet<Operation> Rates { get; set; }

    //}

}
