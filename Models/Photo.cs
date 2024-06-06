using System.ComponentModel.DataAnnotations;

namespace UsersMicroserviceAPI.Models;

public class Photo
{
    [Key]
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Url { get; set; }
    public DateTime UploadedAt { get; set; }
}