using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using MarketPlace.Models;

namespace MarketPlace.ViewModels
{
    public class MessagesViewModel:BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }
        
        public Command LoadChat { get; set; }
        public Command UpdateChat { get; set; }
        public Command SendMessage { get; set; }
        int Sender;
        int Reciever;
        int LastMessage;
        UserInfo User;
        string TitleM;
        public CancellationTokenSource CancellationSource { get; set; }
        public CancellationToken Token { get; set; }

        

        public MessagesViewModel(int sender, int reciever, UserInfo user, string title)
        {
            this.Sender = sender;
            this.Reciever = reciever;
            this.User = user;
            this.TitleM = title;
            CancellationSource = new CancellationTokenSource();
            Token = CancellationSource.Token;
            Messages = new ObservableCollection<Message>();
            LoadChat = new Command(() =>
            {
                IsBusy = true;
                Task.Run(async () =>
                {
                    Messages.Clear();
                    var resp = await Http.GetRequest<Chat>($"chat?chat_id={TitleM}", true);
                    if (resp != null)
                    {
                        foreach (var message in resp.Messages)
                        {
                            Device.BeginInvokeOnMainThread(() => Messages.Add(message));
                            LastMessage = message.ID;
                        }
                        IsBusy = false;
                        UpdateChat.Execute(null);
                        Title = resp.Name;
                    }
                });
            });
            UpdateChat = new Command(async () =>
            {
                while (true)
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        await Task.Run(async () =>
                        {
                            if (!Token.IsCancellationRequested)
                            {
                                var resp = await Http.GetRequest<Chat>($"chat?chat_id={TitleM}&cid={LastMessage}", true);
                                if (resp != null)
                                {
                                    foreach (var message in resp.Messages)
                                    {
                                        Device.BeginInvokeOnMainThread(() => Messages.Add(message));
                                        LastMessage = message.ID;
                                    }
                                    if (resp.Messages.Count > 0)
                                        foreach (var message in this.Messages)
                                        {
                                            message.WasRead = 1;
                                        }
                                }
                            }
                           
                                
                        }, Token);
                    }
                    catch
                    {

                    }
                    
                }
            });

            SendMessage = new Command<string>((message) =>
            {
                Messages.Add(new Message(User.Name, User.Surname, User.Avatar, message));
                Task.Run(async () =>
                {
                    var resp = await Http.GetRequest<Chat>($"chat?chat_id={TitleM}&action=add&text={message}&cid={LastMessage}", true);
                    if (resp != null)
                    {
                        foreach (var msg in resp.Messages)
                        {
                            LastMessage = msg.ID;
                        }
                    }
                });
            });
        }
    }
}
