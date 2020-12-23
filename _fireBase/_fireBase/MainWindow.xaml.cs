using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _fireBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void firebaseBtn_Click(object sender, RoutedEventArgs e)
        {
            IFirebaseConfig config = new FirebaseConfig { AuthSecret = "aJz6mI2uIwjeRAIOoG9kqTZwmQ2F3AEOZZ9AWUGv", BasePath = "https://keepit-8a486.firebaseio.com/" };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = await client.GetAsync("name");
            string name = response.ResultAs<string>();
            MessageBox.Show(name);
            setDatatoFirebase(client);
        }
        private async void setDatatoFirebase(IFirebaseClient client)
        {
            var Customer = new Customer
            {
                name = "x",
                lastName = "y",
                age = 11
            };
            SetResponse response = await client.SetAsync("customer/set", Customer);
            Customer cus_ = response.ResultAs<Customer>();
            MessageBox.Show(cus_.name);
        }
    }
}
