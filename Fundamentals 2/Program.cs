using System.ComponentModel.DataAnnotations;

int[] arr = { 0,1,2,3,4,5,6,7,8,9};
string[] names = {"tim","martin","nikki","sara"};
bool[] array = new bool[10];
array[0] = true;
array[1] = false;
array[2] = true;
array[3] = false;
array[4] = true;
array[5] = false;
array[6] = true;
array[7] = false;
array[8] = true;
array[9] = false;

List<string> icecream = new List<string>();
icecream.Add("Chocolate");
icecream.Add("Oreo");
icecream.Add("Vanilla");
icecream.Add("Strawberries");
icecream.Add("Pistachio");
System.Console.WriteLine(icecream.Count);
System.Console.WriteLine(icecream[2]);
icecream.RemoveAt(2);
System.Console.WriteLine(icecream.Count);


Dictionary<string,string> MyDictionary = new Dictionary<string,string>();
Random rand = new Random();
MyDictionary.Add("First", names[0]);
MyDictionary.Add("Second", names[1]);
MyDictionary.Add("Third", names[2]);
MyDictionary.Add("Fourth", names[3]);
MyDictionary.Add("First Flavor", icecream[rand.Next(icecream.Count)]);
MyDictionary.Add("Second Flavor", icecream[rand.Next(icecream.Count)]);
MyDictionary.Add("Third Flavor", icecream[rand.Next(icecream.Count)]);
MyDictionary.Add("Fourth Flavor", icecream[rand.Next(icecream.Count)]);

foreach(KeyValuePair<string,string> entry in MyDictionary)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}








