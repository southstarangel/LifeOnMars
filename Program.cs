using System.Diagnostics.Metrics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LifeOnMars
{
    class Program
    {
        public static string dnaInput = null; // needs to be outside any methods to call this variable for other methods
        public static string startCodon = "ATG";
        public static char convertedInput;
        public static int input, randomGenes, randomCodons, randomGender, emptycounter = 0, counter = 0;
        public static char[] bonds1;
        public static string genderGen1, genderGen2; // For finding genders in operation 3
        public static string finalGender;
        public static string emptySpace = "";




        public static void Main(string[] args)
        {

            // Variables

            bool showMenu = true; // Boolean variable for the main menu (for while loop)

            while (showMenu) // Main menu loop, this makes the program go back to the main menu after any operation
            {
                showMenu = MainMenu();
            }

        }




        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine(@"----Life on Mars----" + "\n");
            Console.Write("Main DNA Strand: " + dnaInput + "\n");
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("* 1) Input DNA Strand 1 by file");
            Console.WriteLine("* 2) Input DNA Strand 1 by keyboard");
            Console.WriteLine("* 3) Generate random genes for BLOB organism");
            Console.WriteLine("* 4) Check DNA gene structure");
            Console.WriteLine("* 5) Check DNA BLOB organism");
            Console.WriteLine("* 6) Produce complement of a DNA sequence");
            Console.WriteLine("* 7) Determine amino acids");
            Console.WriteLine("* 8) Delete codons");
            Console.WriteLine("* 9) Insert codons");
            Console.WriteLine("* 10) Find codons");
            Console.WriteLine("* 11) Reverse codons");
            Console.WriteLine("* 12) Find the number of genes in a DNA Strand");
            Console.WriteLine("* 13) Find the shortest gene in a DNA Strand");
            Console.WriteLine("* 14) Find the longest gene in a DNA Strand");
            Console.WriteLine("* 15) Find the most repeated n-nucleotide sequence in a DNA Strand");
            Console.WriteLine("* 16) Hydrogen bond statistics for a DNA Strand");
            Console.WriteLine("* 17) Simulate BLOB generations using DNA strands");
            Console.WriteLine("* 0) Exit");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {

                case "1":
                    MainStrandFile();
                    return true;

                case "2":

                    MainStrandKeyboard();
                    return true;

                case "3":
                    OperationThree();
                    return true;

                case "4":
                    OperationFour();
                    return true;

                case "5":
                    OperationFive();
                    return true;

                case "6":
                    OperationSix();
                    return true;

                case "7":
                    OperationSeven();
                    return true;

                case "8":
                    OperationEight();
                    return true;

                case "9":
                    OperationNine();
                    return true;

                case "10":
                    OperationTen();
                    return true;

                case "11":
                    OperationEleven();
                    return true;

                case "12":
                    OperationTwelve();
                    return true;

                case "13":
                    OperationThirteen();
                    return true;

                case "14":
                    OperationFourteen();
                    return true;

                case "0":
                    return false;

                default:
                    return true;
            }
        }


        // Operation 1 *
        private static void MainStrandFile()
        {
            StreamReader f = File.OpenText("E:\\Coding Projects\\C#\\Life on Mars\\LifeOnMars\\LifeOnMars\\dna1.txt");
            dnaInput = f.ReadLine();
            Console.Write("dna1.txt: " + dnaInput + "\n");
        }
        // Operation 2 *

        private static void MainStrandKeyboard()
        {
            Console.Write("Input the DNA Strand 1: ");
            dnaInput = Console.ReadLine();
        }


        // Operation 3 *

        private static void OperationThree()
        {
            Random r = new Random();
            string[] genderGenes = new string[4];
            genderGenes[0] = "AAA";
            genderGenes[1] = "TTT";
            genderGenes[2] = "GGG";
            genderGenes[3] = "CCC";

            randomGenes = r.Next(2, 8);
            Console.WriteLine(randomGenes);
            randomCodons = r.Next(3, 9);

            randomGender = r.Next(0, 4);         // find random gender twice so that we do not get the same result
            genderGen1 = genderGenes[randomGender];
            randomGender = r.Next(0, 4);
            genderGen2 = genderGenes[randomGender];

            for (int i = 1; i <= randomGenes; i++)
            {
                randomGender = r.Next(0, 4);
                genderGen1 = genderGenes[randomGender];
                randomGender = r.Next(0, 4);
                genderGen2 = genderGenes[randomGender];

                while ((genderGen1 == "CCC" && genderGen2 == "CCC") ||
                       (genderGen1 == "GGG" && genderGen2 == "GGG") ||
                       (genderGen1 == "GGG" && genderGen2 == "CCC") ||
                       (genderGen1 == "CCC" && genderGen2 == "GGG"))
                {
                    randomGender = r.Next(0, 4);
                    genderGen1 = genderGenes[randomGender];
                    randomGender = r.Next(0, 4);
                    genderGen2 = genderGenes[randomGender];

                    //YY posibility 

                }
                if (genderGen1 == "TTT" && genderGen2 == "TTT" ||
                    genderGen1 == "AAA" && genderGen2 == "AAA" ||
                    genderGen1 == "AAA" && genderGen2 == "TTT" ||
                    genderGen1 == "TTT" && genderGen2 == "AAA")
                {
                    finalGender = "female";
                }
                else
                {
                    finalGender = "male";
                }
                Console.WriteLine(startCodon + " " + genderGen1 + " " + genderGen2 + " " + "TAG" + " -> " + finalGender);
                randomCodons = r.Next(3, 9);
            }

            Console.WriteLine("\n" + "Press any key to return to main menu");
            Console.ReadKey();

        }

        // Operation 4 *
        private static void OperationFour()
        {

            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }


            // Variables
            bool notblobanswer = false;
            bool outfromwhile = true;
            int codoncounter = 0;
            bool gene_structure = true;
            bool codon_structure = true;
            int firstStartIndex = 0;
            int secondStartIndex = 0;
            counter = 0;
            emptycounter = 0;


            char[] dnaInputChar = dnaInput.ToCharArray();

            //Deleting Empty Chars
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] == ' ')
                {
                    dnaInputChar[i] = '?';
                    emptycounter++;
                }
            }




            char[] newdnaInputChar = new char[dnaInputChar.Length - emptycounter]; //New Strand
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] != '?')
                {
                    newdnaInputChar[i - counter] = dnaInputChar[i];
                }
                else
                {
                    counter++;
                }
            }

            //Checking DNA length
            if (newdnaInputChar.Length % 3 != 0)
            {
                codon_structure = false;
            }

            //Checking characters in DNA strand
            int k = 0;
            while (k < newdnaInputChar.Length)
            {
                if (newdnaInputChar[k] != 'A' && newdnaInputChar[k] != 'T' && newdnaInputChar[k] != 'G' && newdnaInputChar[k] != 'C')
                {
                    gene_structure = false;
                }
                k++;
            }
            if (newdnaInputChar.Length == 0)
            {
                gene_structure = false;
            }


            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if (newdnaInputChar.Length - 3 > codoncounter)
                {
                    if (newdnaInputChar[codoncounter] == 'A' && newdnaInputChar[codoncounter + 1] == 'T' && newdnaInputChar[codoncounter + 2] == 'G')
                    {
                        firstStartIndex = codoncounter; // Saving the value of first start codons index 
                        while (outfromwhile == true)
                        {
                            if ((newdnaInputChar[secondStartIndex] == 'A' && newdnaInputChar[secondStartIndex + 1] == 'T' && newdnaInputChar[secondStartIndex + 2] == 'G') && (secondStartIndex > firstStartIndex) && (secondStartIndex % 3 == 0))
                            {
                                outfromwhile = false;
                            }
                            else
                            {
                                secondStartIndex++;
                            }

                            if (secondStartIndex == newdnaInputChar.Length - 3)
                            {
                                outfromwhile = false;
                            }
                        }

                        bool finishwstop = false;
                        //Finding Stop Codon
                        while ((finishwstop == false) & (gene_structure == true))
                        {
                            if ((
                            newdnaInputChar[codoncounter] == 'T' &&
                            newdnaInputChar[codoncounter + 1] == 'G' &&
                            newdnaInputChar[codoncounter + 2] == 'A' ||
                            newdnaInputChar[codoncounter] == 'T' &&
                            newdnaInputChar[codoncounter + 1] == 'A' &&
                            newdnaInputChar[codoncounter + 2] == 'A' ||
                            newdnaInputChar[codoncounter] == 'T' &&
                            newdnaInputChar[codoncounter + 1] == 'A' &&
                            newdnaInputChar[codoncounter + 2] == 'G') && (codoncounter % 3 == 0))
                            {
                                finishwstop = true;
                                gene_structure = true;
                            }
                            else
                            {
                                if (codoncounter >= newdnaInputChar.Length - 2)
                                {
                                    gene_structure = false;
                                    //Checks the end of codons
                                }
                            }
                            codoncounter++;
                        }

                        if (gene_structure == false)
                        {
                            codoncounter--;
                            //To get the index real value back (Actullay not needed but ı am scared to remove :D)
                        }
                        int lastStopIndex = codoncounter - 1;

                        if (secondStartIndex < lastStopIndex)
                        {
                            gene_structure = false;

                        }
                        int notblob = lastStopIndex - firstStartIndex;

                        if (notblob < 6)
                        {
                            notblobanswer = true;
                        }


                        outfromwhile = true;
                        codoncounter = codoncounter + 2; // Will start with next codons first nucleotide

                    }
                    //does not start with ATG so not an DNA
                    else
                    {
                        gene_structure = false;
                    }
                }
            }




            // Outputs

            Console.Write("DNA strand  :  ");
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {

                if (i % 3 == 0 && i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(newdnaInputChar[i]);
            }
            Console.WriteLine();

            if (gene_structure == true && codon_structure == true)
            {
                if (notblobanswer == false)
                {
                    Console.WriteLine("Gene structure is OK.");
                }
                else if (notblobanswer == true)
                {
                    Console.WriteLine("Gene structure is OK.(Not BLOB DNA,but OK)");
                }
            }
            else
            {
                Console.WriteLine("Codon structure error.");
            }
            Console.WriteLine();

            outfromwhile = true;
            codoncounter = 0;
            firstStartIndex = 0;
            secondStartIndex = 0;
            counter = 0;
            emptycounter = 0;

            char[] MainDnaChar = new char[newdnaInputChar.Length + (newdnaInputChar.Length / 3)];

            //Adding Empty Spaces For Other Operations 
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if ((i + counter) % 4 == 3)
                {
                    MainDnaChar[i + counter] = ' ';
                    counter++;
                }

                MainDnaChar[i + counter] = newdnaInputChar[i];
            }

            for (int i = 0; i < MainDnaChar.Length; i++)
            {
                Console.Write(MainDnaChar[i]);
            }
            counter = 0;

            //MainDnaChar is the main strand with empty spaces

            Console.Read();
        }


        // Operation 5 *

        private static void OperationFive()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }

            counter = 0;
            char firstGenderBlob = ' ';
            char secondGenderBlob = ' ';
            bool genderError = false;
            bool outfromwhile = true;
            emptycounter = 0;
            emptycounter = 0;

            char[] dnaInputChar = dnaInput.ToCharArray();

            Console.WriteLine(dnaInputChar);

            //Deleting Empty Chars
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] == ' ')
                {
                    dnaInputChar[i] = '?';
                    emptycounter++;
                }
            }

            char[] newdnaInputChar = new char[dnaInputChar.Length - emptycounter]; //New Strand

            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] != '?')
                {
                    newdnaInputChar[i - counter] = dnaInputChar[i];
                }
                else
                {
                    counter++;
                }
            }

            //Checking gender genes

            if ((newdnaInputChar[3] == 'A' && newdnaInputChar[4] == 'A' && newdnaInputChar[5] == 'A') || (newdnaInputChar[3] == 'T' && newdnaInputChar[4] == 'T' && newdnaInputChar[5] == 'T'))
            {
                firstGenderBlob = 'X';
            }
            else if ((newdnaInputChar[3] == 'G' && newdnaInputChar[4] == 'G' && newdnaInputChar[5] == 'G') || (newdnaInputChar[3] == 'C' && newdnaInputChar[4] == 'C' && newdnaInputChar[5] == 'C'))
            {
                firstGenderBlob = 'Y';
            }
            if ((newdnaInputChar[6] == 'A' && newdnaInputChar[7] == 'A' && newdnaInputChar[8] == 'A') || (newdnaInputChar[6] == 'T' && newdnaInputChar[7] == 'T' && newdnaInputChar[8] == 'T'))
            {
                secondGenderBlob = 'X';
            }
            else if ((newdnaInputChar[6] == 'G' && newdnaInputChar[7] == 'G' && newdnaInputChar[8] == 'G') || (newdnaInputChar[6] == 'C' && newdnaInputChar[7] == 'C' && newdnaInputChar[8] == 'C'))
            {
                secondGenderBlob = 'Y';
            }

            if (firstGenderBlob == ' ' || secondGenderBlob == ' ')
            {
                genderError = true;
            }

            int StartIndex = 0;
            int bfrStartIndex = 0;
            int bfrStopIndex = 0;
            int StopIndex = 0;

            for (int i = 0; i < newdnaInputChar.Length / 6; i++)
            {
                while (outfromwhile == true)
                {
                    if (newdnaInputChar.Length - 3 > StopIndex)
                    {
                        if ((newdnaInputChar[StopIndex] == 'T' &&
                            newdnaInputChar[StopIndex + 1] == 'G' &&
                            newdnaInputChar[StopIndex + 2] == 'A' ||
                            newdnaInputChar[StopIndex] == 'T' &&
                            newdnaInputChar[StopIndex + 1] == 'A' &&
                            newdnaInputChar[StopIndex + 2] == 'A' ||
                            newdnaInputChar[StopIndex] == 'T' &&
                            newdnaInputChar[StopIndex + 1] == 'A' &&
                            newdnaInputChar[StopIndex + 2] == 'G') && (StopIndex % 3 == 0) && (StopIndex > bfrStopIndex))
                        {
                            outfromwhile = false;
                            bfrStopIndex = StopIndex;
                        }
                        else
                        {
                            StopIndex++;
                        }
                    }
                    else
                    {
                        outfromwhile = false;
                    }
                }

                //Founded Stop Codons Index

                outfromwhile = true;
                while (outfromwhile == true)
                {
                    if (newdnaInputChar.Length - 3 > StopIndex)
                    {
                        if ((newdnaInputChar[StartIndex] == 'A' && newdnaInputChar[StartIndex + 1] == 'T' && newdnaInputChar[StartIndex + 2] == 'G') && (StartIndex > bfrStartIndex) && (StartIndex % 3 == 0))
                        {
                            outfromwhile = false;
                            bfrStartIndex = StartIndex;
                        }
                        else
                        {
                            StartIndex++;
                        }
                    }
                    else
                    {
                        outfromwhile = false;
                    }
                }
                outfromwhile = true;
                //Founded Start Codons Index
            }

            //Outputs
            Console.Write("DNA strand  :  ");
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {

                if (i % 3 == 0 && i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(newdnaInputChar[i]);
            }
            Console.WriteLine();
            if (genderError == true)
            {
                Console.Write("Gender Error.");
                if (bfrStopIndex == 0)
                {
                    //Mean there is 1 gene
                    Console.Write("Number of genes error. ");
                }
                else if (StopIndex - StartIndex == 3)
                {
                    Console.WriteLine("Number of codons error. ");
                }
            }
            else
            {
                if (bfrStopIndex == 0)
                {
                    //Mean there is 1 gene 
                    Console.Write("Number of genes error. ");
                }
                else if (StopIndex - StartIndex == 3)
                {
                    Console.Write("Number of codons error. ");
                }
                else
                {
                    Console.Write("BLOB is OK. ");
                }
            }
            Console.WriteLine();

            outfromwhile = true;
            counter = 0;
            emptycounter = 0;

            char[] MainDnaChar = new char[newdnaInputChar.Length + (newdnaInputChar.Length / 3)];

            //Adding Empty Spaces For Other Operations 
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if ((i + counter) % 4 == 3)
                {
                    MainDnaChar[i + counter] = ' ';
                    counter++;
                }

                MainDnaChar[i + counter] = newdnaInputChar[i];
            }

            for (int i = 0; i < MainDnaChar.Length; i++)
            {
                Console.Write(MainDnaChar[i]);
            }
            counter = 0;

            //MainDnaChar is the main strand with empty spaces

            Console.ReadKey();
        }

        // Operation 6 *

        private static void OperationSix()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }

            char[] dnaInputChar = dnaInput.ToCharArray();

            //Reseting The Variables
            emptycounter = 0;
            counter = 0;

            //Deleting Empty Chars
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] == ' ')
                {
                    dnaInputChar[i] = '?';
                    emptycounter++;
                }
            }

            char[] newdnaInputChar = new char[dnaInputChar.Length - emptycounter]; //New Strand
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] != '?')
                {
                    newdnaInputChar[i - counter] = dnaInputChar[i];
                }
                else
                {
                    counter++;
                }
            }


            Console.WriteLine("Main DNA strand: " + dnaInput);
            Console.Write("Complement: ");

            var oldOut = Console.Out;

            using var fileStream = new FileStream("out.txt", FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);
            Console.SetOut(streamWriter);
            Console.SetError(streamWriter);
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if (newdnaInputChar[i] == 'A')
                    Console.Write('T');
                else if (newdnaInputChar[i] == 'T')
                {
                    Console.Write('A');
                }
                else if (newdnaInputChar[i] == 'G')
                {
                    Console.Write('C');
                }
                else if (newdnaInputChar[i] == 'C')
                {
                    Console.Write('G');
                }
            }

            Console.SetOut(oldOut);
            Console.SetError(oldOut);

            streamWriter.Close();

            StreamReader f = File.OpenText("out.txt");
            dnaInput = f.ReadLine();
            f.Close();

            Console.Write(dnaInput);



            //Reseting The Variables
            counter = 0;
            emptycounter = 0;

            char[] MainDnaChar = new char[newdnaInputChar.Length + (newdnaInputChar.Length / 3)];

            //Adding Empty Spaces For Other Operations 
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if ((i + counter) % 4 == 3)
                {
                    MainDnaChar[i + counter] = ' ';
                    counter++;
                }

                MainDnaChar[i + counter] = newdnaInputChar[i];
            }

            //   for (int i = 0; i < MainDnaChar.Length; i++)
            //      {
            //     Console.Write(MainDnaChar[i]);
            //      }

            counter = 0;

            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 7 *

        private static void OperationSeven()
        {

            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }

            string[] aminoAcids = new string[dnaInput.Length / 3];

            char[] dnaInputChar = dnaInput.ToCharArray();

            //Reseting The Variables
            emptycounter = 0;
            counter = 0;
            emptySpace = "";

            //Deleting Empty Chars
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] == ' ')
                {
                    dnaInputChar[i] = '?';
                    emptycounter++;
                }
            }

            char[] newdnaInputChar = new char[dnaInputChar.Length - emptycounter]; //New Strand
            for (int i = 0; i < dnaInputChar.Length; i++)
            {
                if (dnaInputChar[i] != '?')
                {
                    newdnaInputChar[i - counter] = dnaInputChar[i];
                }
                else
                {
                    counter++;
                }
            }



            Console.WriteLine("DNA strand: " + dnaInput);
            Console.Write("Amino acids: ");

            for (int i = 0; i < newdnaInputChar.Length; i += 3)
            {
                emptySpace = emptySpace + newdnaInputChar[i];
                emptySpace = emptySpace + newdnaInputChar[i + 1];
                emptySpace = emptySpace + newdnaInputChar[i + 2];
                aminoAcids[i / 3] = emptySpace;
                emptySpace = "";
            }


            for (int i = 0; i < aminoAcids.Length; i++)
            {
                if (aminoAcids[i] == "GCT" || aminoAcids[i] == "GCC" || aminoAcids[i] == "GCA" || aminoAcids[i] == "GCG")
                {
                    Console.Write("Ala ");
                }
                if (aminoAcids[i] == "GGT" || aminoAcids[i] == "GGC" || aminoAcids[i] == "GGA" || aminoAcids[i] == "GGG")
                {
                    Console.Write("Gly ");
                }
                if (aminoAcids[i] == "CCT" || aminoAcids[i] == "CCC" || aminoAcids[i] == "CCA" || aminoAcids[i] == "CCG")
                {
                    Console.Write("Pro ");
                }
                if (aminoAcids[i] == "CGT" || aminoAcids[i] == "CGC" || aminoAcids[i] == "CGA" || aminoAcids[i] == "CGG" || aminoAcids[i] == "AGA" || aminoAcids[i] == "AGG")
                {
                    Console.Write("Arg ");
                }
                if (aminoAcids[i] == "CAT" || aminoAcids[i] == "CAC")
                {
                    Console.Write("His ");
                }
                if (aminoAcids[i] == "TCT" || aminoAcids[i] == "TCC" || aminoAcids[i] == "TCA" || aminoAcids[i] == "TCG" || aminoAcids[i] == "AGT" || aminoAcids[i] == "AGC")
                {
                    Console.Write("Ser ");
                }
                if (aminoAcids[i] == "AAT" || aminoAcids[i] == "AAC")
                {
                    Console.Write("Asn ");
                }
                if (aminoAcids[i] == "ATT" || aminoAcids[i] == "ATC" || aminoAcids[i] == "ATA")
                {
                    Console.Write("Ile ");
                }
                if (aminoAcids[i] == "ACT" || aminoAcids[i] == "ACC" || aminoAcids[i] == "ACA" || aminoAcids[i] == "ACG")
                {
                    Console.Write("Thr ");
                }
                if (aminoAcids[i] == "GAT" || aminoAcids[i] == "GAC")
                {
                    Console.Write("Asp ");
                }
                if (aminoAcids[i] == "CTT" || aminoAcids[i] == "CTC" || aminoAcids[i] == "CTA" || aminoAcids[i] == "CTG" || aminoAcids[i] == "TTA" || aminoAcids[i] == "TTG")
                {
                    Console.Write("Leu ");
                }
                if (aminoAcids[i] == "TGG")
                {
                    Console.Write("Trp ");
                }
                if (aminoAcids[i] == "TGT" || aminoAcids[i] == "TGC")
                {
                    Console.Write("Cys ");
                }
                if (aminoAcids[i] == "AAA" || aminoAcids[i] == "AAG")
                {
                    Console.Write("Lys ");
                }
                if (aminoAcids[i] == "TAT" || aminoAcids[i] == "TAC")
                {
                    Console.Write("Tyr ");
                }
                if (aminoAcids[i] == "CAA" || aminoAcids[i] == "CAG")
                {
                    Console.Write("Gln ");
                }
                if (aminoAcids[i] == "ATG") // Start codon
                {
                    Console.Write("Met ");
                }
                if (aminoAcids[i] == "GTT" || aminoAcids[i] == "GTC" || aminoAcids[i] == "GTA" || aminoAcids[i] == "GTG")
                {
                    Console.Write("Val ");
                }
                if (aminoAcids[i] == "GAA" || aminoAcids[i] == "GAG")
                {
                    Console.Write("Glu ");
                }
                if (aminoAcids[i] == "TTT" || aminoAcids[i] == "TTC")
                {
                    Console.Write("Phe ");
                }
                if (aminoAcids[i] == "TAA" || aminoAcids[i] == "TGA" || aminoAcids[i] == "TAG") // END codons (Print as END)
                {
                    Console.Write("END ");
                }
            }


            //Reseting The Variables
            counter = 0;
            emptycounter = 0;

            char[] MainDnaChar = new char[newdnaInputChar.Length + (newdnaInputChar.Length / 3)];

            //Adding Empty Spaces For Other Operations 
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if ((i + counter) % 4 == 3)
                {
                    MainDnaChar[i + counter] = ' ';
                    counter++;
                }

                MainDnaChar[i + counter] = newdnaInputChar[i];
            }

            //        for (int i = 0; i < MainDnaChar.Length; i++)
            //       {
            //            Console.Write(MainDnaChar[i]);
            //      }
            counter = 0;

            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 8 *

        private static void OperationEight()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }


            // Console.WriteLine(DnaStrand.Length);
            int deleteCnum, StartInd, Startcod;
            Console.Write("Please enter how many codon number that you want to delete: ");
            deleteCnum = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please enter that which codon do you want to start; ");
            Startcod = Convert.ToInt16(Console.ReadLine());
            Char[] CharDnaStrand = dnaInput.ToCharArray();
            //Console.WriteLine(CharDnaStrand.Length);
            emptycounter = 0;
            counter = 0;
            int StartIndex = (Startcod - 1) * 4;
            int StopIndex = (StartIndex) + 2 + 4 * (deleteCnum - 1);

            var oldOut = Console.Out;

            using var fileStream = new FileStream("out.txt", FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);


            Console.SetOut(streamWriter);
            Console.SetError(streamWriter);

            for (int x = StartIndex; x <= StopIndex; x++)
            {
                CharDnaStrand[x] = ' ';

            }

            for (int i = 0; i < CharDnaStrand.Length; i++)
            {
                if (CharDnaStrand[i] == ' ')
                {
                    CharDnaStrand[i] = '?';
                    emptycounter++;
                }
            }
            char[] newdnaInputChar = new char[CharDnaStrand.Length - emptycounter]; //New Strand
            for (int i = 0; i < CharDnaStrand.Length; i++)
            {
                if (CharDnaStrand[i] != '?')
                {
                    newdnaInputChar[i - counter] = CharDnaStrand[i];
                }
                else
                {
                    counter++;
                }
            }

            counter = 0;
            emptycounter = 0;

            char[] MainDnaChar = new char[newdnaInputChar.Length + (newdnaInputChar.Length / 3)];

            //Adding Empty Spaces For Other Operations 
            for (int i = 0; i < newdnaInputChar.Length; i++)
            {
                if ((i + counter) % 4 == 3)
                {
                    MainDnaChar[i + counter] = ' ';
                    counter++;
                }

                MainDnaChar[i + counter] = newdnaInputChar[i];
            }

            for (int i = 0; i < MainDnaChar.Length; i++)
            {
                Console.Write(MainDnaChar[i]);
            }
            counter = 0;

            Console.SetOut(oldOut);
            Console.SetError(oldOut);

            streamWriter.Close();

            StreamReader f = File.OpenText("out.txt");
            dnaInput = f.ReadLine();
            f.Close();

            Console.Write(dnaInput);

            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 9 *

        private static void OperationNine()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }


            string Codon_sequence;
            Console.Write("Please enter your CODON sequence: "); // sonra try-cath veya if eklenebilir.
            Codon_sequence = (Console.ReadLine());
            Char[] Charcodon_sequence = Codon_sequence.ToCharArray();
            Char[] CharDnaStrandstage1 = dnaInput.ToCharArray();
            int Startcod1, InsertIndex1;
            Console.Write("Please enter that which codon do you want to start: ");
            Startcod1 = Convert.ToInt16(Console.ReadLine());
            InsertIndex1 = (Startcod1 - 1) * 4 - 1;

            var oldOut = Console.Out;

            using var fileStream = new FileStream("out.txt", FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);

            Console.SetOut(streamWriter);
            Console.SetError(streamWriter);
            for (int i = 0; i < CharDnaStrandstage1.Length; i++)
            {
                if (InsertIndex1 == i)
                {
                    for (int p = 0; p < Charcodon_sequence.Length; p++)
                    {
                        if (p == 0)
                        {
                            Console.Write(" " + Charcodon_sequence[p]);
                        }
                        else
                        {
                            Console.Write(Charcodon_sequence[p]);
                        }
                    }
                }
                Console.Write(CharDnaStrandstage1[i]);
            }
            Console.SetOut(oldOut);
            Console.SetError(oldOut);
            streamWriter.Close();

            StreamReader f = File.OpenText("out.txt");
            dnaInput = f.ReadLine();
            f.Close();

            Console.Write(dnaInput);
            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 10 *

        public static void OperationTen() // *** DOESN'T WORK -- WORK IN PROGRESS ***
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }


            string DnaStrand2 = "ATG ACT GAT GAG AGA TAT TGA";
            int deleteCnum2, StartInd2, Startcod2;
            String Dna_Sequence = "";
            //Console.Write("Please enter how many codon number that you want to add: ");
            // deleteCnum2 = Convert.ToInt16(Console.ReadLine());
            // Console.Write("Please enter that which codon do you want to start; ");
            // Startcod2 = Convert.ToInt16(Console.ReadLine());
            // Console.Write("Please enter your Dna sequence: ");
            int counter4 = 0;
            int DetermineIndex1;
            Dna_Sequence = "GAT GAG"; //Console.ReadLine();
            Char[] CharDna_Sequence = Dna_Sequence.ToCharArray();
            Char[] CharDnaStrand2 = DnaStrand2.ToCharArray();
            // Console.Write("Please enter that which codon do you want to start: ");
            Startcod2 = 2; //Convert.ToInt16(Console.ReadLine());
            DetermineIndex1 = (Startcod2 - 1) * 4;

            for (int i = 0; i < CharDna_Sequence.Length; i++)
            {
                for (int o = DetermineIndex1; o < CharDnaStrand2.Length; o++)
                {
                    if (CharDna_Sequence[i] == CharDnaStrand2[o])
                    {

                        break;
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 11 *

        private static void OperationEleven()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }

            var oldOut = Console.Out;
            using var fileStream = new FileStream("out.txt", FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);

            // Console.WriteLine(DnaStrand.Length);
            int deleteCnum3, StartInd3, Startcod3;
            Console.Write("Please enter how many codon number that you want to reverse: ");
            int ReversCnum3 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please enter that which codon do you want to start; ");
            Startcod3 = Convert.ToInt16(Console.ReadLine());
            Char[] CharDnaStrand3 = dnaInput.ToCharArray();
            //Console.WriteLine(CharDnaStrand.Length);
            int counter3 = 0;

            int StartIndex3 = (Startcod3 - 1) * 4;
            int StopIndex3 = (StartIndex3) + 2 + 4 * (ReversCnum3 - 1);
            int u = StopIndex3;

            Console.SetOut(streamWriter);
            Console.SetError(streamWriter);
            for (int x = StartIndex3; x <= StopIndex3; x++)
            {
                if (u == x)
                {
                    for (int w = StartIndex3; w <= StopIndex3; w += 4)
                    {
                        char c = CharDnaStrand3[w];
                        CharDnaStrand3[w] = CharDnaStrand3[w + 2];
                        CharDnaStrand3[w + 2] = c;
                    }
                    for (int i = 0; i < CharDnaStrand3.Length; i++)
                    {
                        Console.Write(CharDnaStrand3[i]);
                    }
                    break;
                }
                char z = CharDnaStrand3[x];
                CharDnaStrand3[x] = CharDnaStrand3[u];
                CharDnaStrand3[u] = z;
                u--;



            }
            Console.SetOut(oldOut);
            Console.SetError(oldOut);

            streamWriter.Close();

            StreamReader f = File.OpenText("out.txt");
            dnaInput = f.ReadLine();
            f.Close();

            Console.Write(dnaInput);

            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }

        // Operation 12 *

        private static void OperationTwelve()
        {
            if (string.IsNullOrEmpty(dnaInput))
            {
                Console.WriteLine("");
                Console.WriteLine("You must enter DNA Strand 1 (Main) first before proceeding to operation." + "\n" + "Press any key to return to main menu.");
                Console.WriteLine("");
                Console.ReadKey();
                MainMenu();
            }

            string DnaStrand5 = dnaInput;
            Char[] CharDnaStrand5 = DnaStrand5.ToCharArray();
            string startCodon = "ATG";
            string stopCodon = "TAATGATAG";
            Char[] CharstopCodon = stopCodon.ToCharArray();
            Char[] CharstartCodon = startCodon.ToCharArray();
            int counterstart = 0;
            int counterend = 0;
            for (int i = 0; i < (CharDnaStrand5.Length - 3); i++)
            {
                if (CharDnaStrand5[i] == CharstartCodon[0])
                {
                    if (CharDnaStrand5[i + 1] == CharstartCodon[1])
                    {
                        if (CharDnaStrand5[i + 2] == CharstartCodon[2])
                        {
                            counterstart++;
                        }
                    }
                }
            }
            for (int i = 3; i < (CharDnaStrand5.Length); i++)
            {
                if (CharDnaStrand5[i] == CharstopCodon[0])
                {
                    if (CharDnaStrand5[i + 1] == CharstopCodon[1])
                    {
                        if (CharDnaStrand5[i + 2] == CharstopCodon[2])
                        {
                            counterend++;
                        }

                    }
                }
                if (CharDnaStrand5[i] == CharstopCodon[3])
                {
                    if (CharDnaStrand5[i + 1] == CharstopCodon[4])
                    {
                        if (CharDnaStrand5[i + 2] == CharstopCodon[5])
                        {
                            counterend++;
                        }

                    }
                }
                if (CharDnaStrand5[i] == CharstopCodon[6])
                {
                    if (CharDnaStrand5[i + 1] == CharstopCodon[7])
                    {
                        if (CharDnaStrand5[i + 2] == CharstopCodon[8])
                        {
                            counterend++;
                        }

                    }
                }
            }
            if (counterend >= counterstart)
            {
                Console.WriteLine("Number of genes: " + counterstart);
            }
            else if (counterstart > counterend)
            {
                Console.WriteLine("Number of genes" + counterend);
            }

            Console.WriteLine("");
            Console.WriteLine("\n" + "Press any key to return to main menu.");
            Console.ReadKey();
        }


        // Operation 13 *
        private static void OperationThirteen()
        {

            string DNA_Strand_5 = dnaInput;
            Char[] CharDNA_Strand_5 = DNA_Strand_5.ToCharArray();

            //ASSIGMENTS
            string start_Codon = "ATG";

            Char[] char_start_Codon = start_Codon.ToCharArray();

            string stop_Codon_1 = "TAA";
            string stop_Codon_2 = "TGA";
            string stop_Codon_3 = "TAG";

            char[] char_stop_Codon_1 = stop_Codon_1.ToCharArray();
            char[] char_stop_Codon_2 = stop_Codon_2.ToCharArray();
            char[] char_stop_Codon_3 = stop_Codon_3.ToCharArray();

            // CONTROL
            Console.WriteLine();

            //asd
            int start_codon_size = start_Codon.Length;

            int[] starting_index = new int[20];
            int start_index_counter = 0;
            int[] ending_index = new int[20];
            int ending_index_counter = 0;

            // keeps starting indexes
            for (int i = 0; i <= (CharDNA_Strand_5.Length - start_codon_size); i++)
            {
                int check_counter = 0;
                // controlling similarity
                for (int k = 0; k < start_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_start_Codon[k])
                    {
                        check_counter++;
                    }
                }

                //if control size equals codon size, add the index
                if (check_counter == start_codon_size)
                {
                    starting_index[start_index_counter] = i;
                    start_index_counter++;
                }

            }

            int stop_codon_size = stop_Codon_1.Length;

            // keeps ending indexes
            for (int i = start_codon_size; i <= (CharDNA_Strand_5.Length - stop_codon_size); i++)
            {
                int stop_counter_1 = 0;
                int stop_counter_2 = 0;
                int stop_counter_3 = 0;

                // controlling similarity
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_1[k])
                    {
                        stop_counter_1++;
                    }
                }
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_2[k])
                    {
                        stop_counter_2++;
                    }
                }
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_3[k])
                    {
                        stop_counter_3++;
                    }
                }
                //if control size equals codon size, add the index
                if (stop_counter_1 == stop_codon_size || stop_counter_2 == stop_codon_size || stop_counter_3 == stop_codon_size)
                {
                    ending_index[ending_index_counter] = i;
                    ending_index_counter++;
                }
            }

            int codon_num = start_index_counter; //or ending_index_counter

            int[] codon_sizes = new int[codon_num];

            for (int i = 0; i < codon_num; i++)
            {
                codon_sizes[i] = ending_index[i] - starting_index[i];
            }

            int max = -1;
            int min = 999999;

            for (int i = 0; i < codon_sizes.Length; i++)
            {
                if (codon_sizes[i] >= max)
                {
                    max = codon_sizes[i];
                }

                if (codon_sizes[i] <= min)
                {
                    min = codon_sizes[i];
                }
            }
            for (int i = 0; i < codon_sizes.Length; i++)
            {
                if (min == codon_sizes[i])
                {
                    char[] min_contet = new char[codon_sizes[i] + 3];
                    int counter = 0;
                    int start_position = starting_index[i];
                    int end_position = ending_index[i] + 3;
                    for (int k = start_position; k < end_position; k++)
                    {
                        min_contet[counter] = CharDNA_Strand_5[k];
                        counter++;
                    }
                    int mix_content_size = min_contet.Length + 1;
                    double codon_number = mix_content_size / 4;
                    Console.Write("The Gen:\t\t\t");
                    Console.WriteLine(min_contet);
                    Console.WriteLine("Codon number of the Gen:\t" + codon_number);
                    int starting_codon_num = (starting_index[i] + 1 + 4) / 4;
                    Console.WriteLine("The Starting Codon:\t\t" + starting_codon_num);
                    Console.WriteLine();
                }

            }
            Console.ReadLine();
        }


        // Operation 14 *
        private static void OperationFourteen()
        {
            string DNA_Strand_5 = dnaInput;
            Char[] CharDNA_Strand_5 = DNA_Strand_5.ToCharArray();

            //ASSIGMENTS
            string start_Codon = "ATG";

            Char[] char_start_Codon = start_Codon.ToCharArray();

            string stop_Codon_1 = "TAA";
            string stop_Codon_2 = "TGA";
            string stop_Codon_3 = "TAG";

            char[] char_stop_Codon_1 = stop_Codon_1.ToCharArray();
            char[] char_stop_Codon_2 = stop_Codon_2.ToCharArray();
            char[] char_stop_Codon_3 = stop_Codon_3.ToCharArray();

            // CONTROL
            Console.WriteLine();

            //asd
            int start_codon_size = start_Codon.Length;

            int[] starting_index = new int[20];
            int start_index_counter = 0;
            int[] ending_index = new int[20];
            int ending_index_counter = 0;

            // keeps starting indexes
            for (int i = 0; i <= (CharDNA_Strand_5.Length - start_codon_size); i++)
            {
                int check_counter = 0;
                // controlling similarity
                for (int k = 0; k < start_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_start_Codon[k])
                    {
                        check_counter++;
                    }
                }

                //if control size equals codon size, add the index
                if (check_counter == start_codon_size)
                {
                    starting_index[start_index_counter] = i;
                    start_index_counter++;
                }

            }

            int stop_codon_size = stop_Codon_1.Length;

            // keeps ending indexes
            for (int i = start_codon_size; i <= (CharDNA_Strand_5.Length - stop_codon_size); i++)
            {
                int stop_counter_1 = 0;
                int stop_counter_2 = 0;
                int stop_counter_3 = 0;

                // controlling similarity
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_1[k])
                    {
                        stop_counter_1++;
                    }
                }
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_2[k])
                    {
                        stop_counter_2++;
                    }
                }
                for (int k = 0; k < stop_codon_size; k++)
                {
                    if (CharDNA_Strand_5[i + k] == char_stop_Codon_3[k])
                    {
                        stop_counter_3++;
                    }
                }
                //if control size equals codon size, add the index
                if (stop_counter_1 == stop_codon_size || stop_counter_2 == stop_codon_size || stop_counter_3 == stop_codon_size)
                {
                    ending_index[ending_index_counter] = i;
                    ending_index_counter++;
                }
            }

            int codon_num = start_index_counter; //or ending_index_counter

            int[] codon_sizes = new int[codon_num];

            for (int i = 0; i < codon_num; i++)
            {
                codon_sizes[i] = ending_index[i] - starting_index[i];
            }

            int max = -1;
            int min = 999999;

            for (int i = 0; i < codon_sizes.Length; i++)
            {
                if (codon_sizes[i] >= max)
                {
                    max = codon_sizes[i];
                }

                if (codon_sizes[i] <= min)
                {
                    min = codon_sizes[i];
                }
            }
            for (int i = 0; i < codon_sizes.Length; i++)
            {
                if (max == codon_sizes[i])
                {
                    char[] max_contet = new char[codon_sizes[i] + 3];
                    int counter = 0;
                    int start_position = starting_index[i];
                    int end_position = ending_index[i] + 3;

                    for (int k = start_position; k < end_position; k++)
                    {
                        max_contet[counter] = CharDNA_Strand_5[k];
                        counter++;
                    }
                    int max_content_size = max_contet.Length + 1;
                    double codon_number = max_content_size / 4;
                    Console.Write("The Gen:\t\t\t");
                    Console.WriteLine(max_contet);
                    Console.WriteLine("Codon number of the Gen:\t" + codon_number);
                    int starting_codon_num = (starting_index[i] + 1 + 4) / 4;
                    Console.WriteLine("The Starting Codon:\t\t" + starting_codon_num);
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

    }
}
