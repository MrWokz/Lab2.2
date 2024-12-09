using System;

public class Point
{
    private double _x;
    private double _y;
    private string _name;

    // Властивість для отримання координати X
    public double X
    {
        get { return _x; }
    }

    // Властивість для отримання координати Y
    public double Y
    {
        get { return _y; }
    }

    // Властивість для отримання назви точки
    public string Name
    {
        get { return _name; }
    }

    // Конструктор класу Point
    public Point(double x, double y, string name)
    {
        _x = x;
        _y = y;
        _name = name;
    }
}

public class Figure
{
    private Point[] _points;

    // Конструктор класу Figure, який приймає від 3 до 5 точок
    public Figure(params Point[] points)
    {
        if (points.Length < 3 || points.Length > 5)
        {
            throw new ArgumentException("A figure must have between 3 and 5 points.");
        }
        _points = points;
    }

    // Метод для розрахунку довжини сторони між двома точками
    public double GetSideLength(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    // Метод для розрахунку периметра багатокутника
    public void CalculatePerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < _points.Length; i++)
        {
            Point current = _points[i];
            Point next = _points[(i + 1) % _points.Length]; // Гарантує замикання багатокутника
            perimeter += GetSideLength(current, next);
        }

        Console.WriteLine($"Perimeter of the figure: {perimeter}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of points (between 3 and 5):");
        int numPoints = int.Parse(Console.ReadLine());

        if (numPoints < 3 || numPoints > 5)
        {
            Console.WriteLine("Invalid number of points. Please enter a number between 3 and 5.");
            return;
        }

        Point[] points = new Point[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            Console.WriteLine($"Enter the name of point {i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter the X coordinate for point {name}:");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the Y coordinate for point {name}:");
            double y = double.Parse(Console.ReadLine());

            points[i] = new Point(x, y, name);
        }

        // Створення екземпляру класу Figure
        Figure figure = new Figure(points);

        // Виведення інформації про точки
        Console.WriteLine("\nFigure Points:");
        foreach (var point in points)
        {
            Console.WriteLine($"{point.Name}({point.X}, {point.Y})");
        }

        // Виведення периметра багатокутника
        figure.CalculatePerimeter();
    }
}
