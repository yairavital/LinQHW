using LinQHW;

public class Customer
{
    public string name;
    public string lastname;
    public string email;    
    public string phone;
    public Agents myAgent;
    public List<Order> myOrders=new List<Order>();
    public Customer(string name, string lastname, string email,Agents agent)
    {this.name = name;  
        this.lastname = lastname;
        this.email = email; 
        myAgent = agent;

    }
 

}
