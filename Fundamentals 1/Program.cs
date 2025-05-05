for (int i = 1 ; i<255 ; i++)
{
    Console.WriteLine(i);
}



Random rand = new Random();
int sum = 0;
for (int i = 10 ; i<20 ; i+= 2)
{
    int randomNum = rand.Next(10,20);
    System.Console.WriteLine(randomNum);
    sum += randomNum;
}
    System.Console.WriteLine(sum);


for (int i = 0 ; i<= 100; i++)
{
    if (i % 3 == 0 || i % 5 == 0)
    {
        System.Console.WriteLine(i);
    } 
}
for (int i = 0 ; i<= 100; i++)
{
    if (i % 3 == 0 )
    {
        System.Console.WriteLine("fizz"+i);
    } 
}
for (int i = 0 ; i<= 100; i++)
{
    if (i % 5 == 0 )
    {
        System.Console.WriteLine("buzz"+i);
    } 
}

for (int i = 0 ; i<= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        System.Console.WriteLine("fizzbuzz"+i);
    } 
}


