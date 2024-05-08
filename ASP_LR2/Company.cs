namespace ASP_LR2
{
    public class Company
    {
        public string name { get; set; } = "";
        public int humans { get; set; } = 0;

        public static string GetCompanyWithMaxHumans(params Company[] companies)
        {
            if (companies == null || companies.Length == 0)
                throw new ArgumentException("Вкажіть один об'єкт компанії");

            int maxHumans = companies[0].humans;
            string companyName = companies[0].name;

            for (int i = 1; i < companies.Length; i++)
            {
                if (companies[i].humans > maxHumans)
                {
                    maxHumans = companies[i].humans;
                    companyName = companies[i].name;
                }
            }

            return companyName;
        }
    }
}
