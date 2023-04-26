using System;
using System.Linq;
using System.Windows;

namespace MonadExercise
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Hide();

           
           


            NumberWithLogs a = runWithLogs(WrapWithLogs(2), AddOne);
            NumberWithLogs b = runWithLogs(a, AddOne);
            NumberWithLogs c = runWithLogs(b, Decrement);

            foreach (string log in c.logs)
            {
                Console.WriteLine(log);
            }
        }




        public NumberWithLogs Square(int number)
        {

            return new NumberWithLogs
            {
                result = number * number,
                logs = new string[] { "Squared " + number + " to get " + number * number }

            };


           
        }

        public NumberWithLogs Decrement(int number)
        {

            return new NumberWithLogs
            {
                result = number -1,
                logs = new string[] { "Decremented " + number + " to get " + (number -1).ToString() }

            };



        }

        public NumberWithLogs AddOne(int number)
        {
            return new NumberWithLogs
            {
                result = number + 1,
                logs = new string[] { "Added 1 to " + number + " to get " + ((int)number + (int)1).ToString() }
              
            };
        }


        public NumberWithLogs WrapWithLogs(int x)
        {
            return new NumberWithLogs { result = x, logs = new string[] { } };
        }


        public NumberWithLogs runWithLogs(NumberWithLogs input, Func<int, NumberWithLogs> transform)
        {

            var a = transform(input.result);

            return new NumberWithLogs
            {
                result = a.result,
                logs = input.logs.ToList().Concat(a.logs.ToList()).ToArray()
            };



        }

      public struct NumberWithLogs
        {
          public int result;
          public string[] logs;
        }
    }
}

