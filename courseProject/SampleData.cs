﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Models; //для TestsContext

namespace courseProject
{
    public static class SampleData
    {
        //Данный класс определяет один статический метод Initialize(),
        //в котором происходит добавление 4x начальных элементов - объектов Test.
        public static void Initialize(ApplicationDbContext context) //Для добавления объектов в бд в метод Initialize передается контекст данных
        {
            Category category1 = new Category
            {
                //Id = 1,
                Name = "Личность и характер",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg"
            };
            Category category2 = new Category
            {
                //Id = 2,
                Name = "Межличностные отношения",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg"
            };
            Category category3 = new Category
            {
                //Id = 3,
                Name = "Депрессия и стресс",
                Icon = "https://testometrika.com/upload/uf/ba1/ba128dca62e8ca4cdaf166addae7afde.svg"
            };
            Category category4 = new Category
            {
                //Id = 4,
                Name = "Для детей",
                Icon = "https://testometrika.com/upload/uf/e0a/e0a0cc54c382a57350fb298f05334d2d.svg"
            };
            Category category5 = new Category
            {
                //Id = 5,
                Name = "Для мужчин",
                Icon = "https://testometrika.com/upload/uf/44b/44b124a5190d5ecd4212d08d47cbd9c5.svg"
            };

            Test test1 = new Test
            {
                //Id = 1,
                Name = "Насколько Вы адекватны?",
                Icon = "https://testometrika.com/upload/uf/dcd/dcd5c93c830de7cc1d553956098d208c.svg",
                Description = "Вспомните своих знакомых. Всех ли их можно назвать нормальными? А себя вы считаете таким? Давайте признаемся, что иногда быть адекватным человеком крайне скучно и начинаешь гореть желанием совершать безумные поступки, чудить и выходить из зоны собственного комфорта. Возможно периодически вы совершаете какие-либо поступки, выходящие за рамки общепринятого поведения? Или все-таки это стиль вашей жизни? Может быть, вы сами не знаете о том, что у вас не все дома. Этот тест на адекватность поможет выяснить, заблуждаетесь ли вы в своих суждениях. Пройдите тест сами и предложите его друзьям! Давайте узнаем кто адекватнее?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category2,
            };
            Test test2 = new Test
            {
                //Id = 2,
                Name = "Уровень уверенности в себе",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Уверенность в себе, в своих силах, безусловно важное качество в современном мире. Многим хочется быть успешными, добиваться поставленных целей, смело смотреть в будущее и воплощать мечты в реальность. Если у человека низкая самооценка, неуверенность в себе, проблемы будут начинаться на этапе постановки цели.И даже если она будет поставлена, маловероятно, что начнет осуществляться.Поэтому важно развивать это качество в себе. Существует огромное множество статей, пособий, курсов, тренингов, посвященных этой тематике.Но прежде, чем начать самосовершенствоваться необходимо определить свой текущий уровень.Для этого можно пройти онлайн тест на уверенность в себе.Вы готовы по новому взглянуть в будущее и изменить свою жизнь ? ",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category1,
            };
            Test test3 = new Test
            {
                //Id = 3,
                Name = "Тест на синдром хронической усталости",
                Icon = "https://testometrika.com/upload/uf/ba1/ba128dca62e8ca4cdaf166addae7afde.svg",
                Description = "Синдром хронической усталости последнее время все чаще начинает встречаться у людей, особенно в цивилизованных странах. Огромный темп жизни, стремительный рост технологий, постоянная нагруженность и эмоциональная и физическая выматывают нас ежедневно. Можно выделить несколько основных симптомов: постоянное переутомление, даже после продолжительного отдыха тревожный проблемный сон мышечная боль распухшие суставы мигрени Чтобы вовремя диагностировать и приступить к лечению нужно пройти тест на хроническую усталость.И уже по его результатам решать, стоит ли обращаться за помощью к специалисту.Приступим к прохождению ? Больше подробностей о синдроме узнайте в нашем блоге.",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category3,
            };
            Test test4 = new Test
            {
                //Id = 4,
                Name = "Развивающий тест для дошкольников",
                Icon = "https://testometrika.com/upload/uf/e0a/e0a0cc54c382a57350fb298f05334d2d.svg",
                Description = "Дети - цветы жизни. Как и цветок, ребенка нужно напитывать знаниями и навыками, которые пригодятся в жизни, например, как различать фрукты и ягоды, какие животные впадают зимой в спячку или какие деревья всегда зеленые. Пройдите со своим ребенком этот развивающий тест для дошкольников, чтобы проверить знания малыша!",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category4,
            };
            Test test5 = new Test
            {
                //Id = 5,
                Name = "Какой у вас стиль юмора?",
                Icon = "https://testometrika.com/upload/uf/3ce/3cecd2c79d3224c1df1c1bf982778abf.svg",
                Description = "Невозможно определить время появления юмора, точно так же, как нельзя сказать, когда человек впервые рассмеялся. Чувство юмора на самом деле не всегда может нести позитив. В некоторых его проявлениях может содержаться и отрицательное воздействие и на самого человека, и на окружающих. Выделяют следующие стили юмора: Аффилиативный; Самоподдерживающий; Агрессивный; Самоуничижительный. Тест предназначен для диагностики предпочтительного использования разных видов или стилей юмора, различающихся по своей адаптивности и направленности. Чтобы узнать на каком уровне у вас находится каждый из этих стилей, пройдите тест Рода Мартина и Патриши Дорис на стили юмора онлайн. Начнем ? ",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category1,
            };
            Test test6 = new Test
            {
                //Id = 6,
                Name = "Какой тип женщин мне подходит больше всего?",
                Icon = "https://testometrika.com/upload/uf/44b/44b124a5190d5ecd4212d08d47cbd9c5.svg",
                Description = "При выборе спутницы жизни мы задаемся вопросом: «Какой же тип женщин мне подходит и почему?» Все мы абсолютно разные люди с различными чертами характера, особенностями и привычками, хорошими и плохими. Но это все‐таки часть нас самих, которая делать нас уникальными. Хочется, чтобы нас партнер принимал и понимал такими, какими мы являемся на самом деле, без приукрашивания, естественными и настоящими, независимо от обстоятельств. Конечно, это не простая задача, а никто и не говорил, что будет легко. Можно пройти тест и немного приблизиться к пониманию, какие женщины вам подходят. Начнем?",
                Autors = "Testometrika Team",
                NumberOfQuestions = 3,
                Category = category1,
            };

            Question question1 = new Question
            {
                //Id = 1,
                Name = "Какой из этих образов тебе нравится больше всего?",
                Number = 1,
                Test = test6,
            };
            Question question2 = new Question
            {
                //Id = 2,
                Name = "Какое свидание тебе ближе всего?",
                Number = 2,
                Test = test6,
            };
            Question question3 = new Question
            {
                //Id = 3,
                Name = "Чтобы ты подарил своей девушке?",
                Number = 3,
                Test = test6,
            };

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(category1, category2, category3, category4, category5);
                context.SaveChanges();
            }

            //если данные в таблице Tests в бд отсутствуют (if (!context.Tests.Any())), то добавляются 4 объекта.
            if (!context.Tests.Any())
            {
                context.Tests.AddRange(test1, test2, test3, test4, test5, test6);
                context.SaveChanges();
            }

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(question1, question2, question3);
                context.SaveChanges();
            }
        }
    }
}