using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net;
using Windows.ApplicationModel.Email;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel.Contacts;
using System.Diagnostics.Contracts;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestMailSender
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPage rootPage = MainPage.Current;
        public MainPage()
        {
            this.InitializeComponent();
        }
        

        private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
                 string messageBody, StorageFile attachmentFile)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            if (attachmentFile != null)
            {
                var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

                var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                    attachmentFile.Name,
                    stream);

                emailMessage.Attachments.Add(attachment);
            }

            var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            if (email != null)
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
                emailMessage.To.Add(emailRecipient);
            }

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);

        }

        public IList<Contact> contacts;


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            contactPicker.CommitButtonText = "Select";
            contacts = await contactPicker.PickContactsAsync();

            // Clear the ListView.
            OutputContacts.Items.Clear();

            if (contacts != null && contacts.Count > 0)
            {
                OutputContacts.Visibility = Windows.UI.Xaml.Visibility.Visible;
                OutputEmpty.Visibility = Visibility.Collapsed;

                foreach (Contact contact in contacts)
                {
                    // Add the contacts to the ListView.
                    OutputContacts.Items.Add(new ContactItemAdapter(contact));
                }
            }
            else
            {
                OutputEmpty.Visibility = Visibility.Visible;
            }


        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
