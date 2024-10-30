using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 8;
        int gravity = 9;
        int score = 0;
        Random rnd = new Random();

       /*  sınıf genelinde tam sayı dğerinde 3 değişken tanımladık bunlar : pipepSpeed >> boruların gelme hızı 
        *                                                                   gravity >> yerçekimi, kuşun yükselme ve alçalma hızı
        *                                                                   score >> engelleri geçtikçe artacak oyun puanımız.
        */

        public Form1()
        {
            InitializeComponent();
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;        // kuşun dikey konumunu gravitye göre değişimini saglıyoruz.
            pipebottom.Left -= pipeSpeed;     // alt engelin hızını pipeSpeede eşitleyip sola kaydırır.
            pipeTop.Left -= pipeSpeed;        // üst engelin hızını pipeSpeede eşitleyip sola kaydırır.  
            scoreText.Text = " score : " + score;  // ekrandaki score tablosuna ' score : (puan durumu) ' yazdırır.

            if (pipebottom.Left < -150) // eğer alt boru ekranın solundan çıkarsa 
            {
                pipebottom.Left = 800; // yeni boru sağ taraftan verilen değerden çıkar
                pipebottom.Height = rnd.Next(230, 400); // boyunu random değerleri arasında verilen sayılar arasında çıkar.
                score++;     // scoru bir arttır.          
            }


            if (pipeTop.Left < -180) // eğer üst boru ekranın saolundan çıkarsa
            {
                pipeTop.Left = 950; // yeni boru sağ taraftan verilen değerden çıkar
                pipeTop.Height = rnd.Next(230, 450);  // boyunu random değerleri arasında verilen sayılar arasında çıkar.
                score++;  // scoru bir arttır.   
            }

            if (flappyBird.Bounds.IntersectsWith(pipebottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || 
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -10 
                )

             /* eğer kuşun bulunduğu konum ile alt engel bir olursa
                 * veya kuşun konumu ile üst engel bir olursa 
                 * veya kuşun konumu ile yer engeli bir olursa
                 * veya kuşun konumu ile üst sınır bir olursa
             */
            {
                endGame();
            }
            // endGame metodunu çalıştır.
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // eğer oyuncu Space tuşuna basarsa 
            if (e.KeyCode== Keys.Space)
            {
                gravity = -10;
            }
            // yerçelimim yukarı doğru olur , kuşun yukarıya hareket eder.


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // eğer oyuncu Space tuşuna basmazsa
            if (e.KeyCode == Keys.Space)
            {
                gravity = 9;
            }
            // kuşun yere düşme hızı 9 olur.
        }

        private void endGame() // endGame metodu oluşturuldu.
        {
            gameTimer.Stop(); // zamanlayıcı durdur.
            scoreText.Text += " Game Over "; // ekrana ' Game Over ' yazısını yaz.
        }
    }
}
