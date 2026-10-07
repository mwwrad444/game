using System;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        int num;
        int cehdSayi = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void yenioyunbtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            num = r.Next(0, 101);

            cehdSayi = 0;
            errorProvider1.Clear();
            textBox1.Clear();
            richTextBox1.Clear();

            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Axtarılan ədəd xanası boş ola bilməz!");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            int daxilEdilen;
            if (!int.TryParse(textBox1.Text, out daxilEdilen))
            {
                errorProvider1.SetError(textBox1, "Zəhmət olmasa düzgün ədəd daxil edin!");
                return;
            }

            cehdSayi++;

            if (daxilEdilen == num)
            {
                richTextBox1.Text = $"Oyunu qazandınız!\nCəhd sayı: {cehdSayi}";
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            else if (daxilEdilen < num)
            {
                richTextBox1.Text = $"Siz yanlış tapdınız!\nCəhd sayı: {cehdSayi}\nDaxil etdiyiniz ədəd gizli ədəddən kiçikdir.";
            }
            else
            {
                richTextBox1.Text = $"Siz yanlış tapdınız!\nCəhd sayı: {cehdSayi}\nDaxil etdiyiniz ədəd gizli ədəddən böyükdür.";
            }
        }

        // Tıklama hatasını engelleyen kısım
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}