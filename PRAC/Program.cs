using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls3
{

    class City
    {
        public string NameOfTheCity { get; set; }
        public string NameOfTheCountry { get; set; }
        public int NumberOfPeopleInTheCity { get; set; }
        public int AreaCode { get; set; }
        public string[] DistrictsOfTheCity { get; set; }
        public City(string nameOfTheCity, string nameOfTheCountry, int numberOfPeopleInTheCity, int areaCode, string[] districtsOfTheCity)
        {
            NameOfTheCity = nameOfTheCity;
            NameOfTheCountry = nameOfTheCountry;
            NumberOfPeopleInTheCity = numberOfPeopleInTheCity;
            AreaCode = areaCode;
            DistrictsOfTheCity = districtsOfTheCity;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name of the city: {NameOfTheCity}");
            Console.WriteLine($"Name of the country: {NameOfTheCountry}");
            Console.WriteLine($"Number of people in the city: {NumberOfPeopleInTheCity}");
            Console.WriteLine($"Area code: {AreaCode}");
            Console.WriteLine($"Districts of the city: {string.Join(", ", DistrictsOfTheCity)}");
        }

        public static City operator +(City city, int numberPeople)
        {
            city.NumberOfPeopleInTheCity += numberPeople;
            return city;
        }
        public static City operator -(City city, int numberPeople)
        {
            city.NumberOfPeopleInTheCity -= numberPeople;
            return city;
        }
        public static bool operator ==(City city, City city2)
        {
            return (city.NumberOfPeopleInTheCity == city2.NumberOfPeopleInTheCity);
        }
        public static bool operator !=(City city, City city2)
        {
            return (city.NumberOfPeopleInTheCity != city2.NumberOfPeopleInTheCity);
        }
        public static bool operator >(City city1, City city2)
        {
            return (city1.NumberOfPeopleInTheCity > city2.NumberOfPeopleInTheCity);
        }
        public static bool operator <(City city1, City city2)
        {
            return (city1.NumberOfPeopleInTheCity < city2.NumberOfPeopleInTheCity);
        }
    }

    class Employee
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public DateTime Birthday { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string JobDestriction { get; set; }
        public Employee(string fullname, int salary, DateTime birthday, string contactPhone, string email, string position, string jobDestriction)
        {
            FullName = fullname;
            Salary = salary;
            Birthday = birthday;
            ContactPhone = contactPhone;
            Email = email;
            Position = position;
            JobDestriction = jobDestriction;
        }
        public void DisplayData()
        {
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Birthday: {Birthday.ToShortDateString()}");
            Console.WriteLine($"Contact Phone: {ContactPhone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Job Description: {JobDestriction}");

        }

        public static Employee operator +(Employee employee, int AmountAllowance)
        {
            employee.Salary += AmountAllowance;
            return employee;
        }
        public static Employee operator -(Employee employee, int AmountAllowance)
        {
            employee.Salary -= AmountAllowance;
            return employee;
        }
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return (employee1.Salary == employee2.Salary);
        }
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return (employee1.Salary != employee2.Salary);
        }
        public static bool operator >(Employee employee1, Employee employee2)
        {
            return (employee1.Salary > employee2.Salary);
        }
        public static bool operator <(Employee employee1, Employee employee2)
        {
            return (employee1.Salary < employee2.Salary);
        }
    }
    class Matrix
    {
        private int[,] data;
        private int rows;
        private int columns;
        private Random random;

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public int this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public Matrix() : this(5, 5) { }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            data = new int[rows, columns];
            random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = random.Next(1, 100);
                }
            }
        }

        public void InputData()
        {
            Console.WriteLine("Enter matrix data: ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Enter element at position [{i} ,{j}]: ");
                    data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("Matrix data:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{data[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public int Max()
        {
            int max = data[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (data[i, j] > max)
                    {
                        max = data[i, j];
                    }
                }
            }
            return max;
        }

        public int Min()
        {
            int min = data[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (data[i, j] < min)
                    {
                        min = data[i, j];
                    }
                }
            }
            return min;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException("Matrices must have the same dimensions.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException("Matrices must have the same dimensions.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
            {
                throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix.");
            }

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
            {
                return true;
            }

            if (matrix1 is null || matrix2 is null)
            {
                return false;
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                return false;
            }

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1 == matrix2);
        }
    }
    class CreditCard
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public int CVC { get; set; }
        public double Balance { get; private set; }

        public CreditCard(string cardNumber, string cardHolderName, int cvc, int balance)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CVC = cvc;
            Balance = balance;
        }
        public void DisplayData()
        {
            Console.WriteLine($"Card Number: {CardNumber}");
            Console.WriteLine($"Card Holder Name: {CardHolderName}");
            Console.WriteLine($"CVC: {CVC}");
            Console.WriteLine($"Balance: {Balance}");
        }

        public static CreditCard operator +(CreditCard card, double amount)
        {
            card.Balance += amount;
            return card;
        }
        public static CreditCard operator -(CreditCard card, double amount)
        {
            card.Balance -= amount;
            return card;
        }
        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            return (card1.CVC == card2.CVC);
        }
        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return (card1.CVC != card2.CVC);
        }
        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return (card1.Balance > card2.Balance);
        }
        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return (card1.Balance < card2.Balance);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("PRAC_1");
            Employee employee1 = new Employee("John Doe", 50000, new DateTime(1990, 5, 15), "123456789", "john@example.com", "Manager", "Managing tasks");
            Employee employee2 = new Employee("Jane Smith", 60000, new DateTime(1985, 10, 25), "987654321", "jane@example.com", "Supervisor", "Supervising teams");

            Console.WriteLine("Initial Data:");
            Console.WriteLine("Employee 1:");
            employee1.DisplayData();
            Console.WriteLine("\nEmployee 2:");
            employee2.DisplayData();

            employee1 += 2000;
            Console.WriteLine("\nAfter adding allowance to Employee 1:");
            employee1.DisplayData();

            employee2 -= 3000;
            Console.WriteLine("\nAfter subtracting allowance from Employee 2:");
            employee2.DisplayData();

            Console.WriteLine("\nChecking if employees have the same salary:");
            Console.WriteLine($"Employee 1 and Employee 2 have the same salary: {employee1 == employee2}");
            Console.WriteLine($"Employee 1 and Employee 2 have different salaries: {employee1 != employee2}");

            Console.WriteLine("PRAC_2");
            Matrix matrix1 = new Matrix(3, 3);

            matrix1.InputData();

            Console.WriteLine("Matrix 1:");
            matrix1.DisplayData();

            Matrix matrix2 = new Matrix(3, 3);

            matrix2.InputData();

            Console.WriteLine("\nMatrix 2:");
            matrix2.DisplayData();

            Matrix sum = matrix1 + matrix2;
            Console.WriteLine("\nSum of matrices:");
            sum.DisplayData();

            Matrix difference = matrix1 - matrix2;
            Console.WriteLine("\nDifference of matrices:");
            difference.DisplayData();

            Console.WriteLine("\nAre matrices equal? " + (matrix1 == matrix2));

            Console.WriteLine("PRAC_3");
            string[] districtsOfCity1 = { "District A", "District B", "District C" };
            City city1 = new City("City1", "Country1", 100000, 12345, districtsOfCity1);

            string[] districtsOfCity2 = { "District X", "District Y", "District Z" };
            City city2 = new City("City2", "Country2", 200000, 67890, districtsOfCity2);

            Console.WriteLine("Initial Data:");
            Console.WriteLine("City 1:");
            city1.DisplayData();
            Console.WriteLine("\nCity 2:");
            city2.DisplayData();

            city1 += 5000;
            Console.WriteLine("\nAfter adding people to City 1:");
            city1.DisplayData();

            city2 -= 10000;
            Console.WriteLine("\nAfter subtracting people from City 2:");
            city2.DisplayData();

            Console.WriteLine("\nAre cities equal? " + (city1 == city2));

            Console.WriteLine("Is City 1 bigger than City 2? " + (city1 > city2));

            Console.WriteLine("Is City 1 smaller than City 2? " + (city1 < city2));
            Console.WriteLine("PRAC_4");

            CreditCard card1 = new CreditCard("1234 5678 9012 3456", "John Doe", 123, 1000);
            CreditCard card2 = new CreditCard("9876 5432 1098 7654", "Jane Smith", 456, 1500);

            Console.WriteLine("Initial Data:");
            Console.WriteLine("Card 1:");
            card1.DisplayData();
            Console.WriteLine("\nCard 2:");
            card2.DisplayData();

            card1 += 500;
            Console.WriteLine("\nAfter adding funds to Card 1:");
            card1.DisplayData();

            card2 -= 700;
            Console.WriteLine("\nAfter subtracting funds from Card 2:");
            card2.DisplayData();

            Console.WriteLine("\nDo cards have the same CVC? " + (card1 == card2));

            if (card1 > card2)
            {
                Console.WriteLine("Card 1 has a higher balance than Card 2.");
            }
            else if (card1 < card2)
            {
                Console.WriteLine("Card 1 has a lower balance than Card 2.");
            }
            else
            {
                Console.WriteLine("Both cards have the same balance.");
            }







                Console.ReadKey();
        }
    }
}