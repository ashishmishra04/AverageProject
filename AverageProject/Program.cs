Console.WriteLine("Hello, Welcome to Average sample project!");

var averageCalculator = new AverageConsoleProject.Average();

averageCalculator.Add(7.5);
averageCalculator.Add(20.5);
averageCalculator.Add(-10);

Console.WriteLine("Added numbers: 7.5, 20.5, -10");
Console.WriteLine($"The current average is: {averageCalculator.CurrentAverage}"); // 6.0
Console.WriteLine($"The total count of numbers added is: {averageCalculator.Count}"); // 3

Console.ReadLine();
