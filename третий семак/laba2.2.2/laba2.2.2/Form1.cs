using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;


namespace laba2._2._2
{
    public partial class IzolHran : Form
    {
        public IzolHran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dan = textBox2.Text;

            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            //Класс IsolatedStorageFileStream
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("Вася.txt", FileMode.Create, userStore);
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine(dan);
            userWriter.Close();
            //чтение
            /*
            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("No data saved for this user");
            }
            else
            {
                userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore);
                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);

            }*/
        }
    }
}
