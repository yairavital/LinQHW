using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LinQHW;
#region MethodSyntax
//EX4
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("***Exercise4***");
List<int> ints = new List<int> { 1, 5, 34, 72, 3, 6 };
var ints2 = ints.Select(i => i+1).ToList();
ints2.Add(1);
ints2.ForEach(i => Console.Write(i.ToString() + ","));
Console.WriteLine();
//EX5
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n" + "***Exercise5***");
List<string> strings = new List<string> { "dfgg", "sss", "rrrrrrr", "nbf", "Avvvf" };
List<string> strings2 = new List<string>(strings.Where(str => str.Length > 4));
strings2.ForEach(str => Console.Write(str + " "));
//Ex6
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n" + "***Exercise6***");
var ints3 = ints2.OrderByDescending(i => i).ToList();
ints3.ForEach(i => Console.Write(i.ToString() + ","));
var strings3 = strings.OrderBy(strings => strings).ToList();
Console.WriteLine();
strings3.ForEach(str => Console.Write(str + ","));
//Ex7
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n" + "***Exercise7a***");
List<int> listInt = new List<int> { 12, 45, 82, 35, 46, 46 };
List<int> listInt2 = new List<int> { 12, 1, 82, 89, 6 };
List<int> listsComments = listInt.Intersect(listInt2).ToList();
listsComments.ForEach(i => Console.Write(i + ","));
Console.WriteLine();
List<int> notComment = listInt.Except(listInt2).ToList();
Console.WriteLine("\nEx7b");
notComment.ForEach(i => Console.Write(i + ","));
Console.WriteLine();
Console.WriteLine("\nEx7c");
listInt = listInt.Distinct().ToList();
listInt2 = listInt2.Distinct().ToList();
List<int> bothLists = listInt.Union(listInt2).ToList();
bothLists.ForEach(i => Console.Write(i.ToString() + " "));
Console.WriteLine();
Console.WriteLine("\nEx7d");
//bothLists = bothLists.Where(i=> i>12).ToList();
//var maxInt = bothLists.Max(i => i);
//Console.WriteLine(maxInt.ToString());
Console.WriteLine(listInt.First(i => i > 12));
Console.WriteLine(listInt2.First(i => i > 12));
int list1Max = listInt.Max(i => i);
int list2Max = listInt2.Max(i => i);
if (list1Max > list2Max)
    Console.WriteLine(list1Max.ToString());
else
    Console.WriteLine(list2Max.ToString());
//Ex8
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("\n" + "***Exercise8***");
List<Agents> agents = new()
{
    new("Amir", "Cohen"),
    new("Shay", "Hayoun"),
    new("David", "Cvd")
};
List<Customer> customers = new()
{
    new("Haim", "Levi", "Haim@gmail.com", agents[1]),
    new("Hm", "Lvi", "Him@gmail.com", agents[1]),
    new("Shin", "Nodds", "sh@gmail.com", agents[0])
};

customers[0].myAgent = agents[0];
customers[1].myAgent = agents[1];
customers[2].myAgent = agents[2];

var custAndAgent = agents.Join(customers, agents => agents.Name, customers => customers.myAgent.Name,
    (Agents, Customer) => new
    {
        Agents.Name,
        Customer.name
    });
foreach (var item in custAndAgent)
{
    Console.WriteLine(item.ToString());
}
//Ex9
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n" + "***Exercise9***");
Order order1 = new Order("Clock", 560, customers[0]);
Order order2 = new Order("Shoes", 250, customers[0]);
Order order3 = new Order("Skirt", 20, customers[1]);
Order order4 = new Order("Bag", 300, customers[0]);
List<Order> orders = new List<Order>();
orders.Add(order1);
orders.Add(order2);
orders.Add(order3);
orders.Add(order4);
customers[0].myOrders.Add(order1);
customers[0].myOrders.Add(order2);
customers[1].myOrders.Add(order3);


var ordersByCustomers = orders.GroupJoin(customers, orders => orders.customer.name, customers => customers.name,
    (Orders, Customer) => new
    {
        Orders.customer.name,
        Orders.ProductName,
        Orders.Price

    }).ToList();

foreach(var item in ordersByCustomers)
{
    Console.WriteLine(item);
   
}

//Ex10
int sum = 0;
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("\n" + "***Exercise10***");
Dictionary<string, List<Order>> ordersByCust = new Dictionary<string, List<Order>>();
ordersByCust.Add(customers[0].name, customers[0].myOrders);
ordersByCust.Add(customers[1].name, customers[1].myOrders);
ordersByCust.Add(customers[2].name, customers[2].myOrders);


foreach (var item in ordersByCust)
{
    Console.WriteLine("The customer is :" + item.Key + "\n His orders are:");
    foreach (var val in item.Value)
    {
        sum += val.Price;
        Console.WriteLine($"{val.ProductName} ,Price: {val.Price}");


    }
    Console.WriteLine("The total is:" + sum + "\n");
    if((sum>500) && (item.Value.Count>=2))
           Console.WriteLine("costumes with more then 2 orders 500$ worth:\n");

    sum = 0;
}
#endregion
#region QuerySyntax
//Ex4
var intsQuery = from num in ints
                select num;
intsQuery.ToList().ForEach(i => Console.Write(i + " "));
Console.WriteLine();
//Ex5
var stringsQuery = from str in strings
                   where str.Length>4
                   select str;
stringsQuery.ToList().ForEach(stringsQuery => Console.WriteLine(stringsQuery));

//Ex6
var orderByNum = from num in ints
                 orderby num
                 select num;
orderByNum.ToList().ForEach(orderByNum => Console.Write(orderByNum.ToString() + " "));
Console.WriteLine();
var orderByDisitnc = from str in strings
                     orderby str
                     select str;
orderByDisitnc.ToList().ForEach(st => Console.Write(st + " "));
Console.WriteLine();
//EX7
var commentsInts = from num in ints
                   join num2 in ints2
                   on num equals num2
                   select num2;
Console.WriteLine("The common numbers between the lists are: ");
commentsInts.ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine("\n The different numbers between the lists are: ");

var dNums = from num in ints
                   select num;
var fNums= from num2 in ints2
           select num2;

dNums.Except(fNums).ToList().ForEach(s => Console.Write(s + " ,"));

Console.WriteLine("The numbers without doublings: ");
var onlyOnce = from num in ints
               select num;
onlyOnce.Distinct().ToList().ForEach(s => Console.Write(s + " ,"));

Console.WriteLine("\n The first number above 12 on the list is: ");
var Maxum = from num in ints
                  where num>12
                  select num;

Maxum.ToList();
Console.WriteLine(Maxum.First().ToString());

Console.WriteLine();
//Ex8
var agenCust = from agent in agents
               join cust in customers
               on agent.Name equals cust.myAgent.Name
               select cust;
agenCust.ToList().ForEach(c => Console.Write(c.name + " " + c.myAgent.Name + " ,"));
Console.WriteLine();

//Ex9+10
var custOrd = from cust in customers
              join ord in orders
              on cust.name equals ord.customer.name
              into orderByCust
              select new { cust.name, ordersByCust };
custOrd.ToList();
Method(ordersByCust);

static void Method(Dictionary<string, List<Order>> orders)
{
    foreach(var keypair in orders)
    { int sum = 0;
        Console.WriteLine(keypair.Key);
        for(int i = 0; i< keypair.Value.Count; i++)
        {
            Console.WriteLine(keypair.Value[i].ProductName + " Price: " + keypair.Value[i].Price + "\n");
            sum+=keypair.Value[i].Price;
        }
        if (keypair.Value.Count >=2 && sum > 500)
            Console.WriteLine("The cust payed over 500$ and bay over 2 products");
       
    }

}


var over500an2Prod = from cust in customers
                     from custOdd in orders
                     where cust.myOrders.Count >= 2 && custOdd.Price >= 500
                     group custOdd by cust.name
                     into overCust
                     select new { nam = overCust.Key };

foreach (var var in over500an2Prod)
{
    Console.WriteLine(var);
}








#endregion







