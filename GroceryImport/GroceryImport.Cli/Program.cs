using System;
using System.Collections.Generic;
using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;

namespace GroceryImport.Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Quick Arg Checking
            if (NoArgs(args)) return;
            if (DisplayHelp(args)) return;

            //I like to the main pretty clean and move the work into another class.
            new RunMe().Run(args[0]);

            Console.WriteLine("Records Processed");
            Console.WriteLine("Hit Enter to exit...");
            Console.ReadLine();
        }

        private static bool NoArgs(IReadOnlyCollection<string> args)
        {
            if (args != null && args.Count != 0) return false;

            Console.WriteLine("use --help for usage");
            return true;
        }

        private static bool DisplayHelp(IReadOnlyList<string> args)
        {
            
            if (args[0] != "-?" && args[0] != "-h" && args[0] != "--help") return false;

            Console.WriteLine("TODO: Display Real Help Text");
            Console.WriteLine("Quick Usage:");
            Console.WriteLine("<program> [absolute_file_path|relative_file_path]");
            return true;
        }
    }

    public sealed class RunMe
    {
        public int Run(string filePath)
        {
            ProductRecordCollection productRecordCollection = new TraderFoods404ProductRecordCollection(filePath);

            foreach (ProductRecord productRecord in productRecordCollection)
            {
                //Quick impl to show processing happened.
                Console.WriteLine(Printable(productRecord));
            }

            return 0;
        }

        public string Printable(ProductRecord productRecord)
        {
            return $"{productRecord.CompanyId()} | {productRecord.StoreId()} | {productRecord.ProductId()}" +
                   $" | {productRecord.ProductDescription()}" +
                   RegularToString(productRecord) +
                   PromotionalToString(productRecord) +
                   $" | {productRecord.TaxRate()} | {productRecord.UnitOfMeasure()} | {productRecord.ProductSize()}" +
                   $" | {productRecord.IsPromotional()} | {productRecord.IsRegular()}";
        }

        private string RegularToString(ProductRecord productRecord) => productRecord.IsRegular() ? $" | {productRecord.RegularDisplayPrice()} | {productRecord.RegularCalculatorPrice()}" : " | |";
        private string PromotionalToString(ProductRecord productRecord) => productRecord.IsPromotional() ? $" | {productRecord.PromotionalDisplayPrice()} | {productRecord.PromotionalCalculatorPrice()}" : " | |";
    }
}
