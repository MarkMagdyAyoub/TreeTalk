namespace TreeTalk.Model.Entities.DTOs;

public class UpdateBirthDateRequest
{
  public int UserId { get; set; }
  public DateTime BirthDate { get; set; }
}
