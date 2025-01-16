namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get;  set; }
    public DateTime DateOfBirth { get;  set; }
    public bool Married { get;  set; }
    public string Phone { get;  set; }
    public decimal Salary { get;  set; }

    public User() {}
    public void UpdateDetails(string updatedName, DateTime updatedDateOfBirth, bool married, string updatedPhone,
        decimal updatedSalary)
    {
        Name = updatedName;
        DateOfBirth = updatedDateOfBirth;
        Married = married;
        Phone = updatedPhone;
        Salary = updatedSalary;
    }
}