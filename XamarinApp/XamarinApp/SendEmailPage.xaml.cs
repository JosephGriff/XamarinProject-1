using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Text.RegularExpressions;

namespace XamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendEmailPage : ContentPage
	{
        private bool email, subject, body;

		public SendEmailPage ()
		{
			InitializeComponent ();
            setDefaultValues();
		}

        //set default values
        private void setDefaultValues()
        {
            email = subject = body = false;
            sendEmail.IsEnabled = false;
        }


        private async void SendEmail_Clicked(object sender, EventArgs e)
        {
            //add email address
            List<String> addresses = new List<string>();
            addresses.Add(emailAddress.Text);

            //call send email method
            await sendEmailAsync(emailSubject.Text, emailBody.Text, addresses);

            //pop page
            await Navigation.PopAsync();

        }

        //send email method
        private async Task sendEmailAsync(string subject, string body, List<String> address)
        {
            try
            {
                //compose new email message

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = address,
                };
                await Email.ComposeAsync(message);

                
            }
            catch(Exception ex)
            {
                //catch exception error
                emailError.Text = "Error Something went wrong!!! Try again Later...";
                emailError.TextColor = Color.Red;
                emailError.FontAttributes = FontAttributes.Bold;
                return;
            }
        }

        //cancel email operation
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void EmailAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check for empty email
            if(emailAddress.Text == "" || emailAddress.Text == null)
            {
                emailError.Text = "Email Address Field Required";
                emailError.TextColor = Color.Red;
                emailError.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                emailError.Text = "";
            }

            //check for valid email
            if (!isValidEmail(emailAddress.Text))
            {
                email = false;
                emailError.Text = "Not a valid Email Address";
                emailError.TextColor = Color.Red;
                emailError.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                emailError.Text = "Valid Address";
                emailError.TextColor = Color.Green;
                emailError.FontAttributes = FontAttributes.Bold;
                email = true;
            }

            //check all fields valid
            if(email && body && subject)
            {
                sendEmail.IsEnabled = true;
            }
            else
            {
                sendEmail.IsEnabled = false;
            }
      

        }

        private void EmailSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check for empty email subject
            if (emailSubject.Text == "" || emailSubject.Text == null)
            {
                subject = false;
                subjectError.Text = "Subject is Field Required";
                subjectError.TextColor = Color.Red;
                subjectError.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                subjectError.Text = "";
                subject = true;
            }

            //check all fields valid
            if (email && body && subject)
            {
                sendEmail.IsEnabled = true;
            }
            else
            {
                sendEmail.IsEnabled = false;
            }
        }

        private void EmailBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check email body populated
            if (emailBody.Text == "" || emailBody.Text == null)
            {
                body = false;
                bodyError.Text = "Body Field is Required";
                bodyError.TextColor = Color.Red;
                bodyError.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                bodyError.Text = "";
                body = true;
            }

            //check all fields valid
            if (email && body && subject)
            {
                sendEmail.IsEnabled = true;
            }
            else
            {
                sendEmail.IsEnabled = false;
            }
        }

        //validate email string
        private bool isValidEmail(string email)
        {
            //check regular expression
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            return isEmail;
        }
    }
}