using PPM.Domain;

namespace PPM.Ui.Consoles
{
    public class SaveData
    {
        public void SavedData()
        {
            SaveRepo saveRepo = new SaveRepo();
            saveRepo.Save();
            
            System.Console.WriteLine("Data saved to files");
        }
    }
}