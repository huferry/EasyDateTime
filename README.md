# EasyDateTime
Extension library to work with date time much easier.

Make your code using DateTime easier to read by fluently constructing DateTime objects.

```c
// 25 years ago
DateTime birthDate = 25.Years().Ago();

// 15 minutes from now
DateTime executeTime = 15.Minutes().FromNow();

// Define using clock
DateTime downloadTime = 15.OClock();

// Durations
TimeSpan maxTimeOut = 30.Seconds();

// Exact dates using month names
DateTime myPartyDate = 19.January(2020);
DateTime examDate = 20.March(); // current year

// Asserting day of week
bool CanDrinkBeer() => DateTime.Now.IsFriday();
bool IsChurchDay() => DateTime.Now.IsSunday();

// Closed Period
bool IsHoliday() => Period.From(25.December())
					.Until(31.December())
					.IsCurrentlyActive;

// Open Period
bool IsSchoolTime() => Period.Before(4.OClock());

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
