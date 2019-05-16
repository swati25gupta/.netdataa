using SampleWinApp.Models;
using SampleWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for DatabaseProgram.xaml
    /// </summary>
    public partial class DatabaseProgram : Window
    {
        static DataTable tableOfRecords = null;
        public DatabaseProgram()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            tableOfRecords = new DataComponent().GetAllEmployees();
            List<Employee> employees = new List<Employee>();
            foreach(DataRow row in tableOfRecords.Rows)
            {
                var emp = new Employee
                {
                    EmpID = Convert.ToInt32(row[0]),
                    EmpName = row[1].ToString(),
                    EmpAddress = row[2].ToString(),
                    EmpSalary = Convert.ToDouble(row[3])
                };
                employees.Add(emp);
            }
            grdContent.DataContext = employees;

        }
    }
}
