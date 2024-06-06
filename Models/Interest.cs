using System.ComponentModel.DataAnnotations;

namespace UsersMicroserviceAPI.Models;

public class Interest
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
}