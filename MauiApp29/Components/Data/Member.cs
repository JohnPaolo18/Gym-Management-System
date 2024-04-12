using SQLite;

namespace GymManagement.Data;

public class Member
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(200)]
    public string FirstName { get; set; }

    [MaxLength(200)]
    public string LastName { get; set; }

    [MaxLength(20)]
    public string Email { get; set; }

    [MaxLength(400)]
    public string PhoneNumber { get; set; }
}
