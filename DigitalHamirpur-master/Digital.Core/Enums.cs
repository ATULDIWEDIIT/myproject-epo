using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Digital.Core
{
    public enum AuthenticationType
    {
        Authenticated = 1,
        Anonymous = 2
    }

    public enum EmailFormat
    {
        [Display(Name = "SMTP (This sends email directly and requires the information below)")]
        SMTP = 1,

        [Display(Name = "MAPI (This sends email through your existing email program)")]
        MAPI1 = 2,

        [Display(Name = "MAPI (Create but don't send)")]
        MAPI2 = 3
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
    }

    public enum ObjectState
    {
        Added,
        Modified,
        Deleted
    }

    public enum UserRoles
    {
        SuperAdmin = 9, // data access not allowed or data accessible
        Admin = 1, // data access not allowed or data accessible
        User = 2,
        
    }

    public enum MessageType
    {
        Info,
        Warning,
        Danger,
        Success
    }

    public enum ModalSize
    {
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public enum CredentialsRequest
    {
        UserId = 1,
        UserPassword = 2
    }







    

    public enum AddressTypes
    {
        Primary = 0,
        Alternative = 1,
        // Other = 2
    }

    public enum PersonTypes
    {
        Family = 0,
        Individual = 1
    }

    public enum Marital
    {
        Unknown = 0,
        Married = 1,
        Single = 2,
        Divorced = 3,
        Partnership = 4,
        Separated = 5,
        Widow = 6,
        Widower = 7,
    }

    


    public enum WeekDay
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum MonthWeek
    {
        [Display(Name = "First")]
        First = 1,
        [Display(Name = "Second")]
        Second = 2,
        [Display(Name = "Third")]
        Third = 3,
        [Display(Name = "Fourth")]
        Fourth = 4,
        [Display(Name = "Last")]
        Last = 5
    }

    public enum Month
    {
        [Display(Name = "January")]
        January = 1, //January - 31 days   
        [Display(Name = "February")]
        February = 2, //February - 28 days in a common year and 29 days in leap years
        [Display(Name = "March")]
        March = 3, // March - 31 days 
        [Display(Name = "April")]
        April = 4, //April - 30 days       
        [Display(Name = "May")]
        May = 5, // May - 31 days
        [Display(Name = "June")]
        June = 6, //June - 30 days       
        [Display(Name = "July")]
        July = 7, //July - 31 days   
        [Display(Name = "August")]
        August = 8, //August - 31 days   
        [Display(Name = "September")]
        September = 9, //September - 30 days    
        [Display(Name = "October")]
        October = 10, //October - 31 days 
        [Display(Name = "November")]
        November = 11, //November - 30 days   
        [Display(Name = "December")]
        December = 12 // December - 31 days
    }

    

  
    public enum EmailSendBy
    {
        SMTP = 0,
        MAPI = 1
    }

   

    public enum ExportType
    {
        PDF = 1,
        Excel = 2,
        CSV = 3,
        Word = 4
    }

    public enum ImportType
    {
        [Display(Name = "Overwrite Data")]
        OverWrite,
        [Display(Name = "Append Data")]
        Append,
        [Display(Name = "Link Data")]
        Link
    }

    

    

  }
