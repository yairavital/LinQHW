public class Agents
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get=> Name +" " + LastName;}
    public string Phone;
    public Agents(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    public Agents()
    {

    }
}