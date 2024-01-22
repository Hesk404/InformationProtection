using Cryptography.Cipher;
using Cryptography.Hash;
using Cryptography.Models;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace ClientForm
{
    public partial class Client : Form
    {
        private Rsa rsa;

        public Client()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
        }

        private void ClearAllTextBoxes()
        {
            textBox_p.Text = "";
            textBox_q.Text = "";

            textBox_n.Text = "";

            textBox_fi.Text = "";

            textBox_e.Text = "";

            textBox_d.Text = "";


            textBox_publicKey.Text = "";

            textBox_secretKey.Text = "";

            textBox_hash.Text = "";
            textBox_sig.Text = "";
            textBox_sigDecipher.Text = "";
        }

        private void button_generateKeys_Click(object sender, EventArgs e)
        {
            rsa = new Rsa();

            ClearAllTextBoxes();

            textBox_p.Text = rsa.p.ToString();
            textBox_q.Text = rsa.q.ToString();

            textBox_n.Text = rsa.n.ToString();

            textBox_fi.Text = rsa.eilerFunction.ToString();

            textBox_e.Text = rsa.e.ToString();

            textBox_d.Text = rsa.d.ToString();

            textBox_publicKey.Text = rsa.publicKey.ToString();

            textBox_secretKey.Text = rsa.secretKey.ToString();

        }

        private void button_loadKeys_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "�������� ��������� ����";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string openKey_file = openFileDialog1.FileName;

            List<string> openKey_numbers = File.ReadAllLines(openKey_file).ToList();

            if (openKey_numbers.Count != 2)
            {
                MessageBox.Show("� ����� ��������� ����� ������ ���� 2 ������!", "������");
                return;
            }

            openFileDialog1.Title = "�������� �������� ����";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string secretKey_file = openFileDialog1.FileName;

            List<string> secretKey_numbers = File.ReadAllLines(secretKey_file).ToList();

            if (secretKey_numbers.Count != 2)
            {
                MessageBox.Show("� ����� ��������� ����� ������ ���� 2 ������!", "������");
                return;
            }

            try
            {
                rsa = new Rsa(new Key { First = BigInteger.Parse(openKey_numbers[0]), Second = BigInteger.Parse(openKey_numbers[1]) }, new Key { First = BigInteger.Parse(secretKey_numbers[0]), Second = BigInteger.Parse(secretKey_numbers[1]) });
            }
            catch (Exception ex) { MessageBox.Show("�� ������� ���������������� ����� �� ��������� ������. ��������� ������������ ������."); }

            ClearAllTextBoxes();

            textBox_publicKey.Text = rsa.publicKey.ToString();

            textBox_secretKey.Text = rsa.secretKey.ToString();
        }

        private void button_sigFile_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("������� ��������� ���������������� �����!", "������");
                return;
            }

            openFileDialog1.Title = "�������� ����, ������� ����� ���������";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string text = File.ReadAllText(openFileDialog1.FileName);

            Sha256 sha256 = new Sha256();

            var hash = Convert.ToHexString(sha256.ComputeHash(text));

            textBox_hash.Text = hash;

            string sig = rsa.Cipher(hash);

            textBox_sig.Text = sig;

            textBox_sigDecipher.Text = "";

            saveFileDialog1.Title = "���������� �������";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            File.WriteAllText(saveFileDialog1.FileName, sig);

        }

        private void button_checkSig_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("������� ��������� ���������������� �����!", "������");
                return;
            }

            Sha256 sha256 = new Sha256();

            openFileDialog1.Title = "�������� ����������� ����";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string text = File.ReadAllText(openFileDialog1.FileName);

            openFileDialog1.Title = "�������� ���� �������";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string sig = File.ReadAllText(openFileDialog1.FileName);

            var hash = Convert.ToHexString(sha256.ComputeHash(text));

            var decipherSig = rsa.Decipher(sig);

            if (hash == decipherSig)
            {
                textBox_hash.Text = hash;
                textBox_sig.Text = sig;
                textBox_sigDecipher.Text = decipherSig;
                MessageBox.Show("������� �����!", "�����");
            }
            else
            {
                textBox_hash.Text = hash;
                textBox_sig.Text = sig;
                textBox_sigDecipher.Text = decipherSig;
                MessageBox.Show("������� �� �����!", "������");
            }


        }

        private void button_saveKeys_Click(object sender, EventArgs e)
        {
            if(textBox_publicKey.Text == "" || textBox_secretKey.Text == "" || rsa == null)
            {
                MessageBox.Show("������� ��������� ���������������� �����!", "������");
                return;
            }


            saveFileDialog1.Title = "��������� ��������� ����";
            if(saveFileDialog1.ShowDialog() == DialogResult.Cancel) 
                return;

            string key = $"{rsa.publicKey.First.ToString()}\r\n{rsa.publicKey.Second.ToString()}";
            File.WriteAllText(saveFileDialog1.FileName, key);

            saveFileDialog1.Title = "��������� �������� ����";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            key = $"{rsa.secretKey.First.ToString()}\r\n{rsa.secretKey.Second.ToString()}";
            File.WriteAllText(saveFileDialog1.FileName, key);
        }
    }
}