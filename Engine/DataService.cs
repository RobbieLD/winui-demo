using System.Data;

namespace Engine
{
    public class DataService
    {
        private static DataService? instance;

        private readonly DataTable Data = new();

        public static DataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataService();
                }

                return instance;
            }
        }

        public DataRowCollection Rows
        {
            get
            {
                return Data.Rows;
            }
        }

        private DataService()
        {
            Data.Columns.Add("IsError");
            Data.Columns.Add("Value");

            RefreshData(5);
        }

        public void RefreshData(int rows)
        {
            Data.Rows.Clear();
            var random = new Random();

            for (int i = 0; i < rows; i++)
            {
                var isError = random.NextDouble() >= 0.8;
                Data.Rows.Add(random.Next(1, 255), isError);
            }
        }
    }
}