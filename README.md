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

```

Available as Nuget package: https://www.nuget.org/packages/EasyDateTime/
```
PM> Install-Package EasyDateTime
```
