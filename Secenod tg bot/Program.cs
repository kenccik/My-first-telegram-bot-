using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;

string token = "6437479601:AAGYXqj0M7u9EKKEXRm2mYhXmDlytU7Ubd8";

TelegramBotClient client = new TelegramBotClient(token);

client.StartReceiving(
    updateHandler: (client, update, token) => GetUpdate(update),
    (client, error, token) => Task.CompletedTask);

async Task GetUpdate(Update update)
{
    if (update.Message is not null)
    {
        var text = update.Message.Text;
        
        var chatId = update.Message.Chat.Id;

        


        Console.WriteLine(text);

       if (text.ToLower().Contains("/start"))
        {
            client.SendTextMessageAsync(chatId, "Bu bot o'yin uchun qilingan.1 dan 50 gacha sonni kiriting, agar son random sondan katta bo'lsa bot " +
                "pastga deydi, agar kichkina bo'lsa  tepaga deydi.");

        }


        else if (int.TryParse(text, out int userGuess))
        {
            Random rand = new Random();
            int min = 1;
            int max = 51;
            int random = rand.Next(min, max);

            string message;
            if (userGuess < random)
            {
                message = " Tepaga ";
            }
            else if (userGuess > random)
            {
                message = " Pastga ";
            }
            else
            {
                message = $"Tabriklaymiz! Siz {random} sonini topdingiz!";
            }

            await client.SendTextMessageAsync(chatId, message);
        }


    }
}
Console.ReadKey();