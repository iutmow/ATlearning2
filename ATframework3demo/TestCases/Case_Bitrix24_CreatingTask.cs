using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_CreatingTask : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка создания задачи", homePage => CreatingTask(homePage)));
            return caseCollection;
        }

        void CreatingTask(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            var task = new Bitrix24Task("Задача для автотеста " + DateTime.Now.Ticks) { Description = "Описание задачи для автотеста" + +DateTime.Now.Ticks };
            //перейти в Задачи и Проекты
            homePage.LeftMenu
                .OpenTasks()
                //клик в Добавить задачу
                .AddTaskBtn()
                //ввести название задачи
                .GiveNameToTask(task)
                //ввести описание задачи
                .GiveDescriptionToTask(task)
                //клик в Поставить задачу
                .SetTask()
                //открыть созданную задачу
                .OpenCreatedTask(task);
                //добавить комментарий с ответственным
                //.AddComment();
                //проверить название, описание задачи и комментарий к ней
                //.CheckTask(task);


                
                
                
                



        }

     
    }
}
