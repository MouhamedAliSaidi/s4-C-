using System.Globalization;

static void PrintList(List<string> MyList)
{
for (int i = 0; i<MyList.Count; i++)
{
    System.Console.WriteLine(MyList[i]);
}
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);





static void SumOfNumbers(List<int> IntList)
{
int sum = 0;
for (int i = 0;i< IntList.Count ; i++)
{
    sum += IntList[i];
}
System.Console.WriteLine("Sum :" +sum );
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);


static int FindMax(List<int> IntList)
{
    int max = IntList.Max();
    return max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
FindMax(TestIntList2);
System.Console.WriteLine(FindMax(TestIntList2));




static List<int> SquareValues(List<int> IntList)
{
    // Your code here
    List<int> squaredList = new List<int>();
    foreach (int num in IntList)
    {
        squaredList.Add(num * num);
    }
    System.Console.WriteLine(string.Join(",", squaredList));
    return squaredList;
}
    

List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);



static int[] NonNegatives(int[] IntArray)
{
    // Your code here
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    System.Console.WriteLine(string.Join(", ", IntArray));
    return IntArray;
}

int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);





static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    // Your code here
    foreach (KeyValuePair<string, string> entry in MyDictionary)
    {
        System.Console.WriteLine($"label : {entry.Key}, N : {entry.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);



static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    // Your code here
    return MyDictionary.ContainsKey(SearchTerm);
}
// Use the TestDict from the earlier example or make your own
Dictionary<string,string> TestDict2 = new Dictionary<string,string>();
TestDict2.Add("HeroName", "Iron Man");
TestDict2.Add("RealName", "Tony Stark");
TestDict2.Add("Powers", "Money and intelligence");
// This should print true
Console.WriteLine(FindKey(TestDict2, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict2, "Name"));


// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // Your code here
        Dictionary<string, int> result = new Dictionary<string, int>();

    for (int i = 0; i < Names.Count; i++) 
    {
        result.Add(Names[i], Numbers[i]); 
    }

    return result; 
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here
List<string> names = new List<string> { "Julie", "Harold", "James", "Monica" };
List<int> numbers = new List<int> { 6, 12, 7, 10 };
Dictionary<string, int> testDict = GenerateDictionary(names, numbers);

//print
foreach (var entry in testDict)
{
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}








