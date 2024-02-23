using System.Text;

namespace ReadLineIncsharp
{
    class Program
    {
        static void Main(string[]args)
        {
            DirectoryInfo currDir = new DirectoryInfo(".");
            DirectoryInfo deresDir = new DirectoryInfo(@"C:/Users/mac/Documents/WriteLine");
            Console.WriteLine(deresDir.FullName);
            Console.WriteLine(deresDir.Name);
            Console.WriteLine(deresDir.Parent);
            Console.WriteLine(deresDir.Attributes);
            Console.WriteLine(deresDir.CreationTime);

            string[] customers =
            {
                "Angela",
                "Blesssing",
                "Jecinta"
            };


            string textFilePath = @"C:/Users/mac/Documents/WriteLine/texttest.txt";

            File.WriteAllLines(textFilePath, customers);


            foreach(string cust in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine($"Customer: {cust}");
            }
            DirectoryInfo myDataDir = new DirectoryInfo(@"C:/Users/mac/Documents/WriteLine/texttest.txt");

            FileInfo[] txtFiles = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);
            Console.WriteLine("Matches : {0}", txtFiles.Length);
            foreach(FileInfo file in txtFiles
                )
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Length);
            }


            string textFilePath2 = @"C:/Users/mac/Documents/WriteLine/texttest2.txt";
            FileStream fs = File.Open(textFilePath2, FileMode.Create);
            string randString = "This is a random string";

            byte[] rsByteArray = Encoding.Default.GetBytes(randString);


            fs.Write(rsByteArray, 0, rsByteArray.Length);
            fs.Position = 0;

            byte[] fileByteArray = new byte[rsByteArray.Length];

            for(int i =0; i<rsByteArray.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }


            Console.WriteLine(Encoding.Default.GetString(fileByteArray));
            fs.Close();

            string textFilePath3 = @"C:/Users/mac/Documents/C#Data/texttest3.txt";
            StreamWriter sw = File.CreateText(textFilePath3);
            sw.Write("This is a random ");
            sw.WriteLine("Sentence");
            sw.WriteLine("This is another sentence");

            sw.Close();

            StreamReader sr = File.OpenText(textFilePath3);
            Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));

            Console.WriteLine("Ist String : {0}",sr.ReadLine());


            Console.WriteLine("Everything : {0} ", sr.ReadToEnd());


            sr.Close();


            //Binary writer and reader

            string textFilePath4 = @"C:/Users/mac/Documents/C#Data/texttest4.txt";

            FileInfo datFile = new FileInfo(textFilePath4);
            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

            string randText = "RandomeText ";
            int myAge = 42;
            double height = 6.25;
            bw.Write(randText);
            bw.Write(myAge);
            bw.Write(height);
            bw.Close();
            BinaryReader br = new BinaryReader(datFile.OpenRead());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            br.Close();










            Console.ReadLine();







        }
    }
}
