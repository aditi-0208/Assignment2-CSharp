// =====================================
// QUESTION 1
// Subscription Revenue Calculator
// =====================================

Console.Write("Enter the current number of customers: ");
int customers = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the monthly price per customer: ");
decimal price = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter the percentage price increase: ");
decimal percentIncrease = Convert.ToDecimal(Console.ReadLine());

decimal multiplier = 1 + percentIncrease / 100m;

decimal currentRevenue = customers * price;
decimal projectedRevenue = customers * price * multiplier;
decimal revenueIncrease = projectedRevenue - currentRevenue;

Console.WriteLine();
Console.WriteLine($"Current monthly revenue: ${currentRevenue:F2}");
Console.WriteLine($"Projected monthly revenue: ${projectedRevenue:F2}");
Console.WriteLine($"Increase in monthly revenue: ${revenueIncrease:F2}");

// =====================================
// QUESTION 2
// Investment Doubling Time
// =====================================

Console.WriteLine();
Console.Write("Enter the annual return rate as a percentage (greater than 0): ");
double returnPercent = Convert.ToDouble(Console.ReadLine());

if (returnPercent <= 0)
{
    Console.WriteLine("Error: The annual return rate must be greater than zero.");
}
else
{
    double rate = returnPercent / 100;
    double doublingYears = Math.Log(2) / Math.Log(1 + rate);

    string category;
    if (doublingYears < 10)
    {
        category = "Fast";
    }
    else if (doublingYears <= 20)
    {
        category = "Moderate";
    }
    else
    {
        category = "Slow";
    }

    Console.WriteLine($"Doubling time: {doublingYears:F2} years");
    Console.WriteLine($"Classification: {category}");
}

// =====================================
// QUESTION 3
// Triangle Area (Heron's Formula)
// =====================================

Console.WriteLine();
double sideA = 0;
double sideB = 0;
double sideC = 0;
bool validInput = true;

try
{
    Console.Write("Enter side a: ");
    sideA = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter side b: ");
    sideB = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter side c: ");
    sideC = Convert.ToDouble(Console.ReadLine());
}
catch (FormatException)
{
    validInput = false;
    Console.WriteLine("Error: Please enter numeric values for the side lengths.");
}

if (validInput)
{
    if (sideA <= 0 || sideB <= 0 || sideC <= 0)
    {
        Console.WriteLine("Error: All sides must be positive numbers.");
    }
    else if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
    {
        Console.WriteLine("Error: These sides cannot form a triangle.");
    }
    else
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        double triangleArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

        Console.WriteLine($"Triangle area: {triangleArea:F2}");
    }
}

// =====================================
// QUESTION 4
// Cloud Usage Invoice
// =====================================

Console.WriteLine();
Console.Write("Enter the number of compute hours used: ");
decimal computeHours = Convert.ToDecimal(Console.ReadLine());

if (computeHours < 0)
{
    Console.WriteLine("Error: Compute hours cannot be negative.");
}
else
{
    decimal usageCharge;

    if (computeHours <= 100)
    {
        usageCharge = computeHours * 0.12m;
    }
    else if (computeHours <= 500)
    {
        usageCharge = 100 * 0.12m + (computeHours - 100) * 0.09m;
    }
    else
    {
        usageCharge = 100 * 0.12m + 400 * 0.09m + (computeHours - 500) * 0.06m;
    }

    decimal serviceFee = usageCharge * 0.05m;
    decimal totalInvoice = usageCharge + serviceFee;

    Console.WriteLine($"Usage charge: ${usageCharge:F2}");
    Console.WriteLine($"Service fee (5%): ${serviceFee:F2}");
    Console.WriteLine($"Total invoice: ${totalInvoice:F2}");
}

// =====================================
// QUESTION 5
// Daily Sales Entry with a Sentinel
// =====================================

Console.WriteLine();
int saleCount = 0;
decimal totalSales = 0;

Console.Write("Enter a sale amount (-1 to finish): ");
decimal saleAmount = Convert.ToDecimal(Console.ReadLine());

while (saleAmount != -1)
{
    if (saleAmount < 0)
    {
        Console.WriteLine("Invalid input: sale amounts cannot be negative.");
    }
    else
    {
        saleCount++;
        totalSales += saleAmount;
    }

    Console.Write("Enter a sale amount (-1 to finish): ");
    saleAmount = Convert.ToDecimal(Console.ReadLine());
}

if (saleCount == 0)
{
    Console.WriteLine("No valid sales were entered.");
}
else
{
    decimal averageSale = totalSales / saleCount;

    Console.WriteLine($"Number of valid sales: {saleCount}");
    Console.WriteLine($"Total sales: ${totalSales:F2}");
    Console.WriteLine($"Average sale: ${averageSale:F2}");
}

// =====================================
// QUESTION 6
// Investment Payback Simulator
// =====================================

Console.WriteLine();
Console.Write("Enter the initial investment: ");
decimal initialInvestment = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter the expected monthly benefit: ");
decimal monthlyBenefit = Convert.ToDecimal(Console.ReadLine());

if (initialInvestment <= 0 || monthlyBenefit <= 0)
{
    Console.WriteLine("Error: The initial investment and the monthly benefit must both be greater than zero.");
}
else
{
    decimal cumulativeBenefits = 0;
    int monthCount = 0;
    int maxMonths = 600;

    while (cumulativeBenefits < initialInvestment && monthCount < maxMonths)
    {
        monthCount++;
        cumulativeBenefits += monthlyBenefit;

        decimal unrecoveredBalance = Math.Max(0m, initialInvestment - cumulativeBenefits);
        Console.WriteLine($"Month {monthCount}: unrecovered balance ${unrecoveredBalance:F2}");
    }

    if (cumulativeBenefits >= initialInvestment)
    {
        Console.WriteLine($"Payback month: {monthCount}");
        Console.WriteLine($"Cumulative benefits at payback: ${cumulativeBenefits:F2}");
    }
    else
    {
        Console.WriteLine($"The investment was not recovered within {maxMonths} months.");
    }
}

// =====================================
// QUESTION 7
// Weekly Demand Bar Chart
// =====================================

Console.WriteLine();
int[] weeklyDemand = new int[7];

for (int fillIndex = 0; fillIndex < 7; fillIndex++)
{
    Console.Write($"Enter demand for day {fillIndex + 1}: ");
    int demandInput = Convert.ToInt32(Console.ReadLine());

    while (demandInput < 0)
    {
        Console.WriteLine("Error: Demand must be zero or greater.");
        Console.Write($"Enter demand for day {fillIndex + 1}: ");
        demandInput = Convert.ToInt32(Console.ReadLine());
    }

    weeklyDemand[fillIndex] = demandInput;
}

Console.WriteLine();
Console.WriteLine("Weekly Demand Chart");

for (int dayIndex = 0; dayIndex < 7; dayIndex++)
{
    int starCount = weeklyDemand[dayIndex] / 10;

    Console.Write($"Day {dayIndex + 1} ({weeklyDemand[dayIndex]} units): ");

    for (int starNumber = 0; starNumber < starCount; starNumber++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

// =====================================
// QUESTION 8
// Customer Risk Score
// =====================================

int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive)
{
    return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;
}

Console.WriteLine();
Console.Write("Enter the number of missed payments: ");
int missedCount = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the number of support tickets: ");
int ticketCount = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the number of months inactive: ");
int inactiveMonths = Convert.ToInt32(Console.ReadLine());

if (missedCount < 0 || ticketCount < 0 || inactiveMonths < 0)
{
    Console.WriteLine("Error: All values must be zero or greater.");
}
else
{
    int riskScore = ComputeRiskScore(missedCount, ticketCount, inactiveMonths);

    string riskLevel;
    if (riskScore < 30)
    {
        riskLevel = "Low";
    }
    else if (riskScore < 60)
    {
        riskLevel = "Moderate";
    }
    else
    {
        riskLevel = "High";
    }

    Console.WriteLine($"Risk score: {riskScore}");
    Console.WriteLine($"Risk level: {riskLevel}");
}

// =====================================
// QUESTION 9
// Transaction Anomaly Screening
// =====================================

Console.WriteLine();
Console.Write("How many transactions will be entered (3 to 20)? ");
int transactionCount = Convert.ToInt32(Console.ReadLine());

while (transactionCount < 3 || transactionCount > 20)
{
    Console.WriteLine("Error: The number of transactions must be from 3 through 20.");
    Console.Write("How many transactions will be entered (3 to 20)? ");
    transactionCount = Convert.ToInt32(Console.ReadLine());
}

decimal[] transactionAmounts = new decimal[transactionCount];

for (int entryIndex = 0; entryIndex < transactionCount; entryIndex++)
{
    Console.Write($"Enter transaction amount {entryIndex + 1}: ");
    decimal amountInput = Convert.ToDecimal(Console.ReadLine());

    while (amountInput < 0)
    {
        Console.WriteLine("Error: Transaction amounts cannot be negative.");
        Console.Write($"Enter transaction amount {entryIndex + 1}: ");
        amountInput = Convert.ToDecimal(Console.ReadLine());
    }

    transactionAmounts[entryIndex] = amountInput;
}

// First pass: minimum, maximum, and total
decimal minAmount = transactionAmounts[0];
decimal maxAmount = transactionAmounts[0];
decimal totalAmount = 0;

for (int scanIndex = 0; scanIndex < transactionCount; scanIndex++)
{
    totalAmount += transactionAmounts[scanIndex];

    if (transactionAmounts[scanIndex] < minAmount)
    {
        minAmount = transactionAmounts[scanIndex];
    }

    if (transactionAmounts[scanIndex] > maxAmount)
    {
        maxAmount = transactionAmounts[scanIndex];
    }
}

decimal meanAmount = totalAmount / transactionCount;

Console.WriteLine();
Console.WriteLine($"Minimum: ${minAmount:F2}");
Console.WriteLine($"Maximum: ${maxAmount:F2}");
Console.WriteLine($"Total: ${totalAmount:F2}");
Console.WriteLine($"Mean: ${meanAmount:F2}");
Console.WriteLine();

// Second pass: label each transaction using the finished mean
for (int labelIndex = 0; labelIndex < transactionCount; labelIndex++)
{
    string label;
    if (transactionAmounts[labelIndex] > 1.5m * meanAmount)
    {
        label = "Review";
    }
    else
    {
        label = "Normal";
    }

    Console.WriteLine($"Transaction {labelIndex + 1}: ${transactionAmounts[labelIndex]:F2} - {label}");
}

// =====================================
// QUESTION 10
// Seven Day Performance Summary
// =====================================

decimal CalculateTotal(decimal[] sales)
{
    decimal runningTotal = 0;

    for (int totalIndex = 0; totalIndex < sales.Length; totalIndex++)
    {
        runningTotal += sales[totalIndex];
    }

    return runningTotal;
}

// REVISED BY ME: The GenAI design had CalculateAverage reuse CalculateTotal.
// I changed it so CalculateAverage uses its own loop, so each required method clearly uses a loop.
decimal CalculateAverage(decimal[] sales)
{
    decimal sumForAverage = 0;

    for (int averageIndex = 0; averageIndex < sales.Length; averageIndex++)
    {
        sumForAverage += sales[averageIndex];
    }

    return sumForAverage / sales.Length;
}

decimal FindHighest(decimal[] sales)
{
    decimal currentHighest = sales[0];

    for (int highIndex = 0; highIndex < sales.Length; highIndex++)
    {
        if (sales[highIndex] > currentHighest)
        {
            currentHighest = sales[highIndex];
        }
    }

    return currentHighest;
}

decimal FindLowest(decimal[] sales)
{
    decimal currentLowest = sales[0];

    for (int lowIndex = 0; lowIndex < sales.Length; lowIndex++)
    {
        if (sales[lowIndex] < currentLowest)
        {
            currentLowest = sales[lowIndex];
        }
    }

    return currentLowest;
}

int CountDaysAboveAverage(decimal[] sales, decimal average)
{
    int aboveCount = 0;

    for (int countIndex = 0; countIndex < sales.Length; countIndex++)
    {
        if (sales[countIndex] > average)
        {
            aboveCount++;
        }
    }

    return aboveCount;
}

Console.WriteLine();
decimal[] sevenDaySales = new decimal[7];

for (int salesIndex = 0; salesIndex < 7; salesIndex++)
{
    bool valueAccepted = false;

    while (!valueAccepted)
    {
        Console.Write($"Enter sales for day {salesIndex + 1}: ");

        try
        {
            decimal salesInput = Convert.ToDecimal(Console.ReadLine());

            if (salesInput < 0)
            {
                Console.WriteLine("Error: Sales must be zero or greater.");
            }
            else
            {
                sevenDaySales[salesIndex] = salesInput;
                valueAccepted = true;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: That number is too large. Please enter a valid number.");
        }
    }
}

decimal salesTotal = CalculateTotal(sevenDaySales);
decimal salesAverage = CalculateAverage(sevenDaySales);
decimal highestSales = FindHighest(sevenDaySales);
decimal lowestSales = FindLowest(sevenDaySales);
int daysAboveAverage = CountDaysAboveAverage(sevenDaySales, salesAverage);

string weekType;
if (daysAboveAverage >= 4)
{
    weekType = "Strong";
}
else if (daysAboveAverage >= 2)
{
    weekType = "Balanced";
}
else
{
    weekType = "Concentrated";
}

Console.WriteLine();
Console.WriteLine("Daily Sales");

for (int showIndex = 0; showIndex < 7; showIndex++)
{
    Console.WriteLine($"Day {showIndex + 1}: ${sevenDaySales[showIndex]:F2}");
}

Console.WriteLine();
Console.WriteLine($"Total sales: ${salesTotal:F2}");
Console.WriteLine($"Average sales: ${salesAverage:F2}");
Console.WriteLine($"Highest sales: ${highestSales:F2}");
Console.WriteLine($"Lowest sales: ${lowestSales:F2}");
Console.WriteLine($"Days above average: {daysAboveAverage}");
Console.WriteLine($"Week classification: {weekType}");
