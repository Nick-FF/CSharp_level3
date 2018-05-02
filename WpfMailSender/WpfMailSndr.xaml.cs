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
using System.Net;
using System.Net.Mail;

namespace WpfMailSender
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MailSenderWindow : Window
    {
        public MailSenderWindow()
        {
            InitializeComponent();
        }
        List<string> listStrMails = new List<string> { "testEmail@gmail.com", " email@yandex.ru" };
       
        string strPassword = passwordBox

        foreach (string mail in listStrMails)
         {
                using (MailMessage mm = new MailMessage(WpfMailSender @yandex.ru, mail))
                {
                     mm.Subject ="Привет из С#";
                    mm.Body= "Hello Warld";
                    mm.IsBodyHtml = false;

                        using (SmtpClient sc=new NetworkCasltndar;
                        {
                          sc.EnableSsl = true; 
                        sc.Credentials = new NetworkCredential("sender@yandex.ru", strPassword);
                                  try  
                                         {
                                    sc.Send(mm);
                                     }
                                        catch (Exception ex)            
                                    {
                                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                                         }         
                        }    
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail)) } MessageBox.Show("Работа завершена."); 
    }
}
