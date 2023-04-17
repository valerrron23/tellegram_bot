
using Microsoft.VisualBasic;
using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    static ITelegramBotClient bot = new TelegramBotClient("****");

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

        String message = update.Message.Text;
        String selfName = update.Message.Chat.FirstName;
        long chatId = update.Message.Chat.Id;

        Boolean isFind = false;
        if (message.Equals("/start") || message.ToLower().Equals("главное меню"))
        {
            ReplyKeyboardMarkup Start = new(new[]
                  {
                    new KeyboardButton[] { "здравствуйте" },
                    new KeyboardButton[] { "обо мне" },
                    new KeyboardButton[] { "прайс лист" },
                    new KeyboardButton[] { "мы находимся" },
                    new KeyboardButton[] { "досвидания" },
                    
                });


            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Здравствуйте! Меня зовут Валерия и я ваш косметолог.",
               replyMarkup: Start
           );
        }

        if (message.ToLower().Contains("здравствуйте"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "На какую процедуры вы бы хотели записаться?"
           );
        }

        if (message.ToLower().Contains("досвидания"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Всегда пожалуйста. Обращайтесь!"
           );
        }

        if (message.ToLower().Contains("прайс лист"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("l:\\price_list.png");

            var photo = new InputOnlineFile(sr.BaseStream, "price_list.png");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Предоставляю вам мой прайс лист,{selfName}!"
                );

        }



        if (message.ToLower().Contains("мы находимся"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("l:\\direction.png");

            var photo = new InputOnlineFile(sr.BaseStream, "direction.png");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Наша клиника,{selfName}!"
                );

        }

        if (message.ToLower().Contains("обо мне"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Меня зовут 𝓥𝓪𝓵𝓮𝓻𝓲𝔂𝓪. Я косметолог со стажем 6 лет. Помогаю сохранить молодость и здоровье кожи Вашего лица. " +
               "В своей работе косметолога я решаю причины и следствия эстетических проблем, а не просто пытаюсь «скрыть» последствия на время. " +
               "Прощай тональный крем!Если вы обратитесь ко мне, и я увижу, что проблема не только эстетическая, дам рекомендации по анализам и смежным специалистам. Это работает в комплексе." +
               "Не навязываю дорогие и ненужные Вам процедуры или косметику. Подбираю только то, что подходит именно Вам и необходимо в данный момент." +
               "Работаю по профессии в лаборатории кожно-венерологического диспансера с 2017г." +
               "Во время обучения в университете получила дополнительное медсестринское образование, о чем имею сертификат." +
               "Огромным моим преимуществом в освоении и применении техник косметологии является мое образование и опыт работы по профессии, я знаю, как устроен человеческий организм, его процессы, где искать причины проблем с кожей и как их устранять."
               
               );
        }

        if (message.ToLower().Contains("обо мне"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("l:\\sertifikat.png");

            var photo = new InputOnlineFile(sr.BaseStream, "sertifikat.png");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Так же я прошла курсы,{selfName}!"
                );

        }

        if (message.ToLower().Contains("запишите меня на "))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Хорошо, записала✓︎"
           );
        }

        if (message.ToLower().Contains("расскажите об процедурах"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "✿︎Лазерная эпиляция" +
               "Диодный лазер позволяет избавиться от волос навсегда на любых участках тела за несколько процедур. Он максимально бережно воздействует, поэтому вы не почувствуете никаких болевых ощущений и за короткое время сможете получить гладкую, нежную кожу." +

               "✿︎Лазерное лечение акне на аппарате М22" +
               "Уменьшение количества и выраженности воспалительных элементов за 1–4 сеанса." +
               "Пройдите фотолечение акне на аппарате М22 – после заметно сократится количество высыпаний, уменьшится жирность кожи и выровняется цвет лица. Генерируемые прибором лучи IPL разрушают вызывающие воспаления патогенные микроорганизмы, подсушивают имеющиеся элементы, нормализуют работу сальных желез и стимулируют обновление эпидермиса." +
               "Процедура не повреждает здоровье структуры кожи и иммунитет, поэтому возможно лечение акне лазером на любом участке тела – лице, шее, груди или спине. Для удаления практически всех воспалительных элементов достаточно 1–4 сеансов в зависимости от состояния кожи: для полного устранения проблемы вам будет необходимо соблюдать рекомендации косметолога." +

               "✿︎О процедурах М22" +
               "М22 – прорыв в области косметологии. Он существенно омолодит вашу кожу и за несколько процедур поможет избавиться от косметологических недостатков: пигментации, сосудистых звездочек." +

               "✿︎Дерматоскопия и трихоскопия с помощью Aramo Smart Lite." +
               "Избавьтесь от проблем с кожей головы." +
               "Дерматоскоп Aramo Smart Lite (ASL-300) – корейский аппарат, который помогает наиболее полно обследовать кожные покровы. А также диагностировать недуг на начальном этапе и увеличить шанс избавиться от него." +

               "✿︎Биоревитализация лица, зоны декольте и других частей тела." +
               "Эффективная методика профилактики и коррекции возрастных изменений." +
               "Поддержите молодость и красоту своей кожи – пройдите курс биоревитализации в нашей клинике. Во время процедуры косметолог сделает инъекции подходящего вам препарата на основе гиалуроновой кислоты, которая удерживает влагу и придает эпидермису упругость и эластичность. " +
               "После 1–2 сеансов вы заметите положительные изменения – исчезнут признаки увядания кожи, разгладятся морщины и замедлятся процессы старения. Результат сохранится в течение 6–12 месяцев в зависимости от особенностей вашего организма и соблюдения предписаний косметолога."
           );
        }



        if (!isFind)
        {
            await botClient.SendTextMessageAsync(
              chatId: chatId,
              text: "Извините, я вас не понимаю. Сформулируйте правильно вопрос."
          );
        }
    }



    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();

        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // разрешено получать все виды апдейтов
        };

        bot.StartReceiving(
        HandleUpdateAsync,
            HandleErrorAsync,
             receiverOptions,
            cancellationToken

        );
        Console.ReadLine();
    }
}
