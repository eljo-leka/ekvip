using System.ComponentModel.DataAnnotations;

namespace ekvip.Enums;

public enum CommandTypeEnum
{
    [Display(Name = "Unknown")]
    Unknown = 0,
    
    [Display(Name = "Increment")]
    Increment = 1,
    
    [Display(Name = "Decrement")]
    Decrement = 2,
    
    [Display(Name = "Double")]
    Double = 3,
    
    [Display(Name = "RandAdd")]
    RandAdd = 4,
    
    [Display(Name = "Undo")]
    Undo = 5
}