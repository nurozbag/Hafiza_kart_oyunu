namespace hafizakartoyunu {
    public partial class Form1 : Form
    {
        Image[] resimler =
        {
            Properties.Resources.astroid,
            Properties.Resources.cat1,
            Properties.Resources.cat2,
            Properties.Resources.emily,
            Properties.Resources.flower,
            Properties.Resources.moon,
            Properties.Resources.stars_icon,
            Properties.Resources.ufo,

        };

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        PictureBox ilkkutu;
        int ilkindeks, bulunan, deneme;

        int time = 600;
        int puan = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            resimlerikaristir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            time = 60;
            resimlerikaristir();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time < 0)
            {
                timer1.Stop();
                MessageBox.Show("Zaman bitti");
                label3.Text = "00.00";
                bulunan = 0;
                deneme = 0;

            }
            label3.Text = "00:" + time.ToString();
        }
        private void tebrikmsj()
        {



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void resimlerikaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;


            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuno = int.Parse(kutu.Name.Substring(10)) - 1;
            kutu.Image = resimler[indeksler[kutuno]];
            int indeksno = indeksler[kutuno];
            kutu.Image = resimler[indeksno];
            kutu.Refresh();

            if (ilkkutu == null)
            {

                ilkkutu = kutu;
                ilkindeks = indeksno;
                deneme++;
                label5.Text = deneme.ToString();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;
                if (ilkindeks == indeksno)
                {
                    bulunan++;
                    MessageBox.Show("bir cift buldunuz", "tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);
                    label2.Text = bulunan.ToString();
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    puan = bulunan * 10;
                    label7.Text = puan.ToString();
                    



                    if (bulunan == 8)
                    {

                        MessageBox.Show("Tebrikler" + " " + deneme + "denemede buldunuz.");


                        bulunan = 0;
                        deneme = 0;

                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimlerikaristir();


                    }
                }
                ilkkutu = null;
            }

        }
        

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
        


      



    
}





}
