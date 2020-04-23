using System;
using System.Collections.Generic;

namespace learningC_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates a new expandable list for string names
            List<string> nameList = new List<string>();
            //instantiating the generator object
            saveVars save = new saveVars();
            save.getInputSave();
            
        }
    }
    class randomNameGen
    {
        
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string generateString (int charCount)
        {
            char[] nameComponents = new char[charCount];
            for(int i = 0; i < charCount; i++)
            {
                nameComponents[i] = Convert.ToChar(RandomNumber(66, 91));
            }
            string newVarName = new string(nameComponents);
            return newVarName;
        }
    }
    class saveVars
    {
        Dictionary<string, int> intDict = new Dictionary<string, int>();
        Dictionary<string, bool> boolDict = new Dictionary<string, bool>();
        Dictionary<string, string> stringDict = new Dictionary<string, string>();
        Dictionary<string, double> doubleDict = new Dictionary<string, double>();

        public void saveInt(string name, int inputValue)
        {
            intDict.Add(name, inputValue);
        }
        public void saveBool(string name, bool inputValue)
        {
            boolDict.Add(name, inputValue);
        }
        public void saveString(string name, string inputValue)
        {
            stringDict.Add(name, inputValue);
        }
        public void saveDouble(string name, double inputValue)
        {
            doubleDict.Add(name, inputValue);
        }
        public void getInputSave()
        {
            randomNameGen generator = new randomNameGen();
            bool loopChecker = true;
            while (loopChecker == true)
            {
                Console.WriteLine("What data type is the variable?");
                string userTypeInput = Console.ReadLine();
                switch (userTypeInput)
                {
                    case "int":
                        Console.WriteLine("What is the value of the variable?");
                        string userValueInput = Console.ReadLine();
                        string intName = generator.generateString(6);
                        saveInt(intName, Convert.ToInt32(userValueInput));
                        Console.WriteLine("Your new integer is called " + intName + " and is equal to " + userValueInput);
                        intName = "";
                        break;
                    case "boolean":
                        Console.WriteLine("What is the value of the variable?");
                        string userValueInputB = Console.ReadLine();
                        string boolName = generator.generateString(6);
                        saveBool(boolName, Convert.ToBoolean(userValueInputB));
                        Console.WriteLine("Your new boolean is called " + boolName + " and is " + userValueInputB);
                        boolName = "";
                        break;
                    case "double":
                        Console.WriteLine("What is the value of the variable?");
                        string userValueInputF = Console.ReadLine();
                        string floatName = generator.generateString(6);
                        saveDouble(floatName, Convert.ToDouble(userValueInputF));
                        Console.WriteLine("Your new double is called " + floatName + " and is equal to " + userValueInputF);
                        floatName = "";
                        break;
                    case "string":
                        Console.WriteLine("What is the value of the variable?");
                        string userValueInputS = Console.ReadLine();
                        string stringName = generator.generateString(6);
                        saveString(stringName, userValueInputS);
                        Console.WriteLine("Your new string is called " + stringName + " and is equal to " + userValueInputS);
                        stringName = "";
                        break;
                }
            }
        }
    }
}
