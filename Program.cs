namespace ConsoleApp8
{
    internal class Program
    {
        static void Main()
        {
            // Загрузка данных из Excel
            ExcelDataLoader loader = new ExcelDataLoader();
            List<Outfit> outfits = loader.LoadOutfitsFromExcel("OutfitsDatabase.xlsx");

            // Создание и заполнение дерева
            OutfitTree tree = new OutfitTree();
            foreach (var outfit in outfits)
            {
                tree.Add(outfit);
            }

            Console.WriteLine("Дерево до балансировки:");
            tree.PrintInOrder(tree.Root);

            // Балансировка дерева
            tree.Balance();

            Console.WriteLine("\nДерево после балансировки:");
            tree.PrintInOrder(tree.Root);
        }
    }
}
