# EasyDateTime
Extension library to work with date time much easier.

Make your code using DateTime easier to read by fluently constructing DateTime objects.

```c

// 25 years ago
DateTime birthDate = 25.Years().Ago();

// 15 minutes from now
DateTime executeTime = 15.Minutes().FromNow();

// Define using clock
Datetime downloadTime = 15.OClock();

// Durations
TimeSpan maxTimeOut = 30.Seconds();

// Scheduled actions
Action act = () => Console.WriteLine("test");
act.DoEvery(10.Seconds(), times: 100).WithoutWaiting(() => {
	Console.WriteLine("I am finished.");
});


```

Available as Nuget package: https://www.nuget.org/packages/EasyDateTime/
```
PM> Install-Package EasyDateTime
```
