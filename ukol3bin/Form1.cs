using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ukol3bin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"..\..\texty.dat"))
            {
                StreamReader ctenar = new StreamReader(@"..\..\texty.dat");
                while (!ctenar.EndOfStream)
                {
                    listBox1.Items.Add(ctenar.ReadLine());
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\texty2.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                char[] radek = textBox1.Lines[i].ToCharArray();

                for (int y = 0; y < radek.Length; y++)
                {
                    if (radek[y] == '.')
                    {
                        radek[y] = '!';
                    }

                }
            }
            bw.Close();
            fs.Close();
        }
    }
}
/*Na disku je binární soubor texty.dat obsahující řetězce. Každý řetězec obsahuje věty
ukončené tečkou. Opravte soubor texty.dat tak, aby všechny věty v jednotlivých řetězcích
končily místo tečky znakem vykřičník. (Předpokládejte, že jiné tečky, než na konci vět se
v řetězcích nevyskytují.) Původní i opravený soubor zobrazte.
*/