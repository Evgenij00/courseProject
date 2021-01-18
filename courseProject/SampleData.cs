using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Models;

namespace courseProject
{
    public static class SampleData
    {
        //Данный класс определяет один статический метод Initialize(),
        //в котором происходит добавление 4x начальных элементов - объектов Test.
        //Для добавления объектов в бд в метод Initialize передается контекст данных
        public static void Initialize(ApplicationDbContext context)
        {
            Category category1 = new Category
            {
                Name = "Личность и характер",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg"
            };

            Test test1 = new Test
            {
                Name = "Вы добрый человек?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Добро всегда во все времена в почете, воспевается в песнях, ему посвящаются истории, сказки. Считается, что оно побеждает зло и в любом случае считается положительным качеством человека. Но им, к сожалению, некоторые люди обделены. И если кто-то готов отдать все ближнему, то у других не допросишься и песка в пустыне. А насколько вы добрый человек? Пройдите тест на доброту онлайн, чтобы это узнать. Готовы?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 10,
                Category = category1,
            };

            Question question1 = new Question
            {
                Name = "Делитесь вкусняшками со знакомыми?",
                Number = 1,
                Test = test1,
            };

            Question question2 = new Question
            {
                Name = "Участвуете в благотворительных акциях?",
                Number = 2,
                Test = test1,
            };

            Question question3 = new Question
            {
                Name = "Заступаетесь за слабых?",
                Number = 3,
                Test = test1,
            };

            Question question4 = new Question
            {
                Name = "Подкармливаете бездомных животных?",
                Number = 4,
                Test = test1,
            };

            Question question5 = new Question
            {
                Name = "Уверенность в своей правоте мешает вам выслушать аргументы оппонента?",
                Number = 5,
                Test = test1,
            };

            Question question6 = new Question
            {
                Name = "Как вы относитесь к небольшим просьбам окружающих?",
                Number = 6,
                Test = test1,
            };

            Question question7 = new Question
            {
                Name = "Прощаете знакомым долги?",
                Number = 7,
                Test = test1,
            };

            Question question8 = new Question
            {
                Name = "Если ваш партнер плохо играет в настольные игры, вы бы поддавались ему/ей, чтобы сделать приятно?",
                Number = 8,
                Test = test1,
            };

            Question question9 = new Question
            {
                Name = "Знакомый рассказывает вам о своих проблемах, но вам не интересно это слушать. Что вы сделаете?",
                Number = 9,
                Test = test1,
            };

            Question question10 = new Question
            {
                Name = "Можете ли вы назвать себя злопамятным человеком?",
                Number = 10,
                Test = test1,
            };

            Answer answer1 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question1,
            };

            Answer answer2 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question1,
            };

            Answer answer3 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question2,
            };

            Answer answer4 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question2,
            };

            Answer answer5 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question3,
            };

            Answer answer6 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question3,
            };

            Answer answer7 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question4,
            };

            Answer answer8 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question4,
            };

            Answer answer9 = new Answer
            {
                Name = "Да",
                Score = 2,
                Question = question5,
            };

            Answer answer10 = new Answer
            {
                Name = "Нет",
                Score = 1,
                Question = question5,
            };

            Answer answer11 = new Answer
            {
                Name = "Охотно выполняю, я люблю помогать!",
                Score = 1,
                Question = question6,
            };

            Answer answer12 = new Answer
            {
                Name = "Откликаюсь только если мне это выгодно",
                Score = 2,
                Question = question6,
            };

            Answer answer13 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question7,
            };

            Answer answer14 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question7,
            };

            Answer answer15 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question8,
            };

            Answer answer16 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question8,
            };

            Answer answer17 = new Answer
            {
                Name = "Покажу, что желаю сменить тему",
                Score = 2,
                Question = question9,
            };

            Answer answer18 = new Answer
            {
                Name = "Внимательно выслушаю и поддержу",
                Score = 3,
                Question = question9,
            };

            Answer answer19 = new Answer
            {
                Name = "Да",
                Score = 2,
                Question = question10,
            };

            Answer answer20 = new Answer
            {
                Name = "Нет",
                Score = 1,
                Question = question10,
            };

            ResultTest result1 = new ResultTest
            {
                Description = "Доброта - это не универсальная черта характера и далеко не всегда она хороша. Однако, ваше окружение скорее всего пожелало бы вам почаще быть добрым. Общаться с вами сложно, а услышать что-либо доброжелательное - еще сложнее. Если вам присущ чисто прагматический подход к отношениям, мы рекомендуем обращаться не только к кнуту. Внимание к окружающим несет больше пользы, чем кажется, будьте добрее!",
                Scores = 21,
                Test = test1,
            };

            ResultTest result2 = new ResultTest
            {
                Description = "Для вас доброту нужно заслужить. Кто-то из вашего окружения ее достоин, а для кого-то общение с вами это сущая мука. Скорее всего, люди не смогут определиться, если спросить их о вас. Если вы не стремитесь вызывать обиду и раздражение, попробуйте относиться ко всем с одинаковым уважением и вниманием.",
                Scores = 16,
                Test = test1,
            };

            ResultTest result3 = new ResultTest
            {
                Description = "Нельзя быть хорошим для всех, но вы стараетесь. Стоит ли говорить, что такой подход опасен! Нельзя всем угодить, рано или поздно отношения с кем-то начнут ухудшаться, потому что вы добры к кому-то другому. Мы рекомендуем стремиться к взаимоуважительным отношениям и пониманию - таким образом вы будете избегать конфликтов, а при случае удачно их разрешать!",
                Scores = 12,
                Test = test1,
            };

            Test test2 = new Test
            {
                Name = "Какой у вас стиль юмора?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Невозможно определить время появления юмора, точно так же, как нельзя сказать, когда человек впервые рассмеялся. Чувство юмора на самом деле не всегда может нести позитив. В некоторых его проявлениях может содержаться и отрицательное воздействие и на самого человека, и на окружающих. Выделяют следующие стили юмора: Аффилиативный; Самоподдерживающий; Агрессивный; Самоуничижительный. Тест предназначен для диагностики предпочтительного использования разных видов или стилей юмора, различающихся по своей адаптивности и направленности. Чтобы узнать на каком уровне у вас находится каждый из этих стилей, пройдите тест Рода Мартина и Патриши Дорис на стили юмора онлайн. Начнем?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category1,
            };

            Question question11 = new Question
            {
                Name = "Любую напряженную ситуацию может скрасить шутка.",
                Number = 1,
                Test = test2,
            };

            Answer answer21 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question11,
            };

            Answer answer22 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question11,
            };

            ResultTest result4 = new ResultTest
            {
                Description = "Положительный юмор . Люди с положительным чувством юмора часто шутят, спонтанно вовлекаются в добродушный обмен шутливыми замечаниями. Это мягкий, доброжелательный и толерантный стиль юмора. Он способствует укреплению межличностных отношений и росту взаимной привлекательности.",
                Scores = 2,
                Test = test2,
            };

            ResultTest result5 = new ResultTest
            {
                Description = "Враждебный юмор включает в себя сарказм, насмешку, подтрунивание, он может быть использован в целях манипуляции другими людьми. Люди, которые используют такой стиль юмора не могут остановиться и прекратить шутить над окружающими. За это их не всегда любят. К ним относятся настороженно, а иногда и отрицательно.",
                Scores = 3,
                Test = test2,
            };

            Test test3 = new Test
            {
                Name = "Насколько вы счастливы?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Что такое счастье? - один из вечных вопросов человеческой жизни. В последнее время написано особенно много трудов, которые пытаются найти ответ на этот вопрос. Они предоставляют нам множество советов о том, как стать счастливыми, но почему-то помогают они далеко не всем. Наверное, один из главных способов обретения счастья - гармония человека со своими мыслями, действиями и желаниями. К сожалению, уровень нашего ощущения счастья не постоянен и может очень сильно меняться от любых событий в жизни. Тест на уровень счастья поможет определить ваше текущее состояние. Находитесь ли вы в эйфории или на грани депрессии? Данный опросник счастья даст вам ответ!",
                Autors = "Оксфордский университет",
                NumberOfQuestions = 1,
                Category = category1,
            };

            Question question12 = new Question
            {
                Name = "Любую напряженную ситуацию может скрасить шутка.",
                Number = 1,
                Test = test3,
            };

            Answer answer23 = new Answer
            {
                Name = "я невероятно счастлив",
                Score = 1,
                Question = question12,
            };

            Answer answer24 = new Answer
            {
                Name = "я не могу сказать, что счастлив (-а)",
                Score = 2,
                Question = question12,
            };

            ResultTest result6 = new ResultTest
            {
                Description = "Поразительно высокий показатель счастья. Либо у вас крайне светлая полоса, либо у вас практически не бывает проблем и вы научились ценить и любить, то что вас окружает.",
                Scores = 2,
                Test = test3,
            };

            ResultTest result7 = new ResultTest
            {
                Description = "Низкий показатель счастья. С большой вероятностью вы находитесь в состоянии депрессии, апатии или испытываете кризис. Если это действительно так, то стоит обратиться к специалисту.",
                Scores = 3,
                Test = test3,
            };

            Category category2 = new Category
            {
                Name = "Межличностные отношения",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg"
            };

            Test test4 = new Test
            {
                Name = "Тест на умение разбираться в людях",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Когда мы видим кого-либо, будь то наш знакомый или неизвестный человек, мы, на основе опыта или стереотипов делаем какие-то выводы о нем для себя. Умение делать их объективно в современном мире крайне ценно. Человек, умеющий разбираться в людях, способен вовремя распознать ложь, лукавство, истинные намерения другого, не стать жертвой, не быть обманутым. Это немаловажное качество для многих профессий, работающих с людьми. Вы можете пройти тест, чтобы узнать, умеете ли разбираться в людях и чувствовать их сущность или нет. Начнем?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category2,
            };

            Question question13 = new Question
            {
                Name = "Если при первой встрече с человеком он начинает шутить и рассказывать анекдоты, то этот человек...",
                Number = 1,
                Test = test4,
            };

            Answer answer25 = new Answer
            {
                Name = "весельчак",
                Score = 1,
                Question = question13,
            };

            Answer answer26 = new Answer
            {
                Name = "не уверен в себе",
                Score = 2,
                Question = question13,
            };

            ResultTest result8 = new ResultTest
            {
                Description = "Обычно вы довольно уверены в своем мнении, но оно не настолько непоколебимо, как вам кажется. И любая убедительная точка зрения стороннего человека способна убедить вас в ее правдивости. Постарайтесь быть более наблюдательным и внимательным человеком! Вам это точно под силу.",
                Scores = 3,
                Test = test4,
            };

            Test test5 = new Test
            {
                Name = "Легко ли вас обмануть?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Как думаете, легко ли вас ввести в заблуждение? Или одурачить и оставить у разбитого корыта? Сегодня мы попробуем найти ответы на эти вопросы! Обман — безобидный или грозящий серьезными последствиями — поджидает нас на каждом шагу. Сможете ли вы его увидеть и противостоять лжецу или он получит желаемое? Проходите подготовленный нами тест, расположенный ниже, и узнайте, насколько вы доверчивы. Не думали, что всё так просто? Тем не менее это так!",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category2,
            };

            Question question14 = new Question
            {
                Name = "Верите ли вы в то, что вам говорят?",
                Number = 1,
                Test = test5,
            };

            Answer answer27 = new Answer
            {
                Name = "Я все проверяю лично",
                Score = 1,
                Question = question14,
            };

            Answer answer28 = new Answer
            {
                Name = "Я доверяю своей интуиции",
                Score = 2,
                Question = question14,
            };

            ResultTest result9 = new ResultTest
            {
                Description = "Чтобы вас обмануть необходимо приложить чуть больше усилий, чем обычно. Но если лжец выявит особенности вашего настроения, то ему будет намного проще получить свое. Поэтому при общение с людьми чаще обращаете внимание на мимику и жесты, они обычно подводят лгунов.",
                Scores = 3,
                Test = test5,
            };

            Test test6 = new Test
            {
                Name = "Насколько вы надежный друг?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Сколько людей, которых мы называем друзьями уходят из нашего круга общения в течение жизни? А ведь может причина не в них, а в нас самих. Тест на дружбу поможет вам разобраться в этом вопросе!  А насколько вы надежный друг? Можно ли на вас положиться в любой момент или вы рядом только, когда вам выгодно? Этот тест на дружбу откроет вам правду. Узнаем это прямо сейчас?",
                Autors = "Исаева Е. Л.",
                NumberOfQuestions = 1,
                Category = category2,
            };

            Question question15 = new Question
            {
                Name = "Вы принципиальны?",
                Number = 1,
                Test = test6,
            };

            Answer answer29 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question15,
            };

            Answer answer30 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question15,
            };

            ResultTest result10 = new ResultTest
            {
                Description = "Вам нравится держать свое слово, и в нужный момент друзья всегда могут рассчитывать на вас. Однако абсолютная надежность не единственная ваша черта: вы любимы окружением из-за своего характера. В принципе вы можете опоздать на поезд, забыть что-то сделать в срок или не вспомнить вовремя о каком-то мелком деле. Тем не менее вам всегда удается исправить эти ошибки.",
                Scores = 3,
                Test = test6,
            };

            Category category3 = new Category
            {
                Name = "Для мужчин",
                Icon = "https://testometrika.com/upload/uf/44b/44b124a5190d5ecd4212d08d47cbd9c5.svg"
            };

            //Test test7 = new Test
            //{
            //    Name = "Командир или рядовой?",
            //    Icon = "https://testometrika.com/upload/uf/44b/44b124a5190d5ecd4212d08d47cbd9c5.svg",
            //    Description = " В нашей жизни есть много сходств с армией. Возьмем, например, рабочий коллектив распределение ролей такое же, как и в армии. Кто все контролирует и руководит, а кто - то копает от забора до обеда. С мыслями, что скоро тоже будет раздавать всем приказы. А вы сами творите свою судьбу или это делает кто-то другой за вас? Берете ли на себя ответственность за свои действия или перекладываете это на других?  Пройдите этот тест и узнайте, кто вы! Рядовой или командир в своей жизни?",
            //    Autors = "Testometrika Team",
            //    NumberOfQuestions = 1,
            //    Category = category3,
            //};

            //Question question16 = new Question
            //{
            //    Name = "Можете ли вы организовывать других людей?",
            //    Number = 1,
            //    Test = test7,
            //};

            //Answer answer31 = new Answer
            //{
            //    Name = "Да",
            //    Score = 1,
            //    Question = question16,
            //};

            //Answer answer32 = new Answer
            //{
            //    Name = "Нет",
            //    Score = 2,
            //    Question = question16,
            //};

            //ResultTest result11 = new ResultTest
            //{
            //    Description = "Вы человек достаточно ответственный и способный воспринимать адекватно руководство как необходимость. При большом желании вы можете стать лидером и руководить людьми, но пока вам и в роли подчиненного не плохо. Но знайте, что у вас есть потенциал, нужно лишь поработать над этим.",
            //    Scores = 3,
            //    Test = test7,
            //};

            Test test8 = new Test
            {
                Name = "Командир или рядовой?",
                Icon = "https://testometrika.com/upload/uf/44b/44b124a5190d5ecd4212d08d47cbd9c5.svg",
                Description = " В нашей жизни есть много сходств с армией. Возьмем, например, рабочий коллектив распределение ролей такое же, как и в армии. Кто все контролирует и руководит, а кто - то копает от забора до обеда. С мыслями, что скоро тоже будет раздавать всем приказы. А вы сами творите свою судьбу или это делает кто-то другой за вас? Берете ли на себя ответственность за свои действия или перекладываете это на других?  Пройдите этот тест и узнайте, кто вы! Рядовой или командир в своей жизни?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category3,
            };

            Question question17 = new Question
            {
                Name = "Можете ли вы организовывать других людей?",
                Number = 1,
                Test = test8,
            };

            Answer answer33 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question17,
            };

            Answer answer34 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question17,
            };

            ResultTest result12 = new ResultTest
            {
                Description = "Вы человек достаточно ответственный и способный воспринимать адекватно руководство как необходимость. При большом желании вы можете стать лидером и руководить людьми, но пока вам и в роли подчиненного не плохо. Но знайте, что у вас есть потенциал, нужно лишь поработать над этим.",
                Scores = 3,
                Test = test8,
            };

            Category category4 = new Category
            {
                Name = "Для девушек",
                Icon = "https://testometrika.com/upload/uf/eac/eac94180f85189ccbae32cd8243d4321.svg"
            };

            Test test9 = new Test
            {
                Name = "Жертва или охотница?",
                Icon = "https://testometrika.com/upload/uf/eac/eac94180f85189ccbae32cd8243d4321.svg",
                Description = "В любовных делах у каждой девушки стиль поведения свой собственный уникальный. У кого-то отлично получается показывать свою решительность и доминирование, они готовы заполучить желанного принца любыми способами, поборов каждую конкурентку, а другие - могут годами сидеть тихо и ждать своего суженного. Важно ли для тебя постоянно быть на первых ролях или же ты спокойно относишься к вниманию сильного пола? Не знаешь к какому из этих типов ты относишься? Тогда этот тест для тебя! Узнай кто ты? Жертва или охотник? Этот тест покажет истину!",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category4,
            };

            Question question18 = new Question
            {
                Name = "Даже если кто-то позволяет себе говорить гадости в твой адрес, то ты никогда не опустишься до такого же поведения?",
                Number = 1,
                Test = test9,
            };

            Answer answer35 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question18,
            };

            Answer answer36 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question18,
            };

            ResultTest result13 = new ResultTest
            {
                Description = "Ты скорее охотница. Никому и никогда ты не позволишь обидеть или унизить себя. Ты очень яркая и необычная девушка, поэтому реальных соперниц у тебя на самом деле мало. Поэтому ни один парень в здравом уме от тебя отказаться просто не в состоянии. Общественное мнение для тебя всегда на последнем месте, так как ты привыкла думать своей головой.",
                Scores = 3,
                Test = test9,
            };

            Category category5 = new Category
            {
                Name = "Для детей",
                Icon = "https://testometrika.com/upload/uf/e0a/e0a0cc54c382a57350fb298f05334d2d.svg"
            };

            Test test10 = new Test
            {
                Name = "Ваш ребенок талантливый?",
                Icon = "https://testometrika.com/upload/uf/e0a/e0a0cc54c382a57350fb298f05334d2d.svg",
                Description = "Любой ребенок обладает каким-либо талантом и способностью. И даже если вам кажется, что это не так, знайте: Вы ошибаетесь! Нужно просто постараться их найти. Тест на таланты ребенка 7–13 лет способен выявить их наличие. А если вдруг окажется, что их нет – не расстраивайтесь! Ваш ребенок растет и развивается, а его таланты и способности также развиваются вместе с ним. Пройдите тест на таланты прямо сейчас!",
                Autors = "Testometrika Team",
                NumberOfQuestions = 1,
                Category = category5,
            };

            Question question19 = new Question
            {
                Name = "Может ли ваш ребенок придумать необычное применение какому - нибудь предмету?",
                Number = 1,
                Test = test10,
            };

            Answer answer37 = new Answer
            {
                Name = "Да",
                Score = 1,
                Question = question19,
            };

            Answer answer38 = new Answer
            {
                Name = "Нет",
                Score = 2,
                Question = question19,
            };

            ResultTest result14 = new ResultTest
            {
                Description = "Ваш ребенок очень талантлив, сообразителен и имеет свою точку зрения на происходящие события. Он активно проявляет себя, берет инициативу в свои руки и постоянно изобретает что - то новое.",
                Scores = 3,
                Test = test10,
            };


            if (!context.Categories.Any())
            {
                context.Categories.AddRange(category1, category2, category3, category4, category5);
                context.SaveChanges();
            }

            //если данные в таблице Tests в бд отсутствуют (if (!context.Tests.Any())), то добавляются 4 объекта.
            if (!context.Tests.Any())
            {
                context.Tests.AddRange(test1, test2, test3, test4, test5, test6, test8, test9, test10);
                context.SaveChanges();
            }

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(question1, question2, question3, question4, question5, question6, question7, question8, question9,
                                            question10, question11, question12, question13, question14, question15, question17, question18, question19);
                context.SaveChanges();
            }

            if (!context.Answers.Any())
            {
                context.Answers.AddRange(answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9,
                                        answer10, answer11, answer12, answer13, answer14, answer15, answer16, answer17, answer18,
                                        answer19, answer20, answer21, answer22, answer23, answer24, answer25, answer26, answer27,
                                        answer28, answer29, answer30, answer33, answer34, answer35, answer36,
                                        answer37, answer38);
                context.SaveChanges();
            }

            if (!context.ResultTests.Any())
            {
                context.ResultTests.AddRange(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result12, result13, result14);
                context.SaveChanges();
            }
        }
    }
}