using System;
using System.IO;

namespace Exercise01
{
    class Program
        
    {  
        static void Main(string[] args)
        {

            //Current temperature reading          
                 
            Console.WriteLine("Please enter the current temperature reading:");
            var inputAsString = Console.ReadLine();
            int inputCurrentTemp;

            while (!int.TryParse(inputAsString, out inputCurrentTemp))
            {
                Console.WriteLine("Incorrect input! Please enter the current temperature reading:");
                inputAsString = Console.ReadLine();
            }

            Console.WriteLine($"The current temperature reading is {inputCurrentTemp}");    
            

            //Previous temperature reading   

            const string OPERATIONAL_FILE_NAME = "C:\\Temp\\TemperatureReading.txt";
            int previouslyRecordedTemp = inputCurrentTemp;

            if (File.Exists(OPERATIONAL_FILE_NAME))
            {
                previouslyRecordedTemp = Convert.ToInt32(File.ReadAllText(OPERATIONAL_FILE_NAME));
            }                          
            File.WriteAllText(OPERATIONAL_FILE_NAME, inputCurrentTemp.ToString());


            //Temperature analysis

            if (inputCurrentTemp < 30)
            Console.WriteLine("WARNING! The current temperature is below the threshold of 30C!");
            else
            if (inputCurrentTemp > 90)
            Console.WriteLine("WARNING! The current temperature is above the threshold of 90C!");
            else
            Console.WriteLine("The current temperature is within its normal range [30 - 90C].");

            int diffTemp = inputCurrentTemp - previouslyRecordedTemp;
            Console.WriteLine("The temperature fluctuation is {0}", diffTemp);

            int diffTempAbs = Math.Abs(inputCurrentTemp - previouslyRecordedTemp);

            if (diffTempAbs > 20)
                Console.WriteLine("ALARM! The absolute temperature fluctuation is more than 20C!");
            else
                Console.WriteLine("The absolute temperature fluctuation is normal.");                 
           
            Console.ReadLine();          
            
        }
    }
}

