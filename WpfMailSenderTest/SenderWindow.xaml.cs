using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Net.Mail;

namespace WpfMailSenderTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SenderWindow : Window
    {
        public SenderWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "ng@gmail.com", "email@yandex.ru" };

            string strPassword = passwordBox.Password;
            string tltMail = titleMail.Text;
            string txtMail = textMail.Text;

            foreach (string mail in listStrMails)
            {
                using (MailMessage mm = new MailMessage("ng@gmail.com", mail))
                {
                    mm.Subject = tltMail;
                    mm.Body = txtMail;
                    mm.IsBodyHtml = false; // Not use html in mail body

                    using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 58))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("ng@gmail.com", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            SendEnd sew = new SendEnd();
            sew.ShowDialog();
        }
    }
}
